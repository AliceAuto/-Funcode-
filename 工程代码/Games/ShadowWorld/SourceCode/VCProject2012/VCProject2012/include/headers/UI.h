#include <iostream>
#include <string>

// ������һ�����ƺ���
void drawRectangle(int x, int y, int width, int height, const std::string& color);
void drawText(int x, int y, const std::string& text, const std::string& color);

// ״̬UI��
class StatusUI {
public:
    StatusUI() : health(100), energy(100), taskProgress(0) {}

    // ���½���ֵ
    void updateHealth(int newHealth) {
        health = newHealth;
        updateUI();
    }

    // ��������ֵ
    void updateEnergy(int newEnergy) {
        energy = newEnergy;
        updateUI();
    }

    // �����������
    void updateTaskProgress(int newProgress) {
        taskProgress = newProgress;
        updateUI();
    }

    // ����UI
    void draw() const {
        // ���ƽ���ֵ��
        drawRectangle(10, 10, health, 20, "red");
        drawText(10, 35, "Health: " + std::to_string(health), "white");

        // ��������ֵ��
        drawRectangle(10, 60, energy, 20, "blue");
        drawText(10, 85, "Energy: " + std::to_string(energy), "white");

        // �������������
        drawRectangle(10, 110, taskProgress, 20, "green");
        drawText(10, 135, "Task Progress: " + std::to_string(taskProgress) + "%", "white");
    }

private:
    int health;
    int energy;
    int taskProgress;

    // ����UI
    void updateUI() {
        draw();
    }
};

int main() {
    StatusUI ui;

    // ģ�����ݱ仯
    ui.updateHealth(75);
    ui.updateEnergy(50);
    ui.updateTaskProgress(30);

    return 0;
}