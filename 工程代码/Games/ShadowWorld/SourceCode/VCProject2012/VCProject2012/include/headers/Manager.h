#include <iostream>
#include <vector>
#include <memory>

// 基础精灵类
class Sprite {
public:
    virtual ~Sprite() = default;
    
    // 更新精灵状态
    virtual void Update() = 0;
    
    // 渲染精灵
    virtual void Render() = 0;
};

// 通用的精灵管理器
class SpriteManager {
protected:
    std::vector<std::shared_ptr<Sprite>> sprites;

public:
    virtual ~SpriteManager() = default;

    // 添加精灵
    void AddSprite(std::shared_ptr<Sprite> sprite) {
        sprites.push_back(sprite);
    }

    // 更新所有精灵
    void UpdateSprites() {
        for (auto& sprite : sprites) {
            sprite->Update();
        }
    }

    // 渲染所有精灵
    void RenderSprites() {
        for (auto& sprite : sprites) {
            sprite->Render();
        }
    }
};

// 子弹类
class Bullet : public Sprite {
public:
    void Update() override {
        std::cout << "Updating Bullet" << std::endl;
    }

    void Render() override {
        std::cout << "Rendering Bullet" << std::endl;
    }
};

// 子弹管理器
class BulletManager : public SpriteManager {
public:
    void AddBullet(std::shared_ptr<Bullet> bullet) {
        AddSprite(bullet);
    }
};

// 玩家类
class Player : public Sprite {
public:
    void Update() override {
        std::cout << "Updating Player" << std::endl;
    }

    void Render() override {
        std::cout << "Rendering Player" << std::endl;
    }
};

// 玩家管理器
class PlayerManager : public SpriteManager {
public:
    void AddPlayer(std::shared_ptr<Player> player) {
        AddSprite(player);
    }
};

// 主函数示例
int main() {
    // 创建管理器实例
    BulletManager bulletManager;
    PlayerManager playerManager;
    
    // 创建子弹和玩家对象
    auto bullet = std::make_shared<Bullet>();
    auto player = std::make_shared<Player>();
    
    // 将子弹和玩家添加到管理器
    bulletManager.AddBullet(bullet);
    playerManager.AddPlayer(player);
    
    // 更新和渲染
    bulletManager.UpdateSprites();
    bulletManager.RenderSprites();
    
    playerManager.UpdateSprites();
    playerManager.RenderSprites();
    
    return 0;
}
