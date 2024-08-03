#ifndef INTERACTION_H
#define INTERACTION_H

#include <string>
#include <vector>

// Monster �ඨ��
class Monster {
public:
    Monster(const std::string& name, int health) : name(name), health(health) {}
    std::string getName() const { return name; }
    int getHealth() const { return health; }
    void takeDamage(int damage) { health -= damage; }
private:
    std::string name;
    int health;
};

// Item �ඨ��
class Item {
public:
    Item(const std::string& name, int value) : name(name), value(value) {}
    std::string getName() const { return name; }
    int getValue() const { return value; }
private:
    std::string name;
    int value;
};

// GameObjectFactory �ඨ��
class GameObjectFactory {
public:
    static Monster createMonster(const std::string& name, int health) {
        return Monster(name, health);
    }
    static Item createItem(const std::string& name, int value) {
        return Item(name, value);
    }
};

#endif // INTERACTION_H\





/*  




// ����һ������


    Monster goblin = GameObjectFactory::createMonster("Goblin", 100);
    std::cout << "Monster: " << goblin.getName() << ", Health: " << goblin.getHealth() << std::endl;

    // ����һ����Ʒ
    Item potion = GameObjectFactory::createItem("Potion", 50);
    std::cout << "Item: " << potion.getName() << ", Value: " << potion.getValue() << std::endl;

    // ���Թ�������
    goblin.takeDamage(20);
    std::cout << "Monster after damage: " << goblin.getHealth() << std::endl;
	
	
	*/