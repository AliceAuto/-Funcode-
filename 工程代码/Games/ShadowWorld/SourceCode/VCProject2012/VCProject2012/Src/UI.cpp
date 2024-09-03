#include "UI.h"
#include <iostream>

UI::UI(float initialX, float initialY, const std::string& resourceBagName,const std::string& label)
    : Object(initialX, initialY, resourceBagName),label_(label) {
    // ���캯����ʵ�֣�����У�
}

UI::~UI() {
    // ����������ʵ�֣�����ж�������
}

void UI::Init() {
    Object::Init();  // ���û���� Init ����
    // UI ���еĳ�ʼ���߼�
}

void UI::breakdown() {
    Object::breakdown();
}





void UI::UpdateState() {
	Object::UpdateState();
    // ���� UI ״̬��ʵ��
}

void UI::UpdateAnimation(){
	Object::UpdateAnimation();
}
void UI::UpdateSound(){
	Object::UpdateSound();
}