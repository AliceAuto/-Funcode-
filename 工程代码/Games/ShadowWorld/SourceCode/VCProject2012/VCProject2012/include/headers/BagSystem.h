#include <iostream>
#include <vector>
#include <unordered_map>

//======================================================================
/*
							����ϵͳ������ʵ��
*/
//======================================================================




























// ��Ʒ��
class Item {
public:
    int id;         // ��ƷID
    int quantity;   // ��Ʒ����

    Item(int id, int quantity) : id(id), quantity(quantity) {}
};

// ����������
class InventorySlot {
public:
    Item* item;     // ��ǰ��ŵ���Ʒ
    InventorySlot() : item(nullptr) {}

    ~InventorySlot() {
        delete item;
    }
};

// ������
class Inventory {
private:
    std::vector<std::vector<InventorySlot>> grid;   // ��������
    int rows;                                       // ����
    int cols;                                       // ����
    std::unordered_map<int, int> maxStackSize;       // ÿ����Ʒ������������

public:
    Inventory(int rows, int cols) : rows(rows), cols(cols) {
        grid.resize(rows, std::vector<InventorySlot>(cols));
        // ����ÿ����Ʒ����������Ϊ64
        for (int i = 1; i <= 100; ++i) {  // ������ƷID��1��100
            maxStackSize[i] = 64;
        }
    }

    // �����Ʒ������
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
        std::cout << "�����������޷���Ӹ�����Ʒ��" << std::endl;
        return false;  // �����������޷���Ӹ�����Ʒ
    }

    // �ӱ�����ȡ����Ʒ
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
        std::cout << "δ�ҵ��㹻����Ʒ��" << std::endl;
        return false;  // δ�ҵ��㹻����Ʒ
    }

    // ��ȡ�������������
    int getRowCount() const {
        return rows;
    }

    // ��ȡ�������������
    int getColCount() const {
        return cols;
    }

    // ��ȡָ����λ����Ʒ��Ϣ
    Item* getItemAt(int row, int col) const {
        if (row >= 0 && row < rows && col >= 0 && col < cols) {
            const InventorySlot& slot = grid[row][col];
            return slot.item;
        }
        return nullptr;
    }

    // ��ȡ��Ʒ������������
    int getMaxStackSize(int itemId) const {
        auto it = maxStackSize.find(itemId);
        return it != maxStackSize.end() ? it->second : 0;
    }

    // ��ѯ�����Ƿ����㹻�Ŀռ������ָ����������Ʒ
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

    // ��ӡ�������ݣ��Ծ������ʽչʾ
    void printInventory() const {
        std::cout << "����״̬:" << std::endl;
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


 std::cout << "�������� 1: ������Ӻ��Ƴ�����" << std::endl;
    Inventory inventory(5, 5); // ����һ��5x5�ı���

    inventory.addItem(1, 10);
    inventory.addItem(2, 50);
    inventory.addItem(1, 60); // ������ƷID 1
    inventory.printInventory();

    inventory.removeItem(1, 20); // �ӱ�����ȡ����ƷID 1
    inventory.printInventory();

    std::cout << "�������� 2: �߽����" << std::endl;
    Inventory smallInventory(2, 2); // ����һ��2x2��С����

    smallInventory.addItem(1, 30);
    smallInventory.addItem(2, 30);
    smallInventory.addItem(1, 40); // ������ӳ���������������Ʒ
    smallInventory.printInventory();

    std::cout << "�������� 3: �ղۺ�����Ʒ���" << std::endl;
    Inventory emptyInventory(5, 5); // ����һ��5x5�Ŀձ���

    emptyInventory.addItem(3, 30);
    emptyInventory.printInventory();

    emptyInventory.removeItem(4, 10); // ���Դӱ������Ƴ������ڵ���Ʒ
    emptyInventory.printInventory();

    std::cout << "�������� 4: ������Ʒ����" << std::endl;
    Inventory multiItemInventory(5, 5); // ����һ��5x5�ı���

    multiItemInventory.addItem(4, 40);
    multiItemInventory.addItem(5, 25);
    multiItemInventory.addItem(4, 30); // ������ƷID 4
    multiItemInventory.printInventory();

    std::cout << "�������� 5: ������Ƴ���ϲ���" << std::endl;
    Inventory comboInventory(5, 5); // ����һ��5x5�ı���

    comboInventory.addItem(6, 15);
    comboInventory.removeItem(2, 10);
    comboInventory.addItem(7, 50);
    comboInventory.removeItem(6, 10);
    comboInventory.printInventory();
	
	
	*/