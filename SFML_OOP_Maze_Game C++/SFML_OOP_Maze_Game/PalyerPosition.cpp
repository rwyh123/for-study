#include "PalyerPosition.h"


void PalyerPosition::setPSetPlayerPosition(int x, int y)
{
    this->point.x = x;
    this->point.y = y;
}

PalyerPosition& PalyerPosition::getInstance()
{
        static PalyerPosition  instance;
        return instance;  
}

Point PalyerPosition::GetPlayerPosition()
{
    return point;
}
