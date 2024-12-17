#include "GameObjectsFactory.h"
#include "GameObjects.h"
#include <stdexcept>

GameObject* GameObjectsFactory::CreateObjectInstance(char objectType)
{
    switch (objectType)
    {
        
    case 'P':
        return new Player();
    case 'W':
        return new Wall();
    case 'C':
        return new Coin();
    case 'D':
        return new Door();
    case 'Y':
        return new Diamond();
    case 'T':
        return new Time();
    case 'S':
        return new BonusThief();
    case 'E':
        return new TimeFag();
    case 'M':
        return new Monster();
    case ' ': 
        return nullptr;
    default:
        throw std::invalid_argument("An attempt was made to create an invalid object type");
    }
}
