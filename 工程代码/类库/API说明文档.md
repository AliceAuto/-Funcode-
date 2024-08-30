# 开发文档

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

## 2. `Entity` 类

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