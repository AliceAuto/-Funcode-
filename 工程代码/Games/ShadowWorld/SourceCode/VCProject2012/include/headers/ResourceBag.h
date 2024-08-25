
#ifndef RESOURCEBAG_H
#define RESOURCEBAG_H

#include "CSprite.h"
#include <string>
#include <map>

class ResourceBag {
public:
    ResourceBag();
    ResourceBag(const std::string& runningTag, const std::string& characterTag);
    ~ResourceBag();

    void Unload();
    void LoadResourcesFromTags(const std::string& runningTag, const std::string& characterTag);

    CSound* running;
    CAnimateSprite* Character;

private:
    CSound* GetSoundFromTag(const std::string& tag);
    CAnimateSprite* GetSpriteFromTag(const std::string& tag);
};

void LoadResourcesFromJSON(std::map<std::string, ResourceBag *>& resourceBags, const std::string& filename);

#endif // RESOURCEBAG_H