#include "Video.h"



Video::Video(float initialX, float initialY, const std::string& resourceBagName, const std::string& label, const std::string& videoSource)
    : UI(initialX, initialY, resourceBagName, label), videoSource_(videoSource), playing_(false) {

}


Video::~Video() {

}


void Video::Play() {
    if (!playing_) {
        playing_ = true;
    } else {
    }
}

void Video::Pause() {
    if (playing_) {
        playing_ = false;
    } else {
    }
}

// Stop the video
void Video::Stop() {
    if (playing_) {
        playing_ = false;
    } else {

    }
}

void Video::UpdateState() {

}


void Video::UpdateAnimation() {

}


void Video::UpdateSound() {
    
}
 