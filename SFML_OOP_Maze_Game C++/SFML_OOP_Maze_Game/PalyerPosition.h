#pragma once
#include "Point.h"
#include "GameObjects.h"

class PalyerPosition
{
private:
    Point point {0,0};
    PalyerPosition() {}
    PalyerPosition(const PalyerPosition&);
    PalyerPosition& operator=(PalyerPosition&);
    void setPSetPlayerPosition(int x, int y);
public:
    static PalyerPosition& getInstance();
    Point GetPlayerPosition();
    friend class Player;
    
};

