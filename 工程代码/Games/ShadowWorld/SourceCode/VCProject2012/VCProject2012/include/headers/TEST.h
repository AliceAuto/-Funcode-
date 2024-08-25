#include <iostream>
#include <string>
#include <map>
#include <memory>
#include <sstream>
#include <stdexcept>
#include <typeinfo>
#include <typeindex>
#include <functional>

// ������
class Date {
public:
    Date() : day(0), month(0), year(0) {}
    Date(int day, int month, int year)
        : day(day), month(month), year(year) {}

    int GetDay() const { return day; }
    int GetMonth() const { return month; }
    int GetYear() const { return year; }

    // ���������ַ���Ϊ Date ����
    static Date Parse(const std::string& valueStr) {
        int day, month, year;
        char delimiter;
        std::istringstream iss(valueStr);
        iss >> day >> delimiter >> month >> delimiter >> year;
        return Date(day, month, year);
    }

    // ֱ�����������Ϣ
    friend std::ostream& operator<<(std::ostream& os, const Date& date) {
        os << date.day << "/" << date.month << "/" << date.year;
        return os;
    }

private:
    int day;
    int month;
    int year;
};

// ���ʹ���ӿ�
class ITypeHandler {
public:
    virtual ~ITypeHandler() {}
    virtual void* ParseValue(const std::string& valueStr) const = 0;
    virtual const std::type_info& GetType() const = 0;
};

// ���ʹ�����ģ����
template <typename T>
class TypeHandler : public ITypeHandler {
public:
    // ����ֵ������ָ���¶����ָ��
    virtual void* ParseValue(const std::string& valueStr) const {
        T* value = new T();
        *value = T::Parse(valueStr); // �������� T �� Parse ����
        return value;
    }

    virtual const std::type_info& GetType() const {
        return typeid(T);
    }
};

// ��Ի������͵��ػ�
template <>
class TypeHandler<int> : public ITypeHandler {
public:
    // ��������ֵ
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
    // ����˫���ȸ���ֵ
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
    // �����ַ���ֵ
    virtual void* ParseValue(const std::string& valueStr) const {
        return new std::string(valueStr);
    }

    virtual const std::type_info& GetType() const {
        return typeid(std::string);
    }
};

// ������
class Container {
public:
    // ע�����Ͳ�����ֵ
    template <typename T>
    void RegisterAndSetValue(const std::string& key, const T& value) {
        const std::string typeName = typeid(T).name(); // ��ȡ������
        RegisterType<T>(typeName);
        SetValue(key, typeName, &value);
    }

    // ����ֵ
    void SetValue(const std::string& key, const std::string& typeName, const void* value) {
        if (typeHandlers_.find(typeName) == typeHandlers_.end()) {
            throw std::runtime_error("δע�������: " + typeName);
        }

        ITypeHandler* handler = typeHandlers_[typeName].get();
        void* valueCopy = handler->ParseValue(""); // ����һ���¶���
        // ����ֵ��������� T ���͵Ķ������ֱ�Ӹ��ƣ�
        std::memcpy(valueCopy, value, sizeof(valueCopy));
        values_[key] = std::unique_ptr<void, std::function<void(void*)>>(valueCopy, [](void* ptr) { delete static_cast<void*>(ptr); });
    }

    // ��װ��ȡֵ�Ĳ���
    template <typename T>
    T GetValue(const std::string& key) const {
        T value;
        if (!TryGetValue<T>(key, value)) {
            throw std::runtime_error("�޷���ȡ��: " + key + " ��ֵ");
        }
        return value;
    }

    // ��װ��ȫ��ȡֵ�Ĳ���
    template <typename T>
    bool TryGetValue(const std::string& key, T& value) const {
        try {
            const std::string typeName = typeid(T).name();
            const auto& handler = typeHandlers_.at(typeName);
            auto it = values_.find(key);
            if (it == values_.end()) {
                throw std::runtime_error("δ�ҵ���: " + key);
            }

            if (handler->GetType() != typeid(T)) {
                throw std::runtime_error("��: " + key + " �����Ͳ�ƥ��");
            }

            void* storedValue = it->second.get();
            value = *static_cast<T*>(storedValue);
            return true;
        } catch (...) {
            return false;
        }
    }

    // ��װ��ȡֵ�������쳣
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
    // ע������
    template <typename T>
    void RegisterType(const std::string& typeName) {
        typeHandlers_[typeName] = std::unique_ptr<ITypeHandler>(new TypeHandler<T>());
    }

    std::map<std::string, std::unique_ptr<ITypeHandler>> typeHandlers_;
    std::map<std::string, std::unique_ptr<void, std::function<void(void*)>>> values_;
};




/*Container container;
    Container container;

    // ע�����Ͳ�����ֵ
    int age = 42;
    double pi = 3.14;
    std::string greeting = "Hello, World!";
    Date birthDate = Date::Parse("15/08/1990");

    container.RegisterAndSetValue<int>("age", age);
    container.RegisterAndSetValue<double>("pi", pi);
    container.RegisterAndSetValue<std::string>("greeting", greeting);
    container.RegisterAndSetValue<Date>("birthDate", birthDate);

    // ��ȡֵ������
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