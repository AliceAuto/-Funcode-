#ifndef VIDEO_H
#define VIDEO_H

#include "UI.h"

class Video : public UI {
public:
    // Constructor to initialize Video
    Video(float initialX, float initialY, const std::string& resourceBagName, const std::string& label, const std::string& videoSource);

    // Destructor
    virtual ~Video();

    // Methods to control video playback
    void Play();
    void Pause();
    void Stop();

protected:
    // Override to update video-specific state
    void UpdateState() override;
    void UpdateAnimation() override;
    void UpdateSound() override;

private:
    std::string videoSource_; // Path or identifier for the video source
    bool playing_;            // Flag to track if the video is currently playing
};

#endif // VIDEO_H
