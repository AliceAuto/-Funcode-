# StateMachine \ State 开发文档

## 1. 项目概述

本项目实现了一个基于状态机的应用系统，用于管理和切换不同的状态，如主菜单、游戏、设置菜单等。状态机负责处理状态之间的切换及状态的更新逻辑。

---

## 2. 状态机 (StateMachine)

### 2.1 功能概述

- **添加状态**  
  将新的状态添加到状态机中，便于后续切换和管理。

- **状态切换**  
  切换到指定的状态，执行相应的进入和退出操作。

- **设置当前状态**  
  明确设置当前状态，通常用于初始化或状态切换时。

- **获取当前状态名称**  
  查询当前状态的名称。

- **获取状态对象**  
  根据状态名称获取对应的状态对象。

- **更新状态机**  
  更新当前状态的逻辑，根据时间增量进行处理。

---

## 3. 状态接口 (State)

### 3.1 功能接口

- **`update(float fDeltaTime)`**  
  更新状态的逻辑。`fDeltaTime` 表示时间增量。

- **`enter()`**  
  进入状态时调用的方法。在状态切换到当前状态时执行。

- **`exit()`**  
  退出状态时调用的方法。在状态从当前状态切换出去时执行。

### 3.2 事件处理

- **`RegisterEventListeners()`**  
  注册事件监听器，用于处理状态相关的事件（如按钮点击）。

- **`UnregisterEventListeners()`**  
  注销事件监听器，取消之前注册的事件监听，避免内存泄漏或无效事件处理。

### 3.3 工厂方法

- **`CreateState()`**  
  工厂方法，用于创建状态实例。每个具体状态类需实现此方法以返回其实例。

---

## 4. 状态实现说明

### 4.1 主菜单状态 (MainMenuState)

- **功能**  
  管理主菜单界面显示和按钮交互，处理用户点击按钮的事件，切换到相应的状态（如游戏状态）。

### 4.2 游戏状态 (GameState)

- **功能**  
  管理游戏的主要逻辑，包括加载游戏场景和处理游戏内的实体，负责游戏的初始化、更新和清理工作。

### 4.3 设置菜单状态 (SettingsMenuState)

- **功能**  
  管理设置菜单的显示和用户设置操作，加载设置场景及处理设置选项的更新。

### 4.4 暂停菜单状态 (PauseMenuState)

- **功能**  
  管理游戏暂停时的菜单，包括显示暂停菜单和处理用户的暂停操作。

### 4.5 退出菜单状态 (ExitMenuState)

- **功能**  
  处理游戏退出逻辑，包括退出游戏的操作和资源清理。

### 4.6 高分状态 (HighScoreState)

- **功能**  
  显示游戏高分记录，处理相关的界面展示和用户操作。

---
# Entity \ EntityManager 开发文档

## 5. 创建新状态

### 5.1 定义新状态

1. **声明新状态**  
   在状态头文件中声明新状态类，继承自 `State` 类。

2. **实现新状态**  
   在状态实现文件中实现新状态类的 `Enter`, `Exit`, `Update` 和 `CreateState` 方法。

3. **添加到状态机**  
   在主程序中创建状态机对象，并使用 `AddState` 方法将新状态添加到状态机中。

### 5.2 状态添加和切换

- **添加新状态**  
  使用状态机的 `AddState` 方法将新状态添加到状态机。

- **切换状态**  
  使用 `ToNextState` 方法进行状态切换，进入新状态并执行相应的进入和退出操作。

---

## 6. 总结

本系统通过实现状态机和状态类，提供了一种高效的状态管理机制。通过定义状态和实现状态机，能够灵活地管理应用中的不同状态，实现状态间的平滑切换和更新。

---




## 1. 项目概述

本项目实现了 `Entity` 和 `EntityManager` 模块，用于处理游戏中的实体及其管理。`Entity` 类定义了游戏实体的基本属性和行为，而 `EntityManager` 类负责管理这些实体的生命周期和状态。

---

## 2. `Entity ` 类

### 2.1 功能概述

