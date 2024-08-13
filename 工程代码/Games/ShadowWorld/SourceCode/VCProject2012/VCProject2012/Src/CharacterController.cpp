#include "CharacterController.h"
#include "Logger.h"

CharacterController::CharacterController(float initialX, float initialY)
    : Entity(initialX, initialY), facing(Facings::Down) {
    // ������ʼ������
}

CharacterController::~CharacterController() {
    // ������룬�������Ҫ�Ļ�
}

void CharacterController::UpdateState() {
    // Ĭ��ʵ�֣����Ա�������д
	LogManager::Log("״̬�Ѹ���");
    CAnimateSprite* AnimatePtr = this ->resourceBagPtr->GetResource<CAnimateSprite>("Character").get();

    if (AnimatePtr) {
        // �ɹ�ת��
    } else {
        // ת��ʧ��
        LogManager::Log("��̬ת��ʧ�ܣ���Դ���ʹ������ԴΪ�ա�");
    }

    if (AnimatePtr != nullptr) {
		
        AnimatePtr->SetSpriteLinearVelocity(velocityX, velocityY);LogManager::Log(std::to_string(AnimatePtr->GetSpriteLinearVelocityX()));
		LogManager::Log(std::to_string(posX)+std::to_string(posY));
        posX = AnimatePtr->GetSpritePositionX();
        posY = AnimatePtr->GetSpritePositionY();

        if (velocityX == 0 && velocityY > 0) {
            facing = Facings::Down;
        } else if (velocityX > 0 && velocityY == 0) {
            facing = Facings::Right;
        } else if (velocityX == 0 && velocityY < 0) {
            facing = Facings::Up;
        } else if (velocityX < 0 && velocityY == 0) {
            facing = Facings::Left;
        }
    } else {
        LogManager::Log("��Դָ��Ϊ�գ�UpdateState");
    }
}

void CharacterController::UpdateAnimation() {
    // Ĭ��ʵ�֣����Ա�������д
	
    CAnimateSprite* AnimatePtr = resourceBagPtr->GetResource<CAnimateSprite>("Character").get();
    static std::string currentAnimation;
    
    if (AnimatePtr == nullptr) return;

    std::string ani;
    if (velocityX == 0 && velocityY > 0) {
        ani = "to_down";
    } else if (velocityX > 0 && velocityY == 0) {
        ani = "to_right";
    } else if (velocityX == 0 && velocityY < 0) {
        ani = "to_up";
    } else if (velocityX < 0 && velocityY == 0) {
        ani = "to_left";
    }

    if (currentAnimation != ani && AnimatePtr != nullptr) {
		LogManager::Log("�����Ѹ���");
        AnimatePtr->AnimateSpritePlayAnimation(ani.c_str(), false);
        currentAnimation = ani;
    } else if (resourceBagPtr != nullptr && AnimatePtr != nullptr && AnimatePtr->IsAnimateSpriteAnimationFinished()) {
		LogManager::Log("�����Ѹ���====");
        AnimatePtr->AnimateSpritePlayAnimation(ani.c_str(), true);
		
    }
}

void CharacterController::UpdateSound() {
    // Ĭ��ʵ�֣����Ա�������д 
	LogManager::Log("�����Ѹ���");
    CSound* SoundPtr = resourceBagPtr->GetResource<CSound>("running").get();
    static std::string currentSound;
 
    if ((velocityX != 0 || velocityY != 0)) {
        if (resourceBagPtr != nullptr && SoundPtr != nullptr && currentSound != SoundPtr->GetName()) {
            SoundPtr->PlaySound();
            currentSound = SoundPtr->GetName();
			
        }
    } else {
        if (currentSound != "") {
            SoundPtr->StopSound();
            currentSound = "";
        }
    }
}

void CharacterController::ProcessInput(const Event& event) {
    if (event.GetType() == EventType::KeyboardInput) {
        LogManager::Log("�����¼����ճɹ�,���ڴ���������Ϣ");
        const KeyboardInputEvent& keyEvent = static_cast<const KeyboardInputEvent&>(event);
        LogManager::Log("[����] ��������...");
        if (keyEvent.GetState() == KeyboardInputEvent::State::KEY_ON) {
            switch (keyEvent.GetKey()) {
                case KeyCodes::KEY_W:
                    velocityY = -10;
                    break;
                case KeyCodes::KEY_S:
                    velocityY = 10;
                    break;
                case KeyCodes::KEY_A:
                    velocityX = -10;
                    break;
                case KeyCodes::KEY_D:
                    velocityX = 10;
                    break;
                default:
                    break;
            }
        } else {
            switch (keyEvent.GetKey()) {
                case KeyCodes::KEY_W:
                case KeyCodes::KEY_S:
                    velocityY = 0;
                    break;
                case KeyCodes::KEY_A:
                case KeyCodes::KEY_D:
                    velocityX = 0;
                    break;
                default:
                    break;
            }
        }
    }
    LogManager::Log("< " + std::to_string(velocityX) + "," + std::to_string(velocityY) + ">");
}
