#include <iostream>
#include <vector>
#include <memory>

// ����������
class Sprite {
public:
    virtual ~Sprite() = default;
    
    // ���¾���״̬
    virtual void Update() = 0;
    
    // ��Ⱦ����
    virtual void Render() = 0;
};

// ͨ�õľ��������
class SpriteManager {
protected:
    std::vector<std::shared_ptr<Sprite>> sprites;

public:
    virtual ~SpriteManager() = default;

    // ��Ӿ���
    void AddSprite(std::shared_ptr<Sprite> sprite) {
        sprites.push_back(sprite);
    }

    // �������о���
    void UpdateSprites() {
        for (auto& sprite : sprites) {
            sprite->Update();
        }
    }

    // ��Ⱦ���о���
    void RenderSprites() {
        for (auto& sprite : sprites) {
            sprite->Render();
        }
    }
};

// �ӵ���
class Bullet : public Sprite {
public:
    void Update() override {
        std::cout << "Updating Bullet" << std::endl;
    }

    void Render() override {
        std::cout << "Rendering Bullet" << std::endl;
    }
};

// �ӵ�������
class BulletManager : public SpriteManager {
public:
    void AddBullet(std::shared_ptr<Bullet> bullet) {
        AddSprite(bullet);
    }
};

// �����
class Player : public Sprite {
public:
    void Update() override {
        std::cout << "Updating Player" << std::endl;
    }

    void Render() override {
        std::cout << "Rendering Player" << std::endl;
    }
};

// ��ҹ�����
class PlayerManager : public SpriteManager {
public:
    void AddPlayer(std::shared_ptr<Player> player) {
        AddSprite(player);
    }
};

// ������ʾ��
int main() {
    // ����������ʵ��
    BulletManager bulletManager;
    PlayerManager playerManager;
    
    // �����ӵ�����Ҷ���
    auto bullet = std::make_shared<Bullet>();
    auto player = std::make_shared<Player>();
    
    // ���ӵ��������ӵ�������
    bulletManager.AddBullet(bullet);
    playerManager.AddPlayer(player);
    
    // ���º���Ⱦ
    bulletManager.UpdateSprites();
    bulletManager.RenderSprites();
    
    playerManager.UpdateSprites();
    playerManager.RenderSprites();
    
    return 0;
}
