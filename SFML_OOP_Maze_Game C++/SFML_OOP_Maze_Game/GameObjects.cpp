#include "GameObjects.h"
#include "Game.h"
#include "PalyerPosition.h"

string GameObjectBase::GetName()
{
    return name;
}

void GameObjectBase::Draw(sf::Vector2f position)
{
    sprite.setPosition(position);
    if (window)
        window->draw(sprite);
}

int GameObjectBase::GetDrawingPriority()
{
    return 1;
}


void GameObjectBase::LoadTexture(string fileName)
{
    texture.loadFromFile(fileName);
    sprite.setTexture(texture);
}


GameObjectBase::~GameObjectBase()
{
    if (GetName() == "Player") Game::players--;
    else if (GetName() == "Wall") Game::walls--;
    else if (GetName() == "Door") Game::doors--;
    else if (GetName() == "Coin") Game::coins--;
    else if (GetName() == "Diamond") Game::diamonds--;
    else if (GetName() == "Time") Game::times--;
    else if (GetName() == "BonusThief") Game::bonusthief--;
    else if (GetName() == "TimeFag") Game::timefag--;
    else if (GetName() == "Monster") Game::monster--;

}

Player::Player()
{
    name = "Player";
    LoadTexture("assets\\bitmaps\\player.png");
    Game::players++;
}

GameObjectCommand Player::Act(int x, int y, sf::Event event)
{
    PalyerPosition::getInstance().setPSetPlayerPosition(x, y);
    
    auto canMove = [](GameObject* obj) {
        return (obj == nullptr) || (obj->GetName() == "Coin") || (obj->GetName() == "Door") || (obj->GetName() == "Diamond") ||
            (obj->GetName() == "Time") || (obj->GetName() == "BonusThief") || (obj->GetName() == "TimeFag");
    };
    
    if (event.type == sf::Event::KeyPressed)
    {
        switch (event.key.code)
        {
        case sf::Keyboard::Key::Left:
            if (x > 0 && canMove(Game::maze.levelMap[y][x-1]))
            {

                return GameObjectCommand{ -1,0, this };
            }
            break;
        case sf::Keyboard::Key::Right:
            if (x < Game::maze.GetWidth() - 1 && canMove(Game::maze.levelMap[y][x + 1]))
            {
                return GameObjectCommand{ 1,0, this };
            }
            break;
        case sf::Keyboard::Key::Up:
            if (y > 0 && canMove(Game::maze.levelMap[y-1][x]))
            {
                return GameObjectCommand{ 0,-1, this };
            }
            break;
        case sf::Keyboard::Key::Down:
            if (y < Game::maze.GetHeight() - 1 && canMove(Game::maze.levelMap[y + 1][x]))
            {
                return GameObjectCommand{ 0,1, this };
            }
            break;
        }
    }
    return GameObjectCommand {0,0, this};
    
}

bool Player::DeadInConflict(GameObject* conflictedObject)
{
    return false;
}

int Player::GetDrawingPriority()
{
    return 10;
}

Wall::Wall()
{
    name = "Wall";
    LoadTexture("assets\\bitmaps\\wall.png");
    Game::walls++;
}

GameObjectCommand Wall::Act(int x, int y, sf::Event event)
{
    return GameObjectCommand{ 0,0, this};
}

bool Wall::DeadInConflict(GameObject* conflictedObject)
{
    return false;
}

Door::Door()
{
    name = "Door";
    LoadTexture("assets\\bitmaps\\door.png");
    Game::doors++;
}

GameObjectCommand Door::Act(int x, int y, sf::Event event)
{
    return GameObjectCommand{ 0,0, this};
}

bool Door::DeadInConflict(GameObject* conflictedObject)
{
    Game::isOver = true;
    return (conflictedObject->GetName() == "Player");
}

Coin::Coin()
{
    name = "Coin";
    LoadTexture("assets\\bitmaps\\coin.png");
    Game::coins++;
}