- **实体基本功能**  
  定义实体的基本属性，如位置、速度、资源包等，并提供更新、初始化和清理等基本操作。

- **资源包管理**  
  通过 `ResourceBag` 管理和加载实体的资源。

- **碰撞处理**  
  提供与其他实体碰撞的处理接口。

### 2.2 公共接口

- **`Update()`**  
更新实体的状态、动画和声音。

- **`Init()`**  
  初始化实体，加载资源包并设置实体的精灵位置。

- **`breakdown()`**  
  清理实体资源，释放资源包实例。

- **`GetPosX()`**  
  获取实体的 X 坐标。

- **`GetPosY()`**  
  获取实体的 Y 坐标。

- **`GetVelocityX()`**  
  获取实体的 X 方向速度。

- **`GetVelocityY()`**  
  获取实体的 Y 方向速度.

- **`SetPosition(float x, float y)`**  
  设置实体的位置。

- **`SetVelocity(float vx, float vy)`**  
  设置实体的速度。

- **`ifCollision(Entity* otherEntity)`**  
  处理与其他实体的碰撞事件。

### 2.3 保护成员

- **`UpdateState()`**  
  需要子类实现的方法，用于更新实体的状态。

- **`UpdateAnimation()`**  
  需要子类实现的方法，用于更新实体的动画。

- **`UpdateSound()`**  
  需要子类实现的方法，用于更新实体的声音。

---

## 3. `EntityManager` 类

### 3.1 功能概述

- **实体管理**  
  负责创建、获取、删除和更新游戏中的实体。

- **实体加载和清理**  
  提供加载所有实体和清理所有实体资源的功能。

### 3.2 公共接口

- **`CreateEntity(const std::string& jsonString)`**  
  创建新的实体实例，并返回其唯一标识符。实体信息从 JSON 字符串中读取。

- **`GetEntity(const std::string& id)`**  
  根据 ID 获取指定的实体。

- **`GetEntityBySpriteName(const std::string& spriteName)`**  
  根据精灵名称获取实体。

- **`DeleteEntity(const std::string& id)`**  
  删除指定 ID 的实体。

- **`Update()`**  
  更新所有实体，包括状态和渲染。

- **`LoadAllEntitys()`**  
  加载所有实体的资源。

- **`breakDownAllEntitys()`**  
  分解所有实体的资源。

### 3.3 私有方法

- **`CreateEntityInstance(const std::string& type, Json::Value root)`**  
  根据控制器类型创建新的实体实例。

---

## 4. 实现说明

### 4.1 `Entity` 类实现

- **构造函数**  
  初始化实体的位置、速度和资源包名称。

- **析构函数**  
  清理实体的资源包指针。

- **`Init()`**  
  加载资源包，并设置实体的精灵位置。

- **`breakdown()`**  
  释放资源包实例。

- **`Update()`**  
  更新实体的状态、动画和声音。

- **`ifCollision(Entity* otherEntity)`**  
  处理与其他实体的碰撞事件。

### 4.2 `EntityManager` 类实现

- **构造函数**  
  初始化实体管理器。

- **析构函数**  
  释放所有实体的资源。

- **`CreateEntity(const std::string& jsonString)`**  
  根据 JSON 字符串创建新的实体。

- **`CreateEntityInstance(const std::string& type, Json::Value root)`**  
  根据实体类型创建新的实体实例。

- **`GetEntity(const std::string& id)`**  
  获取指定 ID 的实体。

- **`GetEntityBySpriteName(const std::string& spriteName)`**  
  根据精灵名称获取实体。

- **`DeleteEntity(const std::string& id)`**  
  删除指定 ID 的实体。

- **`LoadAllEntitys()`**  
  加载所有实体的资源。

- **`breakDownAllEntitys()`**  
  分解所有实体的资源。

- **`Update()`**  
  更新所有实体。

---

## 5. 总结

`Entity` 类和 `EntityManager` 类为游戏系统提供了强大的实体管理功能。`Entity` 负责定义和操作单个实体的属性和行为，而 `EntityManager` 则负责管理所有实体的生命周期，包括创建、获取、更新和删除实体。

