#include <iostream>
#include <vector>
#include <cmath>

// ������ά�����ṹ
struct Vector2 {
    float x, y;
    Vector2(float x = 0, float y = 0) : x(x), y(y) {}
};

// ��Ϸ�������
class GameObject {
public:
    virtual Vector2 GetPosition() const = 0;
};

// ����AIϵͳ
class EnemyAI {
public:
    enum State { PATROLLING, CHASING, ATTACKING, IDLE };

    EnemyAI();
    void SetTarget(GameObject* newTarget);
    GameObject* GetTarget() const;
    void Update();
    void Attack();
    void MoveTo(const Vector2& position);

private:
    State state;
    GameObject* target;
    std::vector<Vector2> patrolPoints;
    int patrolIndex;
    static const float chaseRange;
    static const float attackRange;
    Vector2 currentPosition;

    void Patrol();
    void Chase();
    void Idle();
    void CheckStateTransitions();
    bool Reached(const Vector2& position);
    float DistanceTo(const Vector2& position);
};

// ��̬������ʼ��
const float EnemyAI::chaseRange = 10.0f;
const float EnemyAI::attackRange = 1.0f;

EnemyAI::EnemyAI() : state(IDLE), target(nullptr), patrolIndex(0) {
    patrolPoints.push_back(Vector2(0, 0));
    patrolPoints.push_back(Vector2(10, 0));
    patrolPoints.push_back(Vector2(10, 10));
    patrolPoints.push_back(Vector2(0, 10));
}

void EnemyAI::SetTarget(GameObject* newTarget) {
    target = newTarget;
}

GameObject* EnemyAI::GetTarget() const {
    return target;
}

void EnemyAI::Update() {
    switch (state) {
        case PATROLLING:
            Patrol();
            break;
        case CHASING:
            Chase();
            break;
        case ATTACKING:
            Attack();
            break;
        case IDLE:
            Idle();
            break;
    }
    CheckStateTransitions();
}

void EnemyAI::Patrol() {
    MoveTo(patrolPoints[patrolIndex]);
    if (Reached(patrolPoints[patrolIndex])) {
        patrolIndex = (patrolIndex + 1) % patrolPoints.size();
    }
}

void EnemyAI::Chase() {
    if (target) {
        MoveTo(target->GetPosition());
    }
}

void EnemyAI::Attack() {
    if (target) {
        std::cout << "���ڹ���Ŀ�꣬Ŀ��λ�� (" 
                  << target->GetPosition().x << ", " 
                  << target->GetPosition().y << ")\n";
    }
}

void EnemyAI::Idle() {
    std::cout << "������\n";
}

void EnemyAI::CheckStateTransitions() {
    if (target && DistanceTo(target->GetPosition()) <= attackRange) {
        state = ATTACKING;
    } else if (target && DistanceTo(target->GetPosition()) <= chaseRange) {
        state = CHASING;
    } else if (target == nullptr) {
        state = PATROLLING;
    }
}

void EnemyAI::MoveTo(const Vector2& position) {
    std::cout << "�ƶ���λ�� (" << position.x << ", " << position.y << ")\n";
    currentPosition = position;
}

bool EnemyAI::Reached(const Vector2& position) {
    return DistanceTo(position) < 1.0f;
}

float EnemyAI::DistanceTo(const Vector2& position) {
    return std::sqrt(std::pow(position.x - currentPosition.x, 2) +
                     std::pow(position.y - currentPosition.y, 2));
}

// ��Ϊ�ڵ����
class BehaviorNode {
public:
    virtual ~BehaviorNode() {}
    virtual bool Tick() = 0;
};

// ѡ�����ڵ�
class SelectorNode : public BehaviorNode {
public:
    void AddChild(BehaviorNode* child) {
        children.push_back(child);
    }
    bool Tick() override {
        for (size_t i = 0; i < children.size(); ++i) {
            if (children[i]->Tick()) {
                return true;
            }
        }
        return false;
    }

private:
    std::vector<BehaviorNode*> children;
};

// ���нڵ�
class SequenceNode : public BehaviorNode {
public:
    void AddChild(BehaviorNode* child) {
        children.push_back(child);
    }
    bool Tick() override {
        for (size_t i = 0; i < children.size(); ++i) {
            if (!children[i]->Tick()) {
                return false;
            }
        }
        return true;
    }

private:
    std::vector<BehaviorNode*> children;
};

// ��Ϊ�ڵ�ʵ��
class AttackNode : public BehaviorNode {
public:
    AttackNode(EnemyAI* enemy) : enemy(enemy) {}
    bool Tick() override {
        if (enemy->GetTarget()) {
            enemy->Attack();
            return true;
        }
        return false;
    }

private:
    EnemyAI* enemy;
};

class ChaseNode : public BehaviorNode {
public:
    ChaseNode(EnemyAI* enemy) : enemy(enemy) {}
    bool Tick() override {
        if (enemy->GetTarget()) {
            enemy->MoveTo(enemy->GetTarget()->GetPosition());
            return true;
        }
        return false;
    }

private:
    EnemyAI* enemy;
};

class PatrolNode : public BehaviorNode {
public:
    PatrolNode(EnemyAI* enemy) : enemy(enemy) {}
    bool Tick() override {
        enemy->Update();
        return true;
    }

private:
    EnemyAI* enemy;
};

// ������Ϸ����
class TestTarget : public GameObject {
public:
    TestTarget(float x, float y) : position(x, y) {}
    Vector2 GetPosition() const override {
        return position;
    }

private:
    Vector2 position;
};






/*




 // ��������AI�Ͳ���Ŀ��
    EnemyAI enemyAI;
    TestTarget target(5.0f, 5.0f);

    // ����Ŀ��
    enemyAI.SetTarget(&target);

    // ������Ϊ��
    SelectorNode* root = new SelectorNode();
    root->AddChild(new ChaseNode(&enemyAI));
    root->AddChild(new AttackNode(&enemyAI));
    root->AddChild(new PatrolNode(&enemyAI));

    // ���µ���AI����Ϊ��
    for (int i = 0; i < 10; ++i) {
        std::cout << "���²��� " << i << ":\n";
        enemyAI.Update();
        root->Tick();
    }

    // �����ڴ�
    delete root;



*/