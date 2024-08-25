#ifndef AI_H
#define AI_H

#include "StateMachine.h"

// 巡逻状态类
class PatrollingState : public State {
public:
    void Enter() override {
        std::cout << "Entering Patrolling State." << std::endl;
        // 初始化巡逻路径或其他相关资源
    }

    void Exit() override {
        std::cout << "Exiting Patrolling State." << std::endl;
        // 清理巡逻路径或其他相关资源
    }

    void Update() override {
        std::cout << "Updating Patrolling State." << std::endl;
        // 更新巡逻逻辑，如移动到下一个巡逻点
    }

    void HandleMouseInput(const MouseInputEvent& event) override {
        // 处理鼠标输入事件（如果需要）
    }

    void HandleKeyboardInput(const KeyboardInputEvent& event) override {
        // 处理键盘输入事件（如果需要）
    }

protected:
    State* CreateState() const override {
        return new PatrollingState();
    }

    void RegisterEventListeners() override {
        // 注册事件监听器（如果有）
    }

    void UnregisterEventListeners() override {
        // 取消事件监听器（如果有）
    }
};



















// 追踪状态类#include "StateMachine.h"
#include "StateMachine.h"
#include <iostream>
#include <vector>
#include <memory>

// 视觉探测子精灵类，用于检测障碍物
class VisualSensor {
public:
    // 检测路径中是否存在障碍物
    bool IsObstacleInPath(const std::vector<std::vector<bool>>& map, const std::pair<int, int>& from, const std::pair<int, int>& to) {
        // 简单实现：线性插值检查障碍物
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


// 追踪状态类
class ChasingState : public State {
public:
    ChasingState() : visualSensor_(new VisualSensor()) {}

    void Enter() override {
        std::cout << "Entering Chasing State." << std::endl;
        // 初始化追踪目标
    }

    void Exit() override {
        std::cout << "Exiting Chasing State." << std::endl;
        // 停止追踪目标
    }

    void Update() override {
        std::cout << "Updating Chasing State." << std::endl;

        if (targetPosition_ == std::make_pair(-1, -1)) {
            std::cout << "No target set, cannot chase." << std::endl;
            return;
        }

        // 获取当前位置
        std::pair<int, int> currentPosition = GetCurrentPosition();

        if (visualSensor_->IsObstacleInPath(map_, currentPosition, targetPosition_)) {
            // 有障碍物，检查脚印
            std::pair<int, int> footprint = FindFootprint();
            if (footprint != std::make_pair(-1, -1)) {
                // 目标有脚印，向脚印移动
                MoveToPosition(footprint);
            } else {
                // 脚印消失，不再追踪
                std::cout << "No visible footprints, stopping chase." << std::endl;
                Exit();
            }
        } else {
            // 无障碍物，直接向目标移动
            MoveToPosition(targetPosition_);
        }

        // 检查是否到达目标
        if (currentPosition == targetPosition_) {
            std::cout << "Reached target!" << std::endl;
            // 切换到攻击状态
            // ToNextState("AttackingState");
        }
    }

    void HandleMouseInput(const MouseInputEvent& event) override {
        // 处理鼠标输入事件（如果需要）
    }

    void HandleKeyboardInput(const KeyboardInputEvent& event) override {
        // 处理键盘输入事件（如果需要）
    }

    void SetTargetPosition(const std::pair<int, int>& targetPosition) {
        targetPosition_ = targetPosition;
    }

    void SetMap(const std::vector<std::vector<bool>>& map) {
        map_ = map;
    }

private:
    VisualSensor* visualSensor_; // 使用裸指针以兼容旧版本的编译器
    std::pair<int, int> targetPosition_; // 目标位置，默认为无效值
    std::vector<std::vector<bool>> map_; // 地图数据

    std::pair<int, int> GetCurrentPosition() {
        // 获取当前 AI 位置
        // 这里返回一个示例位置
        return std::make_pair(0, 0); // 实际实现应从 AI 对象中获取位置
    }

    void MoveToPosition(const std::pair<int, int>& position) {
        // 移动 AI 到指定位置
        std::cout << "Moving to position: (" << position.first << ", " << position.second << ")" << std::endl;
        // 实际移动逻辑
    }

    std::pair<int, int> FindFootprint() {
        // 查找可见脚印
        // 这里简单返回一个示例脚印位置
        return std::make_pair(5, 5); // 实际实现应根据脚印的位置进行查找
    }

    State* CreateState() const override {
        return new ChasingState();
    }

    void RegisterEventListeners() override {
        // 注册事件监听器（如果有）
    }

    void UnregisterEventListeners() override {
        // 取消事件监听器（如果有）
    }
};





















// 攻击状态类
class AttackingState : public State {
public:
    void Enter() override {
        std::cout << "Entering Attacking State." << std::endl;
        // 初始化攻击状态或其他相关资源
    }

    void Exit() override {
        std::cout << "Exiting Attacking State." << std::endl;
        // 结束攻击或清理相关资源
    }

    void Update() override {
        std::cout << "Updating Attacking State." << std::endl;
        // 更新攻击逻辑，如执行攻击动作
    }

    void HandleMouseInput(const MouseInputEvent& event) override {
        // 处理鼠标输入事件（如果需要）
    }

    void HandleKeyboardInput(const KeyboardInputEvent& event) override {
        // 处理键盘输入事件（如果需要）
    }

protected:
    State* CreateState() const override {
        return new AttackingState();
    }

    void RegisterEventListeners() override {
        // 注册事件监听器（如果有）
    }

    void UnregisterEventListeners() override {
        // 取消事件监听器（如果有）
    }
};

#endif // AISTATES_H
