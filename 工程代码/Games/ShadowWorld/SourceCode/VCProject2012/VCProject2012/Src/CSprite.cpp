#include "headers\CSprite.h"
#include "headers\EventDrivenSystem.h" // �õ��¼���

//=====================================================
/*
					����������ʵ��
*/
//=====================================================





















//��ť
//====================================================
#include <unordered_map>
#include <queue>       


// ��ť�๹�캯��
Button::Button(const char* szName)
    : CAnimateSprite(szName), state(Normal), prevState(Normal), textSprite(nullptr) {
    // ��ʼ�����־���
    textSprite = new CTextSprite(szName);
}

// ��ť����������
Button::~Button() {
    // �ͷ��¼������е��¼�
    while (!eventQueue.empty()) {
        delete eventQueue.front();
        eventQueue.pop();
    }

    // �ͷ�������Դ
    for (auto& pair : sounds) {
        delete pair.second; // ɾ��CSound����
    }

    // ɾ�����־���
    delete textSprite;
}

// �����¼�
void Button::HandleEvent(const Event& event) {
    // ���¼���ӵ��¼�����
    eventQueue.push(new MouseInputEvent(static_cast<const MouseInputEvent&>(event)));
}

// ���°�ť״̬
void Button::Update() {
    while (!eventQueue.empty()) {
        const Event* event = eventQueue.front();
        eventQueue.pop();
        UpdateState(*event); // ����״̬
    }
    PlayAnimation(); // ���Ŷ���
}

// ���°�ť״̬
void Button::UpdateState(const Event& event) {
    if (auto mouseInputEvent = dynamic_cast<const MouseInputEvent*>(&event)) {
        bool isHovering = CSprite::IsPointInSprite(mouseInputEvent->GetX(), mouseInputEvent->GetY());
        ButtonState newState = state;

        if (isHovering) {
            if (mouseInputEvent->IsLeftPressed()) {
                newState = Clicked;
            } else {
                newState = Hover;
            }
        } else {
            newState = Normal;
        }

        if (newState != state) {
            SetState(newState);
            if (sounds.find(state) != sounds.end()) {
                sounds[state]->PlaySound(); // ������Ч
            }
        }
    }
}

// ���Ű�ť����
void Button::PlayAnimation() {
    auto it = animNames.find(state);
    if (it != animNames.end()) {
        AnimateSpritePlayAnimation(it->second.c_str(), true);
    }
}

// ���ð�ť״̬
void Button::SetState(ButtonState newState) {
    prevState = state;
    state = newState;
}

// �󶨶���
void Button::BindAnimation(ButtonState state, const char* animName) {
    animNames[state] = animName;
}

// ����Ч
void Button::BindSound(ButtonState state, const char* soundName, bool loop, float volume) {
    // ����һ��CSound���󲢴洢��soundsӳ����
    sounds[state] = new CSound(soundName, loop, volume);
}

// ���ð�ť�ϵ�����
void Button::SetText(const char* text) {
    if (textSprite) {
        textSprite->SetTextString(text);
    }
}

// ���ð�ť�ϵ���ֵ����
void Button::SetTextValue(int value) {
    if (textSprite) {
        textSprite->SetTextValue(value);
    }
}

// ��ȡ��ť��ǰ״̬
Button::ButtonState Button::GetState() const {
    return state;
}

// ��Ⱦ��ť����������
void Button::Render() {
    // ��Ⱦ��ť����
    PlayAnimation();

    // ��Ⱦ��ť�ϵ�����
    if (textSprite) {
       // textSprite->Render();
    }
}


//====================================================