#include <iostream>
#include <string>

// 假设有一个绘制函数
void drawRectangle(int x, int y, int width, int height, const std::string& color);
void drawText(int x, int y, const std::string& text, const std::string& color);

// 状态UI类
class StatusUI {
public:
    StatusUI() : health(100), energy(100), taskProgress(0) {}

    // 更新健康值
    void updateHealth(int newHealth) {
        health = newHealth;
        updateUI();
    }

    // 更新能量值
    void updateEnergy(int newEnergy) {
        energy = newEnergy;
        updateUI();
    }

    // 更新任务进度
    void updateTaskProgress(int newProgress) {
        taskProgress = newProgress;
        updateUI();
    }

    // 绘制UI
    void draw() const {
        // 绘制健康值条
        drawRectangle(10, 10, health, 20, "red");
        drawText(10, 35, "Health: " + std::to_string(health), "white");

        // 绘制能量值条
        drawRectangle(10, 60, energy, 20, "blue");
        drawText(10, 85, "Energy: " + std::to_string(energy), "white");

        // 绘制任务进度条
        drawRectangle(10, 110, taskProgress, 20, "green");
        drawText(10, 135, "Task Progress: " + std::to_string(taskProgress) + "%", "white");
    }

private:
    int health;
    int energy;
    int taskProgress;

    // 更新UI
    void updateUI() {
        draw();
    }
};

int main() {
    StatusUI ui;

    // 模拟数据变化
    ui.updateHealth(75);
    ui.updateEnergy(50);
    ui.updateTaskProgress(30);

    return 0;
}