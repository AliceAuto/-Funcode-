#include "DataShower.h"
#include <iostream>

// DataShower ��ʵ��
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
    UI::UpdateState(); // ���û���� UpdateState ����
    UpdateDataDisplay(); // �������ݵ���ʾ
}

void DataShower::UpdateAnimation() {
    UI::UpdateAnimation(); // ���û���� UpdateAnimation ����
    // DataShower ���еĶ��������߼�
}

void DataShower::UpdateSound() {
    UI::UpdateSound(); // ���û���� UpdateSound ����
    // DataShower ���е����������߼�
}

void DataShower::UpdateDataDisplay() {
    if (dataGetter_) {
        // ʾ���������ݻ�ȡ�ӿڣ�ʹ�þ����ֵ
        dataGetter_(); // ���紫��һ���̶���ֵ�����Ը�����Ҫ����+
    }
}










ChatBox::ChatBox(float initialX, float initialY, const std::string& resourceBagName, const std::string& label)
    : DataShower(initialX, initialY, resourceBagName, label) {
    // ע��Ϊ����¼��ļ�����
    
}

ChatBox::~ChatBox() {
    // ע��������
   
}
void ChatBox::Init() {
    DataShower::Init();

}

void ChatBox::breakdown() {
    DataShower::breakdown();

    // ������Դ�߼�
}

void ChatBox::UpdateState() {
    DataShower::UpdateState(); // ���û���� UpdateState ����
    // ChatBox ���е�״̬�����߼�
}

void ChatBox::UpdateAnimation() {
    DataShower::UpdateAnimation(); // ���û���� UpdateAnimation ����
    // ChatBox ���еĶ��������߼�
}

void ChatBox::UpdateSound() {
    DataShower::UpdateSound(); // ���û���� UpdateSound ����
    // ChatBox ���е����������߼�������У�
}













// StatusAnimationUI ��ʵ��
StatusAnimationUI::StatusAnimationUI(float initialX, float initialY, const std::string& resourceBagName, const std::string& label)
    : DataShower(initialX, initialY, resourceBagName, label), currentFrame_(0) {}

StatusAnimationUI::~StatusAnimationUI() {}

void StatusAnimationUI::SetStatus(const std::string& status) {
    status_ = status;
    UpdateStatusDisplay(); // ����״̬��ʾ
}

void StatusAnimationUI::SetAnimationFrames(const std::vector<std::string>& frames) {
    animationFrames_ = frames;
    currentFrame_ = 0; // ���ö���֡����
    UpdateAnimationDisplay(); // ���¶�����ʾ
}

void StatusAnimationUI::UpdateState() {
    DataShower::UpdateState(); // ���û���� UpdateState ����
    // StatusAnimationUI ���е�״̬�����߼�
}

void StatusAnimationUI::UpdateAnimation() {
    DataShower::UpdateAnimation(); // ���û���� UpdateAnimation ����

    if (!animationFrames_.empty()) {
        // �򵥵�ѭ�����Ŷ���
        currentFrame_ = (currentFrame_ + 1) % animationFrames_.size();
        UpdateAnimationDisplay(); // ���¶�����ʾ
    }
}

void StatusAnimationUI::UpdateSound() {
    DataShower::UpdateSound(); // ���û���� UpdateSound ����
    // StatusAnimationUI ���е����������߼�������У�
}

void StatusAnimationUI::UpdateStatusDisplay() {
    std::cout << "Status: " << status_ << std::endl;
}

void StatusAnimationUI::UpdateAnimationDisplay() {
    if (!animationFrames_.empty()) {
        std::cout << "Animation Frame: " << animationFrames_[currentFrame_] << std::endl;
    }
}