---
# Button 类开发文档

## 1. 项目概述

`Button` 类是一个继承自 `Entity` 的组件，用于处理用户界面中的按钮元素。它集成了鼠标事件处理、动画更新、声音播放等功能，支持按钮的点击、悬停和鼠标离开事件。

## 2. 类概述

### 2.1 类名

`Button`

### 2.2 继承关系

- 继承自：`Entity`

### 2.3 功能描述

- **鼠标事件处理**：响应鼠标点击、悬停和离开事件。
- **动画更新**：根据按钮的状态（点击、悬停等）更新按钮的动画。
- **声音播放**：在按钮点击时播放声音。
- **事件分发**：将按钮点击事件分发到事件管理器中。

---

## 3. 成员函数

### 3.1 构造函数与析构函数

- **`Button(float initialX, float initialY, const std::string& resourceBagName, const std::string& label)`**  
  构造函数，用于初始化按钮对象。参数包括初始位置、资源包名称和按钮标签。

- **`~Button()`**  
  析构函数，用于清理按钮对象。在析构时注销鼠标监听器。

### 3.2 方法

- **`void Init()`**  
  初始化按钮对象，调用父类 `Entity` 的初始化方法，并注册鼠标监听器。

- **`void breakdown()`**  
  清理按钮对象，调用父类 `Entity` 的清理方法，并注销鼠标监听器。

- **`void HandleMouseEvent(const MouseInputEvent& event)`**  
  处理鼠标输入事件。根据鼠标事件（点击、悬停、离开）更新按钮的状态，并执行相应的动画和声音播放。

- **`void UpdateAnimation()`**  
  更新按钮的动画状态。根据按钮的状态（点击、悬停、正常）播放相应的动画。

- **`void UpdateSound()`**  
  播放按钮点击声音。如果按钮被点击且声音资源存在，则播放声音。

- **`void RegisterMouseListener()`**  
  注册鼠标事件监听器，用于接收和处理鼠标输入事件。

- **`void UnregisterMouseListener()`**  
  注销鼠标事件监听器，停止接收鼠标输入事件。

### 3.3 获取器

- **`const std::string& GetLabel() const`**  
  获取按钮的标签。

---

## 4. 事件处理

### 4.1 鼠标事件

- **点击事件**：当鼠标左键按下且鼠标在按钮区域内时，触发点击事件。按钮动画切换到“点击”状态，声音播放，按钮点击事件被分发。
- **悬停事件**：当鼠标进入按钮区域时，按钮动画切换到“悬停”状态。
- **离开事件**：当鼠标离开按钮区域时，按钮动画切换到“正常”状态。

---

## 5. 使用示例

```cpp
// 创建一个按钮对象
	//在主菜单状态添加一个"无文本绑定"、"位置为(0,0)"、"资源包为<Button_Text&Render>"、"标签为<StartGame>"的按钮
    std::string Button0 = objectManager->CreateObject(
        "{\n"
        "  \"TypeName\"      :           \"Button_Text&Photo\"                ,\n"
        "  \"posX\"          :           0.0                      ,\n"
        "  \"posY\"          :           0.0                      ,\n"
        "  \"resourceBag\"   :           \"Button_Text&Render\"       ,\n"
        "  \"label\"         :           \"StartGame\"              \n"
        "}"
    );
	static_cast<Button*>(objectManager->GetObjectBySpriteName(Button0))->SetClickHandler
		([this]() 
	{
            CGameMain::GetInstance().stateMachine->ToNextState("Game");//为按钮设置处理逻辑,这个意思是会调用这个函数 切换状态 
	}
		);


```
# CharacterController 类开发文档

## 1. 项目概述

`CharacterController` 类是一个继承自 `Entity` 的类，用于控制游戏中的角色。它负责处理角色的物理属性、动画状态、声音效果以及用户输入。这个类允许通过键盘和鼠标事件来控制角色的移动和行为。

## 2. 类概述

### 2.1 类名

`CharacterController`

### 2.2 继承关系

- 继承自：`Entity`

### 2.3 功能描述

