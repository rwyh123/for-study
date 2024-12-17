#pragma once
#include "GameObject.h"
#include "GameObjectsFactory.h"
class GameObjectBase : public GameObject
{
protected:
	sf::Texture texture;
	sf::Sprite sprite;
	string name;

	virtual void LoadTexture(string fileName);
public:
	virtual ~GameObjectBase();
	string GetName() override;
	void Draw(sf::Vector2f position) override;
	int GetDrawingPriority() override;
};

class Player : public GameObjectBase
{
	Player();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	int GetDrawingPriority() override;
	friend class GameObjectsFactory;
	//friend class PalyerPosition;
};

class Wall : public GameObjectBase
{
	Wall();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	friend class GameObjectsFactory;
};

class Door : public GameObjectBase
{
	Door();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	friend class GameObjectsFactory;
};

class Coin : public GameObjectBase
{
	Coin();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	friend class GameObjectsFactory;
};

class Diamond : public GameObjectBase
{
	Diamond();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	friend class GameObjectsFactory;
};

class Time : public GameObjectBase
{
	Time();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	friend class GameObjectsFactory;
};

class BonusThief : public GameObjectBase
{
	BonusThief();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	friend class GameObjectsFactory;
};

class TimeFag : public GameObjectBase
{
	TimeFag();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	friend class GameObjectsFactory;
};

class Monster : public GameObjectBase
{
	Monster();
public:
	GameObjectCommand Act(int x, int y, sf::Event event) override;
	bool DeadInConflict(GameObject* conflictedObject) override;
	int GetDrawingPriority() override;
	friend class GameObjectsFactory;
};