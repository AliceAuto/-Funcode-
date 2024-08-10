#include <iostream>
#include <string>
#include <map>
#include <memory>
#include <sstream>
#include <stdexcept>
#include <typeinfo>
#include <typeindex>
#include <functional>

// 日期类
class Date {
public:
    Date() : day(0), month(0), year(0) {}
    Date(int day, int month, int year)
        : day(day), month(month), year(year) {}

    int GetDay() const { return day; }
    int GetMonth() const { return month; }
    int GetYear() const { return year; }

    // 解析日期字符串为 Date 对象
    static Date Parse(const std::string& valueStr) {
        int day, month, year;
        char delimiter;
        std::istringstream iss(valueStr);
        iss >> day >> delimiter >> month >> delimiter >> year;
        return Date(day, month, year);
    }

    // 直接输出日期信息
    friend std::ostream& operator<<(std::ostream& os, const Date& date) {
        os << date.day << "/" << date.month << "/" << date.year;
        return os;
    }

private:
    int day;
    int month;
    int year;
};

// 类型处理接口
class ITypeHandler {
public:
    virtual ~ITypeHandler() {}
    virtual void* ParseValue(const std::string& valueStr) const = 0;
    virtual const std::type_info& GetType() const = 0;
};

// 类型处理器模板类
template <typename T>
class TypeHandler : public ITypeHandler {
public:
    // 解析值并返回指向新对象的指针
    virtual void* ParseValue(const std::string& valueStr) const {
        T* value = new T();
        *value = T::Parse(valueStr); // 调用类型 T 的 Parse 函数
        return value;
    }

    virtual const std::type_info& GetType() const {
        return typeid(T);
    }
};

// 针对基本类型的特化
template <>
class TypeHandler<int> : public ITypeHandler {
public:
    // 解析整数值
    virtual void* ParseValue(const std::string& valueStr) const {
        int* value = new int();
        std::istringstream iss(valueStr);
        iss >> *value;
        return value;
    }

    virtual const std::type_info& GetType() const {
        return typeid(int);
    }
};

template <>
class TypeHandler<double> : public ITypeHandler {
public:
    // 解析双精度浮点值
    virtual void* ParseValue(const std::string& valueStr) const {
        double* value = new double();
        std::istringstream iss(valueStr);
        iss >> *value;
        return value;
    }

    virtual const std::type_info& GetType() const {
        return typeid(double);
    }
};

template <>
class TypeHandler<std::string> : public ITypeHandler {
public:
    // 解析字符串值
    virtual void* ParseValue(const std::string& valueStr) const {
        return new std::string(valueStr);
    }

    virtual const std::type_info& GetType() const {
        return typeid(std::string);
    }
};

// 容器类
class Container {
public:
    // 注册类型并设置值
    template <typename T>
    void RegisterAndSetValue(const std::string& key, const T& value) {
        const std::string typeName = typeid(T).name(); // 获取类型名
        RegisterType<T>(typeName);
        SetValue(key, typeName, &value);
    }

    // 设置值
    void SetValue(const std::string& key, const std::string& typeName, const void* value) {
        if (typeHandlers_.find(typeName) == typeHandlers_.end()) {
            throw std::runtime_error("未注册的类型: " + typeName);
        }

        ITypeHandler* handler = typeHandlers_[typeName].get();
        void* valueCopy = handler->ParseValue(""); // 创建一个新对象
        // 复制值（这里假设 T 类型的对象可以直接复制）
        std::memcpy(valueCopy, value, sizeof(valueCopy));
        values_[key] = std::unique_ptr<void, std::function<void(void*)>>(valueCopy, [](void* ptr) { delete static_cast<void*>(ptr); });
    }

    // 封装获取值的操作
    template <typename T>
    T GetValue(const std::string& key) const {
        T value;
        if (!TryGetValue<T>(key, value)) {
            throw std::runtime_error("无法获取键: " + key + " 的值");
        }
        return value;
    }

    // 封装安全获取值的操作
    template <typename T>
    bool TryGetValue(const std::string& key, T& value) const {
        try {
            const std::string typeName = typeid(T).name();
            const auto& handler = typeHandlers_.at(typeName);
            auto it = values_.find(key);
            if (it == values_.end()) {
                throw std::runtime_error("未找到键: " + key);
            }

            if (handler->GetType() != typeid(T)) {
                throw std::runtime_error("键: " + key + " 的类型不匹配");
            }

            void* storedValue = it->second.get();
            value = *static_cast<T*>(storedValue);
            return true;
        } catch (...) {
            return false;
        }
    }

    // 封装获取值并处理异常
    template <typename T>
    bool SafeGetValue(const std::string& key, T& value) const {
        try {
            value = GetValue<T>(key);
            return true;
        } catch (const std::exception&) {
            return false;
        }
    }

private:
    // 注册类型
    template <typename T>
    void RegisterType(const std::string& typeName) {
        typeHandlers_[typeName] = std::unique_ptr<ITypeHandler>(new TypeHandler<T>());
    }

    std::map<std::string, std::unique_ptr<ITypeHandler>> typeHandlers_;
    std::map<std::string, std::unique_ptr<void, std::function<void(void*)>>> values_;
};




/*Container container;
    Container container;

    // 注册类型并设置值
    int age = 42;
    double pi = 3.14;
    std::string greeting = "Hello, World!";
    Date birthDate = Date::Parse("15/08/1990");

    container.RegisterAndSetValue<int>("age", age);
    container.RegisterAndSetValue<double>("pi", pi);
    container.RegisterAndSetValue<std::string>("greeting", greeting);
    container.RegisterAndSetValue<Date>("birthDate", birthDate);

    // 获取值并处理
    int retrievedAge;
    double retrievedPi;
    std::string retrievedGreeting;
    Date retrievedBirthDate;

    if (container.SafeGetValue("age", retrievedAge)) {
        std::cout << "Retrieved age: " << retrievedAge << std::endl;
    }
    if (container.SafeGetValue("pi", retrievedPi)) {
        std::cout << "Retrieved pi: " << retrievedPi << std::endl;
    }
    if (container.SafeGetValue("greeting", retrievedGreeting)) {
        std::cout << "Retrieved greeting: " << retrievedGreeting << std::endl;
    }
    if (container.SafeGetValue("birthDate", retrievedBirthDate)) {
        std::cout << "Retrieved birth date: " << retrievedBirthDate << std::endl;
    }


*/