- **输入处理**：响应键盘和鼠标事件，控制角色的移动和其他行为。
- **状态更新**：根据物理属性和用户输入更新角色的状态。
- **动画更新**：根据角色的运动方向更新角色的动画状态。
- **声音更新**：根据角色的运动状态更新声音效果。

---

## 3. 成员函数

### 3.1 构造函数与析构函数

- **`CharacterController(float initialX, float initialY, const std::string& resourceBagName)`**  
  构造函数，用于初始化角色控制器。参数包括初始位置和资源包名称。

- **`~CharacterController()`**  
  虚析构函数，用于清理角色控制器的资源（如果需要）。

### 3.2 方法

- **`void Init()`**  
  初始化角色的物理属性，设置角色动画精灵的属性，如质量、惯性矩等，并处理其他初始化操作。

- **`void breakdown()`**  
  清理角色的物理属性，调用基类的清理函数。

- **`void UpdateState()`**  
  更新角色的物理状态和位置，包括摩擦力计算和方向判断。根据角色的速度更新摩擦力和方向。

- **`void UpdateAnimation()`**  
  更新角色的动画状态。根据角色的运动方向播放相应的动画。

- **`void UpdateSound()`**  
  更新角色的声音效果。根据角色的运动状态播放或停止声音。

- **`void ProcessInput(const Event& event)`**  
  处理输入事件。根据键盘和鼠标输入更新角色的力和速度，处理鼠标点击事件发射子弹。

### 3.3 属性

- **`float forceX`**  
  角色在 X 方向上的外力。

- **`float forceY`**  
  角色在 Y 方向上的外力。

- **`float mess`**  
  角色的质量。

- **`enum Facings { Up, Down, Left, Right }`**  
  角色的面朝方向。

- **`Facings facing`**  
  当前角色的面朝方向。

---

## 4. 事件处理

### 4.1 键盘事件

- **按下 W 键**：向上施加力。
- **按下 S 键**：向下施加力。
- **按下 A 键**：向左施加力。
- **按下 D 键**：向右施加力。
- **按下 空格键**：设置角色的最大线速度（加速）。

- **释放 W 键**：取消向上施加的力。
- **释放 S 键**：取消向下施加的力。
- **释放 A 键**：取消向左施加的力。
- **释放 D 键**：取消向右施加的力。
- **释放 空格键**：恢复角色的最大线速度。

### 4.2 鼠标事件

- **鼠标左键按下**：计算从角色到鼠标点击位置的方向和距离，并发射子弹。

---

## 5. 使用示例

```cpp
// 创建角色控制器对象
CharacterController character(100.0f, 200.0f, "ResourceBagName");

// 初始化角色控制器
character.Init();

// 处理输入事件（通常在主循环中）
void OnEvent(const Event& event) {
    character.ProcessInput(event);
}

// 更新角色状态、动画和声音
void Update() {
    character.UpdateState();
    character.UpdateAnimation();
    character.UpdateSound();
}

// 清理角色控制器
character.breakdown();
```
# MonsterController 类开发文档

## 1. 项目概述

`MonsterController` 类是一个继承自 `CharacterController` 的类，用于控制游戏中的NPC（非玩家角色）或智能物体。它继承了 `CharacterController` 的基本功能，并可根据需要进行扩展。

## 2. 类概述

### 2.1 类名

`MonsterController`

### 2.2 继承关系

- 继承自：`CharacterController`

### 2.3 功能描述

- **初始化**：初始化 NPC 控制器的资源和状态。
- **清理资源**：销毁 NPC 控制器实例，清理资源。
- **状态更新**：每帧更新 NPC 的行为和状态（待实现）。

---

## 3. 成员函数

### 3.1 构造函数与析构函数

- **`MonsterController(float initialX, float initialY, const std::string& resourceBagName)`**  
  构造函数，初始化 `MonsterController` 实例。参数包括初始位置和资源包名称。继承自 `CharacterController` 的构造函数。

- **`~MonsterController()`**  
  虚析构函数，销毁 `MonsterController` 实例，并清理资源。

### 3.2 方法

