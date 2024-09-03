#include "DataShower.h"
#include <iostream>

// DataShower 类实现
DataShower::DataShower(float initialX, float initialY, const std::string& resourceBagName, const std::string& label)
    : UI(initialX, initialY, resourceBagName, label), dataGetter_(nullptr) {}

DataShower::~DataShower() {}

void DataShower::SetDataGetter(DataGetterFunc getter) {
    dataGetter_ = getter;
}
void DataShower::Init()
{
	UI::Init();
}
void DataShower::breakdown()
{
	UI::breakdown();
}

void DataShower::UpdateState() {
    UI::UpdateState(); // 调用基类的 UpdateState 方法
    UpdateDataDisplay(); // 更新数据的显示
}

void DataShower::UpdateAnimation() {
    UI::UpdateAnimation(); // 调用基类的 UpdateAnimation 方法
    // DataShower 特有的动画更新逻辑
}

void DataShower::UpdateSound() {
    UI::UpdateSound(); // 调用基类的 UpdateSound 方法
    // DataShower 特有的声音更新逻辑
}

void DataShower::UpdateDataDisplay() {
    if (dataGetter_) {
        // 示例调用数据获取接口，使用具体的值
        dataGetter_(); // 例如传递一个固定的值，可以根据需要调整+
    }
}










ChatBox::ChatBox(float initialX, float initialY, const std::string& resourceBagName, const std::string& label)
    : DataShower(initialX, initialY, resourceBagName, label) {
    // 注册为鼠标事件的监听器
    
}

ChatBox::~ChatBox() {
    // 注销监听器
   
}
void ChatBox::Init() {
    DataShower::Init();

}

void ChatBox::breakdown() {
    DataShower::breakdown();

    // 清理资源逻辑
}

void ChatBox::UpdateState() {
    DataShower::UpdateState(); // 调用基类的 UpdateState 方法
    // ChatBox 特有的状态更新逻辑
}

void ChatBox::UpdateAnimation() {
    DataShower::UpdateAnimation(); // 调用基类的 UpdateAnimation 方法
    // ChatBox 特有的动画更新逻辑
}

void ChatBox::UpdateSound() {
    DataShower::UpdateSound(); // 调用基类的 UpdateSound 方法
    // ChatBox 特有的声音更新逻辑（如果有）
}













// StatusAnimationUI 类实现
StatusAnimationUI::StatusAnimationUI(float initialX, float initialY, const std::string& resourceBagName, const std::string& label)
    : DataShower(initialX, initialY, resourceBagName, label), currentFrame_(0) {}

StatusAnimationUI::~StatusAnimationUI() {}

void StatusAnimationUI::SetStatus(const std::string& status) {
    status_ = status;
    UpdateStatusDisplay(); // 更新状态显示
}

void StatusAnimationUI::SetAnimationFrames(const std::vector<std::string>& frames) {
    animationFrames_ = frames;
    currentFrame_ = 0; // 重置动画帧索引
    UpdateAnimationDisplay(); // 更新动画显示
}

void StatusAnimationUI::UpdateState() {
    DataShower::UpdateState(); // 调用基类的 UpdateState 方法
    // StatusAnimationUI 特有的状态更新逻辑
}

void StatusAnimationUI::UpdateAnimation() {
    DataShower::UpdateAnimation(); // 调用基类的 UpdateAnimation 方法

    if (!animationFrames_.empty()) {
        // 简单地循环播放动画
        currentFrame_ = (currentFrame_ + 1) % animationFrames_.size();
        UpdateAnimationDisplay(); // 更新动画显示
    }
}

void StatusAnimationUI::UpdateSound() {
    DataShower::UpdateSound(); // 调用基类的 UpdateSound 方法
    // StatusAnimationUI 特有的声音更新逻辑（如果有）
}

void StatusAnimationUI::UpdateStatusDisplay() {
    std::cout << "Status: " << status_ << std::endl;
}

void StatusAnimationUI::UpdateAnimationDisplay() {
    if (!animationFrames_.empty()) {
        std::cout << "Animation Frame: " << animationFrames_[currentFrame_] << std::endl;
    }
}
