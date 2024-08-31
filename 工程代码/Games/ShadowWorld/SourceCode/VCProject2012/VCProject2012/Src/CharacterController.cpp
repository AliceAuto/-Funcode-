#include "CharacterController.h"
#include "Logger.h"
#include <cmath>
#include "CGameMain.h"
//======================================================
/*
                        CharacterController ���ʵ��
*/
//======================================================





// [˵��]
// ���캯������ʼ����ɫ������
// ��ʼ����ɫ�����������ó�ʼλ�á���Դ�����ƣ��Լ���ʼ�泯���������״̬
// ����:
//   - initialX: ��ɫ�ĳ�ʼ X ����
//   - initialY: ��ɫ�ĳ�ʼ Y ����
//   - resourceBagName: ��Դ��������
//____________________________________________________________________________________________________________
CharacterController::CharacterController(float initialX, float initialY, const std::string& resourceBagName)
    : Entity(initialX, initialY, resourceBagName), facing(Facings::Down), forceX(0), forceY(0) {
    // ������ʼ������
}
//____________________________________________________________________________________________________________




// [˵��]
// Init ��������ʼ����ɫ����������
// �Խ�ɫ���������Խ��г�ʼ�������������������Ծص�
//____________________________________________________________________________________________________________
void CharacterController::Init() {
    this->Entity::Init(); // ���û���ĳ�ʼ������

    // ���ý�ɫ�������������
    auto animateSprite = this->resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
    if (animateSprite) {
        animateSprite->SetSpritePosition(posX, posY);
        animateSprite->SetSpriteMass(100);
        animateSprite->SetSpriteAtRest(false);
        animateSprite->SetSpriteInertialMoment(100);
        animateSprite->SetSpriteAutoMassInertia(true);
        animateSprite->SetSpriteMaxLinearVelocity(20);
        mess = animateSprite->GetSpriteMass();
    } else {
        LogManager::Log("��ʼ��ʧ�ܣ��޷���ȡ CAnimateSprite ��Դ��");
    }
}
//____________________________________________________________________________________________________________




// [˵��]
// breakdown �����������ɫ����������
// �Խ�ɫ���������Խ����������û����������
//____________________________________________________________________________________________________________
void CharacterController::breakdown() {
    Entity::breakdown(); // ���û����������
}
//____________________________________________________________________________________________________________





// [˵��]
// ���������������ɫ������
// �����ɫ����������Դ�������Ҫ��
//____________________________________________________________________________________________________________
CharacterController::~CharacterController() {
    // ������룬�������Ҫ�Ļ�
}
//____________________________________________________________________________________________________________





// [˵��]
// UpdateState ���������½�ɫ״̬
// ���½�ɫ������״̬��λ�ã�����Ħ��������ͷ����ж�
//____________________________________________________________________________________________________________
void CharacterController::UpdateState() {
    LogManager::Log("״̬�Ѹ���");
    auto AnimatePtr = resourceBagPtr->GetResource<CAnimateSprite>("Entity").get();
	LogManager::Log(std::to_string(velocityX));
    if (AnimatePtr) {
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
            frictionForceX = -frictionCoefficient * mess * (velocityX / std::abs(velocityX));
        }
        if (std::abs(velocityY) > velocityThreshold) {
            frictionForceY = -frictionCoefficient * mess * (velocityY / std::abs(velocityY));
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

        // �����ٶ��жϽ�ɫ�泯����
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
//____________________________________________________________________________________________________________




// [˵��]
// UpdateAnimation ���������½�ɫ����
// ���ݽ�ɫ���˶�������½�ɫ�Ķ���״̬
//____________________________________________________________________________________________________________
void CharacterController::UpdateAnimation() {
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
//____________________________________________________________________________________________________________




// [˵��]
// UpdateSound ���������½�ɫ����
// ���ݽ�ɫ���˶�״̬���½�ɫ������Ч��
//____________________________________________________________________________________________________________
void CharacterController::UpdateSound() {
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
//____________________________________________________________________________________________________________





// [˵��]
// ProcessInput ���������������¼�
// ���ݼ��������¼����½�ɫ�������ٶ�
// ����:
//   - event: �����¼�
//____________________________________________________________________________________________________________
void CharacterController::ProcessInput(const Event& event) 
{  
	if (event.GetType() == EventType::KeyboardInput) 
	{
        LogManager::Log("�����¼����ճɹ�,���ڴ���������Ϣ");
        const KeyboardInputEvent& keyEvent = static_cast<const KeyboardInputEvent&>(event);
        LogManager::Log("[����] ��������...");
        if (keyEvent.GetState() == KeyboardInputEvent::KeyState::KEY_ON) {
            switch (keyEvent.GetKey()) {
                case KeyCodes::KEY_W:
                    forceY -= 80000;
                    break;
                case KeyCodes::KEY_S:
                    forceY += 80000;
                    break;
                case KeyCodes::KEY_A:
                    forceX -= 80000;
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
                    forceY += 80000;
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
    } else if (event.GetType() == EventType::MouseInput) 
	{
        const MouseInputEvent& mouseEvent = static_cast<const MouseInputEvent&>(event);
        if (mouseEvent.GetType() == EventType::MouseInput) 
		{
			if(mouseEvent.IsLeftPressed())
			{
				// ����������¼��������ӵ�
				float dx = mouseEvent.GetX() - posX;
				float dy = mouseEvent.GetY() - posY;
				float distance = std::sqrt(dx * dx + dy * dy);
				float direction = std::atan2(dy, dx); // ���㷽�򣨻��ȣ�

				// �����ӵ�
				float bulletSpeed = 200.0f; // ����Ը�����Ҫ�����ӵ����ٶ�
				std::string bulletID = CGameMain::GetInstance().stateMachine->currentState_->objectManager->CreateObject(
					"{\n"
					"  \"TypeName\"      : \"Bullet\",\n"
					"  \"posX\"          : " + std::to_string(posX) + ",\n"
					"  \"posY\"          : " + std::to_string(posY) + ",\n"
					"  \"speed\"         : " + std::to_string(bulletSpeed) + ",\n"
					"  \"direction\"     : " + std::to_string(direction) + ",\n"
					"  \"resourceBag\"   : \"Bullet_1\"\n"
					"}"
				);
				CGameMain::GetInstance().stateMachine->currentState_->objectManager->GetObjectBySpriteName(bulletID)->Init();
				LogManager::Log("�ӵ������ɹ���ID: " + bulletID);
			}
		
		}
	}
}
//____________________________________________________________________________________________________________