- **`void Init()`**  
  初始化 `MonsterController` 实例，调用基类 `CharacterController` 的 `Init()` 函数以加载资源和初始化状态。

- **`void breakdown()`**  
  清理 `MonsterController` 实例，调用基类 `CharacterController` 的 `breakdown()` 函数以清理资源。

- **`void Update()`**  
  更新 `MonsterController` 的状态。每帧调用该函数以更新 NPC 的行为和状态（当前未实现，需要子类扩展）。

---

## 4. 使用示例

```cpp
// 创建 MonsterController 对象
MonsterController npc(100.0f, 200.0f, "ResourceBagName");

// 初始化 NPC 控制器
npc.Init();

// 更新 NPC 状态（通常在主循环中）
void Update() {
    npc.Update();
}

// 清理 NPC 控制器
npc.breakdown();
```
# NonInteractiveObject 类及其派生类开发文档

## 1. 项目概述

`NonInteractiveObject` 类及其派生类（`PhysicalObject`、`ObstacleObject` 和 `Bullet`）用于表示游戏中的非交互对象。这些对象包括物理性实体、障碍物和子弹，它们在游戏中不与玩家交互，但具有特定的行为和状态更新逻辑。

## 2. 类概述

### 2.1 NonInteractiveObject

#### 功能描述
- 基类，表示不与玩家交互的游戏对象。
- 提供默认的状态更新、动画更新和声音更新方法。

#### 成员函数
- **`NonInteractiveObject(float initialX, float initialY, const std::string& resourceBagName)`**  
  构造函数，初始化对象的初始位置和资源包名称。

- **`virtual ~NonInteractiveObject()`**  
  虚析构函数，清理对象的资源。

- **`void Init() override`**  
  初始化对象，调用基类 `Entity` 的初始化函数。

- **`void breakdown() override`**  
  清理对象，调用基类 `Entity` 的资源清理函数。

- **`virtual void UpdateState() override`**  
  更新对象的状态，提供默认实现。

- **`virtual void UpdateAnimation() override`**  
  更新对象的动画，提供默认实现。

- **`virtual void UpdateSound() override`**  
  更新对象的声音，提供默认实现。

### 2.2 PhysicalObject

#### 功能描述
- 表示一个具有物理属性的游戏对象，如速度和位置更新。

#### 成员函数
- **`PhysicalObject(float initialX, float initialY, const std::string& resourceBagName)`**  
  构造函数，初始化物理对象及其速度属性。

- **`virtual ~PhysicalObject()`**  
  虚析构函数，清理物理对象的资源。

- **`void Init() override`**  
  初始化物理对象，调用基类 `NonInteractiveObject` 的初始化函数。

- **`void breakdown() override`**  
  清理物理对象，调用基类 `NonInteractiveObject` 的资源清理函数。

- **`void UpdateState() override`**  
  更新物理对象的状态，包括应用物理运算。

- **`void UpdateAnimation() override`**  
  更新物理对象的动画，基于物理状态。

- **`void UpdateSound() override`**  
  更新物理对象的声音，基于物理状态。

- **`void ApplyPhysics()`**  
  应用物理运算，更新位置基于速度属性。

### 2.3 ObstacleObject

#### 功能描述
- 表示一个障碍物对象，其位置通常不变。

#### 成员函数
- **`ObstacleObject(float initialX, float initialY, const std::string& resourceBagName)`**  
  构造函数，初始化障碍物对象。

- **`virtual ~ObstacleObject()`**  
  虚析构函数，清理障碍物的资源。

- **`void Init() override`**  
  初始化障碍物，调用基类 `NonInteractiveObject` 的初始化函数。

- **`void breakdown() override`**  
  清理障碍物，调用基类 `NonInteractiveObject` 的资源清理函数。

- **`void UpdateState() override`**  
  更新障碍物状态，位置不变，因此无需更新位置。

### 2.4 Bullet

#### 功能描述
- 表示一个子弹对象，具有速度和方向属性。

#### 成员函数
- **`Bullet(float initialX, float initialY, const std::string& resourceBagName, float speed, float direction)`**  
  构造函数，初始化子弹对象，包括速度和方向。

