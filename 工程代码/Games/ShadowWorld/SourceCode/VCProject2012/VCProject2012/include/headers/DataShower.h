#ifndef DataShower_H
#define DataShower_H

#include "UI.h"
#include <vector>
#include <string>
#include "EventDrivenSystem.h"
// DataShower �ඨ��
class DataShower : public UI {
public:
    typedef void (*DataGetterFunc)(); // ���庯��ָ������

    DataShower(float initialX, float initialY, const std::string& resourceBagName, const std::string& label);
    virtual ~DataShower();
	void Init() override;
    void breakdown() override;
    // �������ݻ�ȡ�ӿ�
    void SetDataGetter(DataGetterFunc getter);
protected:
	void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;
private:
    DataGetterFunc dataGetter_; // ���ݻ�ȡ�ӿ�
    void UpdateDataDisplay(); // �������ݵ���ʾ
};











// ChatBox �ඨ��

class ChatBox : public DataShower {
public:
    ChatBox(float initialX, float initialY, const std::string& resourceBagName, const std::string& label);
    virtual ~ChatBox();
	void Init() override;
    void breakdown() override;

protected:
    void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;
};





// StatusAnimationUI �ඨ��
class StatusAnimationUI : public DataShower {
public:
    StatusAnimationUI(float initialX, float initialY, const std::string& resourceBagName, const std::string& label);
    virtual ~StatusAnimationUI();
    // ����״̬��Ϣ
    void SetStatus(const std::string& status);
    // ���ö���֡����
    void SetAnimationFrames(const std::vector<std::string>& frames);
protected:
    void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;

private:
    std::string status_;								// ��ǰ״̬��Ϣ
    std::vector<std::string> animationFrames_;			// ����֡����
    size_t currentFrame_;								// ��ǰ����֡����

    void UpdateStatusDisplay(); // ����״̬��ʾ
    void UpdateAnimationDisplay(); // ���¶�����ʾ
};

#endif // UICOMPONENTS_H
