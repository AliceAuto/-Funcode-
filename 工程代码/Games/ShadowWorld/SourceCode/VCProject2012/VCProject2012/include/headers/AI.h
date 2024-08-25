#ifndef AI_H
#define AI_H

#include "StateMachine.h"

// Ѳ��״̬��
class PatrollingState : public State {
public:
    void Enter() override {
        std::cout << "Entering Patrolling State." << std::endl;
        // ��ʼ��Ѳ��·�������������Դ
    }

    void Exit() override {
        std::cout << "Exiting Patrolling State." << std::endl;
        // ����Ѳ��·�������������Դ
    }

    void Update() override {
        std::cout << "Updating Patrolling State." << std::endl;
        // ����Ѳ���߼������ƶ�����һ��Ѳ�ߵ�
    }

    void HandleMouseInput(const MouseInputEvent& event) override {
        // ������������¼��������Ҫ��
    }

    void HandleKeyboardInput(const KeyboardInputEvent& event) override {
        // ������������¼��������Ҫ��
    }

protected:
    State* CreateState() const override {
        return new PatrollingState();
    }

    void RegisterEventListeners() override {
        // ע���¼�������������У�
    }

    void UnregisterEventListeners() override {
        // ȡ���¼�������������У�
    }
};



















// ׷��״̬��#include "StateMachine.h"
#include "StateMachine.h"
#include <iostream>
#include <vector>
#include <memory>

// �Ӿ�̽���Ӿ����࣬���ڼ���ϰ���
class VisualSensor {
public:
    // ���·�����Ƿ�����ϰ���
    bool IsObstacleInPath(const std::vector<std::vector<bool>>& map, const std::pair<int, int>& from, const std::pair<int, int>& to) {
        // ��ʵ�֣����Բ�ֵ����ϰ���
        int x1 = from.first, y1 = from.second;
        int x2 = to.first, y2 = to.second;
        int dx = abs(x2 - x1);
        int dy = abs(y2 - y1);
        int sx = (x1 < x2) ? 1 : -1;
        int sy = (y1 < y2) ? 1 : -1;
        int err = dx - dy;

        while (true) {
            if (x1 >= 0 && x1 < map[0].size() && y1 >= 0 && y1 < map.size()) {
                if (map[y1][x1]) return true;
            }
            if (x1 == x2 && y1 == y2) break;
            int e2 = err * 2;
            if (e2 > -dy) {
                err -= dy;
                x1 += sx;
            }
            if (e2 < dx) {
                err += dx;
                y1 += sy;
            }
        }
        return false;
    }
};


// ׷��״̬��
class ChasingState : public State {
public:
    ChasingState() : visualSensor_(new VisualSensor()) {}

    void Enter() override {
        std::cout << "Entering Chasing State." << std::endl;
        // ��ʼ��׷��Ŀ��
    }

    void Exit() override {
        std::cout << "Exiting Chasing State." << std::endl;
        // ֹͣ׷��Ŀ��
    }

    void Update() override {
        std::cout << "Updating Chasing State." << std::endl;

        if (targetPosition_ == std::make_pair(-1, -1)) {
            std::cout << "No target set, cannot chase." << std::endl;
            return;
        }

        // ��ȡ��ǰλ��
        std::pair<int, int> currentPosition = GetCurrentPosition();

        if (visualSensor_->IsObstacleInPath(map_, currentPosition, targetPosition_)) {
            // ���ϰ������ӡ
            std::pair<int, int> footprint = FindFootprint();
            if (footprint != std::make_pair(-1, -1)) {
                // Ŀ���н�ӡ�����ӡ�ƶ�
                MoveToPosition(footprint);
            } else {
                // ��ӡ��ʧ������׷��
                std::cout << "No visible footprints, stopping chase." << std::endl;
                Exit();
            }
        } else {
            // ���ϰ��ֱ����Ŀ���ƶ�
            MoveToPosition(targetPosition_);
        }

        // ����Ƿ񵽴�Ŀ��
        if (currentPosition == targetPosition_) {
            std::cout << "Reached target!" << std::endl;
            // �л�������״̬
            // ToNextState("AttackingState");
        }
    }

    void HandleMouseInput(const MouseInputEvent& event) override {
        // ������������¼��������Ҫ��
    }

    void HandleKeyboardInput(const KeyboardInputEvent& event) override {
        // ������������¼��������Ҫ��
    }

    void SetTargetPosition(const std::pair<int, int>& targetPosition) {
        targetPosition_ = targetPosition;
    }

    void SetMap(const std::vector<std::vector<bool>>& map) {
        map_ = map;
    }

private:
    VisualSensor* visualSensor_; // ʹ����ָ���Լ��ݾɰ汾�ı�����
    std::pair<int, int> targetPosition_; // Ŀ��λ�ã�Ĭ��Ϊ��Чֵ
    std::vector<std::vector<bool>> map_; // ��ͼ����

    std::pair<int, int> GetCurrentPosition() {
        // ��ȡ��ǰ AI λ��
        // ���ﷵ��һ��ʾ��λ��
        return std::make_pair(0, 0); // ʵ��ʵ��Ӧ�� AI �����л�ȡλ��
    }

    void MoveToPosition(const std::pair<int, int>& position) {
        // �ƶ� AI ��ָ��λ��
        std::cout << "Moving to position: (" << position.first << ", " << position.second << ")" << std::endl;
        // ʵ���ƶ��߼�
    }

    std::pair<int, int> FindFootprint() {
        // ���ҿɼ���ӡ
        // ����򵥷���һ��ʾ����ӡλ��
        return std::make_pair(5, 5); // ʵ��ʵ��Ӧ���ݽ�ӡ��λ�ý��в���
    }

    State* CreateState() const override {
        return new ChasingState();
    }

    void RegisterEventListeners() override {
        // ע���¼�������������У�
    }

    void UnregisterEventListeners() override {
        // ȡ���¼�������������У�
    }
};





















// ����״̬��
class AttackingState : public State {
public:
    void Enter() override {
        std::cout << "Entering Attacking State." << std::endl;
        // ��ʼ������״̬�����������Դ
    }

    void Exit() override {
        std::cout << "Exiting Attacking State." << std::endl;
        // �������������������Դ
    }

    void Update() override {
        std::cout << "Updating Attacking State." << std::endl;
        // ���¹����߼�����ִ�й�������
    }

    void HandleMouseInput(const MouseInputEvent& event) override {
        // ������������¼��������Ҫ��
    }

    void HandleKeyboardInput(const KeyboardInputEvent& event) override {
        // ������������¼��������Ҫ��
    }

protected:
    State* CreateState() const override {
        return new AttackingState();
    }

    void RegisterEventListeners() override {
        // ע���¼�������������У�
    }

    void UnregisterEventListeners() override {
        // ȡ���¼�������������У�
    }
};

#endif // AISTATES_H