GameObjectCommand Coin::Act(int x, int y, sf::Event event)
{
    return GameObjectCommand{ 0, 0, this};
}

bool Coin::DeadInConflict(GameObject* conflictedObject)
{
    if (conflictedObject->GetName() == "Player")
    {
        Game::score += 100;
    }
    return true;
}

Diamond::Diamond()
{
    name = "Diamond";
    LoadTexture("assets\\bitmaps\\diamond.png");
    Game::diamonds++;
}

GameObjectCommand Diamond::Act(int x, int y, sf::Event event)
{
    return GameObjectCommand{ 0, 0, this }; 
}

bool Diamond::DeadInConflict(GameObject* conflictedObject)
{
    if (conflictedObject->GetName() == "Player")
    {
        Game::score += 300;
    }
    return true;
}


Time::Time()
{
    name = "Time";
    LoadTexture("assets\\bitmaps\\time.png");
    Game::times++;
}

GameObjectCommand Time::Act(int x, int y, sf::Event event)
{
    return GameObjectCommand{ 0, 0, this };
}

bool Time::DeadInConflict(GameObject* conflictedObject)
{
    if (conflictedObject->GetName() == "Player")
    {
        Game::timeLeft += 10000;
    }
    return true;
}

BonusThief::BonusThief()
{
    name = "BonusThief";
    LoadTexture("assets\\bitmaps\\bonusthief.png");
    Game::bonusthief++;
}

GameObjectCommand BonusThief::Act(int x, int y, sf::Event event)
{
    return GameObjectCommand{ 0, 0, this };
}

bool BonusThief::DeadInConflict(GameObject* conflictedObject)
{
    if (conflictedObject->GetName() == "Player")
    {
        Game::score -= 200;
    }
    return true;
}

TimeFag::TimeFag()
{
    name = "TimeFag";
    LoadTexture("assets\\bitmaps\\timefag.png");
    Game::timefag++;
}

GameObjectCommand TimeFag::Act(int x, int y, sf::Event event)
{
    return GameObjectCommand{ 0, 0, this };
}

bool TimeFag::DeadInConflict(GameObject* conflictedObject)
{
    if (conflictedObject->GetName() == "Player")
    {
        Game::timeLeft -= 7000;
    }
    return true;
}

Monster::Monster()
{
    name = "Monster";
    LoadTexture("assets\\bitmaps\\monster.png");
    Game::monster++;
}

GameObjectCommand Monster::Act(int x, int y, sf::Event event)
{
    auto canMove = [](GameObject* obj) {
        return (obj == nullptr) || (obj->GetName() == "Coin") || (obj->GetName() == "Door") || (obj->GetName() == "Diamond") ||
            (obj->GetName() == "Time") || (obj->GetName() == "BonusThief") || (obj->GetName() == "TimeFag");
    };



    if (Game::players > 0)
    {
        switch (event.key.code)
        {
        case sf::Keyboard::Key::Left:
            if (x > 0 && canMove(Game::maze.levelMap[y][x - 1])) // влево
            {
                return GameObjectCommand{ -1,0, this };
            }
            break;
        case sf::Keyboard::Key::Right:
            if (x < Game::maze.GetWidth() - 1 && canMove(Game::maze.levelMap[y][x + 1]))  // вправо
            {
                return GameObjectCommand{ 1,0, this };
            }
            break;
        case sf::Keyboard::Key::Up:
            if (y > 0 && canMove(Game::maze.levelMap[y - 1][x])) //вверх
            {
                return GameObjectCommand{ 0,-1, this };
            }
            break;
        case sf::Keyboard::Key::Down:
            if (y < Game::maze.GetHeight() - 1 && canMove(Game::maze.levelMap[y + 1][x])) //вниз
            {
                return GameObjectCommand{ 0,1, this };
            }
            break;
        }
    }
    return GameObjectCommand{ 0,0, this };
}

bool Player::DeadInConflict(GameObject* conflictedObject)
{
    return false;
}

int Player::GetDrawingPriority()
{
    return 10;
}