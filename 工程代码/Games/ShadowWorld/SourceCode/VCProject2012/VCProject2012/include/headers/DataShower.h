#ifndef DataShower_H
#define DataShower_H

#include "UI.h"
#include <vector>
#include <string>
#include "EventDrivenSystem.h"
// DataShower 类定义
class DataShower : public UI {
public:
    typedef void (*DataGetterFunc)(); // 定义函数指针类型

    DataShower(float initialX, float initialY, const std::string& resourceBagName, const std::string& label);
    virtual ~DataShower();
	void Init() override;
    void breakdown() override;
    // 设置数据获取接口
    void SetDataGetter(DataGetterFunc getter);
protected:
	void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;
private:
    DataGetterFunc dataGetter_; // 数据获取接口
    void UpdateDataDisplay(); // 更新数据的显示
};











// ChatBox 类定义

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





// StatusAnimationUI 类定义
class StatusAnimationUI : public DataShower {
public:
    StatusAnimationUI(float initialX, float initialY, const std::string& resourceBagName, const std::string& label);
    virtual ~StatusAnimationUI();
    // 设置状态信息
    void SetStatus(const std::string& status);
    // 设置动画帧数据
    void SetAnimationFrames(const std::vector<std::string>& frames);
protected:
    void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;

private:
    std::string status_;								// 当前状态信息
    std::vector<std::string> animationFrames_;			// 动画帧数据
    size_t currentFrame_;								// 当前动画帧索引

    void UpdateStatusDisplay(); // 更新状态显示
    void UpdateAnimationDisplay(); // 更新动画显示
};

#endif // UICOMPONENTS_H