- **`virtual ~Bullet()`**  
  虚析构函数，清理子弹的资源。

- **`void Init() override`**  
  初始化子弹，设置速度和方向，并更新资源包中的动画速度。

- **`void breakdown() override`**  
  清理子弹，调用基类 `NonInteractiveObject` 的资源清理函数。

- **`void UpdateState() override`**  
  更新子弹的状态，处理子弹的移动。

- **`void UpdateAnimation() override`**  
  更新子弹的动画，基于子弹状态。

- **`void UpdateSound() override`**  
  更新子弹的声音，基于子弹状态。

## 3. 使用示例

```cpp
// 创建一个物理对象
PhysicalObject physicalObj(100.0f, 200.0f, "PhysicsResourceBag");
physicalObj.Init();
physicalObj.UpdateState();
physicalObj.UpdateAnimation();
physicalObj.UpdateSound();
physicalObj.breakdown();

// 创建一个障碍物对象
ObstacleObject obstacle(150.0f, 250.0f, "ObstacleResourceBag");
obstacle.Init();
obstacle.UpdateState();
obstacle.breakdown();

// 创建一个子弹对象
Bullet bullet(200.0f, 300.0f, "BulletResourceBag", 10.0f, 0.5f);
bullet.Init();
bullet.UpdateState();
bullet.UpdateAnimation();
bullet.UpdateSound();
bullet.breakdown();
```
# 事件驱动系统开发文档

## 1. 项目概述

事件驱动系统用于处理和管理游戏中的各种事件，如用户输入、按钮点击和碰撞等。系统基于观察者模式，通过事件类型和监听器来实现事件的分发和处理。

## 2. 类概述

### 2.1 EventType 枚举

**功能描述**  
定义了支持的事件类型。

**成员**
- `MouseInput` - 鼠标输入事件
- `KeyboardInput` - 键盘输入事件
- `ButtonClick` - 按钮点击事件
- `Collision` - 碰撞事件

### 2.2 Event 基类

**功能描述**  
所有事件类型的基类，提供事件类型的接口。

**成员函数**
- **`virtual ~Event()`**  
  虚析构函数，确保派生类可以正确析构。

- **`virtual EventType GetType() const = 0`**  
  纯虚函数，返回事件类型。

### 2.3 MouseInputEvent 类

**功能描述**  
表示鼠标输入事件，包括位置和按键状态。

**成员函数**
- **`MouseInputEvent(float x, float y, bool isLeftPressed, bool isMiddlePressed, bool isRightPressed)`**  
  构造函数，初始化鼠标位置和按键状态。

- **`EventType GetType() const override`**  
  返回事件类型 `MouseInput`。

- **`float GetX() const`**  
  获取鼠标X坐标。

- **`float GetY() const`**  
  获取鼠标Y坐标。

- **`bool IsLeftPressed() const`**  
  判断左键是否按下。

- **`bool IsMiddlePressed() const`**  
  判断中键是否按下。

- **`bool IsRightPressed() const`**  
  判断右键是否按下。

### 2.4 KeyboardInputEvent 类

**功能描述**  
表示键盘输入事件，包括按键和状态。

**成员函数**
- **`KeyboardInputEvent(int key, KeyState state)`**  
  构造函数，初始化按键和状态。

- **`EventType GetType() const override`**  
  返回事件类型 `KeyboardInput`。

- **`int GetKey() const`**  
  获取按键值。

- **`KeyState GetState() const`**  
  获取按键状态（`KEY_ON` 或 `KEY_OFF`）。

### 2.5 CollisionEvent 类

**功能描述**  
表示碰撞事件，包含两个碰撞体的名称。

**成员函数**
- **`CollisionEvent(const std::string& A, const std::string& B)`**  
  构造函数，初始化碰撞体A和B的名称。

- **`EventType GetType() const override`**  
  返回事件类型 `Collision`。

- **`const std::string& GetA() const`**  
  获取碰撞体A的名称。

- **`const std::string& GetB() const`**  
  获取碰撞体B的名称。

### 2.6 ButtonClickEvent 类

