#include "CharacterController.h"
#include "Logger.h"
#include <cmath>
CharacterController::CharacterController(float initialX, float initialY)
    : Entity(initialX, initialY), facing(Facings::Down),forceX(0),forceY(0) {



    // ������ʼ������
}
void CharacterController::Init(const std::string & bag){
	//������������г�ʼ��
	this->resourceBagPtr->LoadFromJson(bag);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpritePosition(posX,posY);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteMass(100);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteAtRest(false);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteInertialMoment(100);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteAutoMassInertia(true);
	this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteMaxLinearVelocity(20);
	mess = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->GetSpriteMass();
}
CharacterController::~CharacterController() {
    // ������룬�������Ҫ�Ļ�
}

void CharacterController::UpdateState() {
    // Ĭ��ʵ�֣����Ա�������д
	LogManager::Log("״̬�Ѹ���");
    CAnimateSprite* AnimatePtr = resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();

    if (AnimatePtr) {

        // �ɹ�ת��
    } else {
        // ת��ʧ��
        LogManager::Log("��̬ת��ʧ�ܣ���Դ���ʹ������ԴΪ�ա�");
    }

    if (AnimatePtr != nullptr) {
		// ��ʼ��Ħ����
       // ��ʼ��Ħ����
    static const float frictionCoefficient = 40; // Ħ��ϵ����������Ҫ����
    static const float velocityThreshold = 1; // �ٶ���ֵ��С�ڴ�ֵ���ٶ���Ϊ��

    // �����ٶ�
    velocityX = AnimatePtr->GetSpriteLinearVelocityX();
    velocityY = AnimatePtr->GetSpriteLinearVelocityY();

    // ����Ħ����
    float frictionForceX = 0;
    float frictionForceY = 0;

    if (std::abs(velocityX) > velocityThreshold) {
        frictionForceX = -frictionCoefficient * mess*(velocityX/std::abs(velocityX));
    }
    if (std::abs(velocityY) > velocityThreshold) {
        frictionForceY = -frictionCoefficient * mess* (velocityY/std::abs(velocityY));
    }

    // ��Ħ����������Ӧ�õ���ɫ��
    AnimatePtr->SetSpriteConstantForce(forceX + frictionForceX, forceY + frictionForceY, false);

    // ����ٶȵ�����ֵ��ֱ�ӽ��ٶ���Ϊ��
    if (std::abs(velocityX) < velocityThreshold) {
        AnimatePtr->SetSpriteLinearVelocityX(0);
    }
    if (std::abs(velocityY) < velocityThreshold) {
        AnimatePtr->SetSpriteLinearVelocityY(0);
    }

    // ����λ��
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
	
    CAnimateSprite* AnimatePtr = resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
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
		LogManager::Log("�����Ѹ���");
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
                    forceY -= 80000;
                    break;
                case KeyCodes::KEY_S:
                    forceY += 80000;
                    break;
                case KeyCodes::KEY_A:
                    forceX -=80000;
                    break;
                case KeyCodes::KEY_D:
                    forceX += 80000;
                    break;
				case KeyCodes::KEY_SPACE:
                    this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteMaxLinearVelocity(200);
                    break;
                default:
                    break;
            }
        } else {
            switch (keyEvent.GetKey()) {
                case KeyCodes::KEY_W:
					forceY +=80000 ;
                    break;
                case KeyCodes::KEY_S:
                    forceY -= 80000;
                    break;
                case KeyCodes::KEY_A:
					forceX += 80000;
                    break;
                case KeyCodes::KEY_D:
                    forceX -= 80000;
                    break;
				case KeyCodes::KEY_SPACE:
                    this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get()->SetSpriteMaxLinearVelocity(20);
                    break;
                default:
                    break;
            }
        }
    }
  
}
