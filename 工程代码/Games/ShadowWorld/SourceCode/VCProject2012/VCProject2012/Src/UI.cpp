#include "UI.h"
#include <iostream>

UI::UI(float initialX, float initialY, const std::string& resourceBagName,const std::string& label)
    : Object(initialX, initialY, resourceBagName),label_(label) {
    // 构造函数的实现（如果有）
}

UI::~UI() {
    // 析构函数的实现（如果有额外清理）
}

void UI::Init() {
    Object::Init();  // 调用基类的 Init 方法
    // UI 特有的初始化逻辑
}

void UI::breakdown() {
    Object::breakdown();
}





void UI::UpdateState() {
	Object::UpdateState();
    // 更新 UI 状态的实现
}

void UI::UpdateAnimation(){
	Object::UpdateAnimation();
}
void UI::UpdateSound(){
	Object::UpdateSound();
}