**功能描述**  
表示按钮点击事件，包含发送者的信息。

**成员函数**
- **`ButtonClickEvent(const std::string& sender)`**  
  构造函数，初始化按钮发送者的信息。

- **`EventType GetType() const override`**  
  返回事件类型 `ButtonClick`。

- **`std::string GetButtonSender() const`**  
  获取按钮发送者的信息。

### 2.7 EventManager 类

**功能描述**  
管理事件的注册、移除和分发。

**成员函数**
- **`static EventManager& Instance()`**  
  获取事件管理器的单例实例。

- **`void RegisterListener(EventType type, const std::string& listenerID, EventListener listener)`**  
  注册事件监听器。

- **`void RemoveListener(EventType type, const std::string& listenerID)`**  
  移除事件监听器。

- **`void DispatchEvent(const Event& event)`**  
  分发事件给所有注册的监听器。

- **`void ClearListeners()`**  
  清理所有监听器。

**私有成员**
- **`std::unordered_map<EventType, std::vector<std::pair<std::string, EventListener>>> listeners`**  
  存储事件类型及其对应的监听器列表。

**使用示例**

```cpp
// 注册一个事件监听器
EventManager::Instance().RegisterListener(MouseInput, "MouseListener", [](const Event& e) {
    const MouseInputEvent& mouseEvent = static_cast<const MouseInputEvent&>(e);
    // 处理鼠标输入事件
});

// 分发一个鼠标输入事件
MouseInputEvent mouseEvent(100.0f, 200.0f, true, false, false);
EventManager::Instance().DispatchEvent(mouseEvent);

// 移除事件监听器
EventManager::Instance().RemoveListener(MouseInput, "MouseListener");
```
# ResourceBag 开发文档

## 1. 项目概述

`ResourceBag` 类负责管理和加载游戏资源。它支持从 JSON 文件中加载不同类型的资源，并提供方法来添加和获取这些资源。

## 2. 类概述

### 2.1 ResourceBag 类

**功能描述**  
`ResourceBag` 类用于存储和管理游戏资源，包括精灵、音效、特效等。资源通过名称进行存取，并能够从 JSON 文件中加载资源信息。

**成员函数**

- **`ResourceBag(const std::string & Entity_ID)`**  
  构造函数，初始化 `ResourceBag` 实例。`Entity_ID` 用于标识资源的唯一性。

- **`~ResourceBag()`**  
  析构函数，自动清理资源，确保资源的正确释放。

- **`template <typename T> void AddResource(const std::string& name, std::shared_ptr<T> resource)`**  
  添加资源到 `ResourceBag` 中。使用 `std::shared_ptr` 管理资源的生命周期。

- **`template <typename T> std::shared_ptr<T> GetResource(const std::string& name) const`**  
  获取 `ResourceBag` 中的资源。通过资源名称查找并返回对应的 `std::shared_ptr`。

- **`bool LoadFromJson(const std::string& packageName)`**  
  从指定的 JSON 文件加载资源。根据资源包名称解析 JSON 文件，并创建资源对象（如 `CAnimateSprite`、`CSound` 等）。

**私有成员**

- **`std::unordered_map<std::string, std::shared_ptr<void>> container_`**  
  存储资源的容器，使用资源名称作为键，资源对象作为值。

- **`std::string Entity_ID`**  
  实体标识符，用于唯一标识资源。

- **`static const std::string resourceFilename`**  
  静态常量，资源文件的默认名称。

- **`long IdCounter`**  
  资源 ID 计数器，确保每个资源 ID 的唯一性。

## 3. 使用示例

```cpp
// 创建 ResourceBag 实例
ResourceBag resourceBag("Entity_1");

// 从 JSON 文件加载资源
if (resourceBag.LoadFromJson("packageName")) {
    // 资源加载成功
}

// 添加资源
auto sprite = std::make_shared<CStaticSprite>("sprite_id", "sprite_resource");
resourceBag.AddResource("sprite_name", sprite);

// 获取资源
auto retrievedSprite = resourceBag.GetResource<CStaticSprite>("sprite_name");
```