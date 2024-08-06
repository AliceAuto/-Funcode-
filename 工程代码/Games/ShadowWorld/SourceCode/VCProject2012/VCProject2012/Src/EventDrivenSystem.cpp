#include "EventDrivenSystem.h"
#include <iostream>
EventManager eventManager;


void onMouseInput(const Event& event) {
    const MouseInputEvent& mouseEvent = static_cast<const MouseInputEvent&>(event);
    std::cout << "Mouse Input: (" << mouseEvent.GetX() << ", " << mouseEvent.GetY() << ")\n";
}

void onKeyboardInput(const Event& event) {
    const KeyboardInputEvent& keyboardEvent = static_cast<const KeyboardInputEvent&>(event);
    std::cout << "Keyboard Input: Key=" << keyboardEvent.GetKey() << ", State=" << keyboardEvent.GetState() << "\n";
}

