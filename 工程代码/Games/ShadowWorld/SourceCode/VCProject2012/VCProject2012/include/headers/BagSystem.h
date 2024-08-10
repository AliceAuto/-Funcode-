#include <iostream>
#include <vector>
#include <unordered_map>

//======================================================================
/*
							背包系统声明及实现
*/
//======================================================================




























// 物品类
class Item {
public:
    int id;         // 物品ID
    int quantity;   // 物品数量

    Item(int id, int quantity) : id(id), quantity(quantity) {}
};

// 背包网格类
class InventorySlot {
public:
    Item* item;     // 当前存放的物品
    InventorySlot() : item(nullptr) {}

    ~InventorySlot() {
        delete item;
    }
};

// 背包类
class Inventory {
private:
    std::vector<std::vector<InventorySlot>> grid;   // 背包网格
    int rows;                                       // 行数
    int cols;                                       // 列数
    std::unordered_map<int, int> maxStackSize;       // 每种物品的最大叠加数量

public:
    Inventory(int rows, int cols) : rows(rows), cols(cols) {
        grid.resize(rows, std::vector<InventorySlot>(cols));
        // 假设每种物品最大叠加数量为64
        for (int i = 1; i <= 100; ++i) {  // 假设物品ID从1到100
            maxStackSize[i] = 64;
        }
    }

    // 添加物品到背包
    bool addItem(int id, int quantity) {
        for (int r = 0; r < rows; ++r) {
            for (int c = 0; c < cols; ++c) {
                InventorySlot& slot = grid[r][c];
                if (slot.item != nullptr && slot.item->id == id) {
                    int maxStack = maxStackSize[id];
                    if (slot.item->quantity + quantity <= maxStack) {
                        slot.item->quantity += quantity;
                        return true;
                    } else {
                        quantity -= (maxStack - slot.item->quantity);
                        slot.item->quantity = maxStack;
                    }
                } else if (slot.item == nullptr) {
                    if (quantity <= maxStackSize[id]) {
                        slot.item = new Item(id, quantity);
                        return true;
                    } else {
                        slot.item = new Item(id, maxStackSize[id]);
                        quantity -= maxStackSize[id];
                    }
                }
            }
        }
        std::cout << "背包已满或无法添加更多物品！" << std::endl;
        return false;  // 背包已满或无法添加更多物品
    }

    // 从背包中取出物品
    bool removeItem(int id, int quantity) {
        for (int r = 0; r < rows; ++r) {
            for (int c = 0; c < cols; ++c) {
                InventorySlot& slot = grid[r][c];
                if (slot.item != nullptr && slot.item->id == id) {
                    if (slot.item->quantity >= quantity) {
                        slot.item->quantity -= quantity;
                        if (slot.item->quantity == 0) {
                            delete slot.item;
                            slot.item = nullptr;
                        }
                        return true;
                    } else {
                        quantity -= slot.item->quantity;
                        delete slot.item;
                        slot.item = nullptr;
                    }
                }
            }
        }
        std::cout << "未找到足够的物品！" << std::endl;
        return false;  // 未找到足够的物品
    }

    // 获取背包网格的行数
    int getRowCount() const {
        return rows;
    }

    // 获取背包网格的列数
    int getColCount() const {
        return cols;
    }

    // 获取指定槽位的物品信息
    Item* getItemAt(int row, int col) const {
        if (row >= 0 && row < rows && col >= 0 && col < cols) {
            const InventorySlot& slot = grid[row][col];
            return slot.item;
        }
        return nullptr;
    }

    // 获取物品的最大叠加数量
    int getMaxStackSize(int itemId) const {
        auto it = maxStackSize.find(itemId);
        return it != maxStackSize.end() ? it->second : 0;
    }

    // 查询背包是否有足够的空间来添加指定数量的物品
    bool canAddItem(int id, int quantity) const {
        for (int r = 0; r < rows; ++r) {
            for (int c = 0; c < cols; ++c) {
                const InventorySlot& slot = grid[r][c];
                if (slot.item == nullptr) {
                    if (quantity <= maxStackSize.at(id)) {
                        return true;
                    } else {
                        quantity -= maxStackSize.at(id);
                    }
                } else if (slot.item->id == id) {
                    int availableSpace = maxStackSize.at(id) - slot.item->quantity;
                    if (quantity <= availableSpace) {
                        return true;
                    } else {
                        quantity -= availableSpace;
                    }
                }
            }
        }
        return false;
    }

    // 打印背包内容，以矩阵的形式展示
    void printInventory() const {
        std::cout << "背包状态:" << std::endl;
        for (int r = 0; r < rows; ++r) {
            for (int c = 0; c < cols; ++c) {
                const InventorySlot& slot = grid[r][c];
                if (slot.item != nullptr) {
                    std::cout << "[" << slot.item->id << ":" << slot.item->quantity << "] ";
                } else {
                    std::cout << "[Empty] ";
                }
            }
            std::cout << std::endl;
        }
    }
};




/*


 std::cout << "测试用例 1: 基础添加和移除测试" << std::endl;
    Inventory inventory(5, 5); // 创建一个5x5的背包

    inventory.addItem(1, 10);
    inventory.addItem(2, 50);
    inventory.addItem(1, 60); // 叠加物品ID 1
    inventory.printInventory();

    inventory.removeItem(1, 20); // 从背包中取出物品ID 1
    inventory.printInventory();

    std::cout << "测试用例 2: 边界测试" << std::endl;
    Inventory smallInventory(2, 2); // 创建一个2x2的小背包

    smallInventory.addItem(1, 30);
    smallInventory.addItem(2, 30);
    smallInventory.addItem(1, 40); // 尝试添加超出背包容量的物品
    smallInventory.printInventory();

    std::cout << "测试用例 3: 空槽和无物品情况" << std::endl;
    Inventory emptyInventory(5, 5); // 创建一个5x5的空背包

    emptyInventory.addItem(3, 30);
    emptyInventory.printInventory();

    emptyInventory.removeItem(4, 10); // 尝试从背包中移除不存在的物品
    emptyInventory.printInventory();

    std::cout << "测试用例 4: 多种物品测试" << std::endl;
    Inventory multiItemInventory(5, 5); // 创建一个5x5的背包

    multiItemInventory.addItem(4, 40);
    multiItemInventory.addItem(5, 25);
    multiItemInventory.addItem(4, 30); // 叠加物品ID 4
    multiItemInventory.printInventory();

    std::cout << "测试用例 5: 添加与移除组合测试" << std::endl;
    Inventory comboInventory(5, 5); // 创建一个5x5的背包

    comboInventory.addItem(6, 15);
    comboInventory.removeItem(2, 10);
    comboInventory.addItem(7, 50);
    comboInventory.removeItem(6, 10);
    comboInventory.printInventory();
	
	
	*/