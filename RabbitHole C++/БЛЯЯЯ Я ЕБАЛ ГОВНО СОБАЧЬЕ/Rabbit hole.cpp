
#include <SFML/Graphics.hpp>
#include <conio.h>
#include <iostream>
#include <vector>
#include <ctime>  // Для использования функции std::time
#include <cstdlib>
#include <random>
#include <chrono>
#include <string>

using namespace sf;
class Wall;
class Maze;
class Entity;
class Enemy;
class Player;
class Key;
class Door;




int rows1 = 20, cols1 =20 , spriteSize =  24;
sf::RenderWindow window(sf::VideoMode(rows1* spriteSize, cols1* spriteSize), "Rabbit hole");

class Wall
{
private:
	int x;
	int y;
	Sprite wallSprite;
	Texture wallTexture;
	Sprite wallSprite1;
	Texture wallTexture1;
	bool left, top, right, bot, visited, isCurrent;
	
public:
	Wall(int x, int y);
	Wall();
	~Wall();

	void drawWall(int cols, int rows);

	void setVisited();
	void setCurrent(bool x);
	void disLeft();
	void disTop();
	void disRight();
	void disBot();

	bool getCurrent();
	bool getVisiteg();
	int getX();
	int getY();
	bool getTop();
	bool getBot();
	bool getLeft();
	bool getRight();
};

Wall::Wall()
{
	visited = 0;
	left = 1;
	top = 1;
	right = 1;
	bot = 1;
	x = 0;
	y = 0;
	isCurrent = 0;
	wallTexture.loadFromFile("wall.PNG");
	wallSprite.setTexture(wallTexture);
}

Wall::Wall(int x, int y)
{
	visited = 0;
	left = 1;
	top = 1;
	right = 1;
	bot = 1;
	isCurrent = 0;
	this->x = x;
	this->y = y;
	wallTexture.loadFromFile("wall.PNG");
	wallSprite.setTexture(wallTexture);
	
}

Wall::~Wall()
{
}

void Wall::drawWall(int cols,int rows)
{
	if (left && top && right && bot)
	{
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (left && top && right && !bot)
	{
		//assets\\bitmaps\\ 
		wallTexture.loadFromFile("walBot1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));

		window.draw(wallSprite);
	}
	if (left && top && bot && !right)
	{
		wallTexture.loadFromFile("walRight1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (right && top && bot && !left)
	{
		wallTexture.loadFromFile("walLeftl1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (right && left && bot && !top)
	{
		wallTexture.loadFromFile("walTop1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (left && top && !right && !bot)
	{
		wallTexture.loadFromFile("walBotRight1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (!left && top && right && !bot)
	{
		wallTexture.loadFromFile("walBotLeft1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (!left && !top && right && bot)
	{
		wallTexture.loadFromFile("walTopLeft1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (left && !top && !right && bot)
	{
		wallTexture.loadFromFile("walTopRight1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);

		
	}
	if (left && !top && right && !bot)
	{
		wallTexture.loadFromFile("walTopBot1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (!left && top && !right && bot)
	{
		wallTexture.loadFromFile("walRightLeft1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (!left && !top && !right && bot)
	{
		wallTexture.loadFromFile("walRightLeftTot1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (!left && !top && right && !bot)
	{
		wallTexture.loadFromFile("walBotRightTot1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (!left && top && !right && !bot)
	{
		wallTexture.loadFromFile("walRightLeftBot1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (left && !top && !right && !bot)
	{
		wallTexture.loadFromFile("walBotLeftTot1.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
	if (!left && !top && !right && !bot)
	{
		wallTexture.loadFromFile("ext.PNG");
		wallSprite.setTexture(wallTexture);
		wallSprite.setPosition(sf::Vector2f(this->x * cols1, this->y * rows1));
		window.draw(wallSprite);
	}
}

void Wall::setVisited()
{
	visited = 1;
}

void Wall::setCurrent(bool x)
{
	if (x)
	{
		isCurrent = x;
		wallTexture.loadFromFile("wallCurrent.PNG");
		wallSprite.setTexture(wallTexture);
	}
	else
	{
		isCurrent = 0;
		wallTexture.loadFromFile("wall.PNG");
		wallSprite.setTexture(wallTexture);
	}

}

void Wall::disLeft()
{
	left = 0;
}

void Wall::disTop()
{
	top = 0;
}

void Wall::disRight()
{
	right = 0;
}

void Wall::disBot()
{
	bot = 0;
}

bool Wall::getCurrent()
{
	return isCurrent;
}

bool Wall::getVisiteg()
{
	return visited;
}

int Wall::getX()
{
	return x;
}

int Wall::getY()
{
	return y;
}

bool Wall::getTop()
{
	return top;
}

bool Wall::getBot()
{
	return bot;
}

bool Wall::getLeft()
{
	return left;
}

bool Wall::getRight()
{
	return right;
}


//--------------------------------------------------------------------------------------------

class Maze
{
private:
	int cols;
	int rows;
	Wall** maze;

public:
	Maze();
	~Maze();
	Wall** createMaze();
	void currentWall(bool x);
	auto serchNeibor();
	Wall** move();
	void drawMaze();
	Wall** getMaze();
	int getCols();
	int getRows();
};

Maze::Maze()
{
	cols = 20;
	rows = 20;
	maze = createMaze();
}

Maze::~Maze()
{
}

Wall** Maze::createMaze() {

	Wall** maze = new Wall * [rows];
	for (int i = 0; i < rows; ++i) {
		maze[i] = new Wall[cols];
	}
	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < cols; ++j)
		{
			maze[i][j] = *new Wall(i, j);

		}
	}
	return maze;
}

void Maze::currentWall(bool x)
{
	int i = 0, j = 0;
	maze[i][j].setVisited();
	maze[i][j].setCurrent(x);
}

auto Maze::serchNeibor()
{
	std::vector<Wall*>neibors;
	Wall curWal;
	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < cols; ++j)
		{
			if (maze[i][j].getCurrent())
			{
				curWal = maze[i][j];
				break;
			}
		}
	}
	for (int i = 0; i < rows; ++i)
	{
		for (int j = 0; j < cols; ++j)
		{
			if (((curWal.getX() - maze[i][j].getX()) == 1 || (curWal.getX() - maze[i][j].getX()) == -1))
			{
				if (((curWal.getY() - maze[i][j].getY()) == 0) && !maze[i][j].getVisiteg() && maze[i][j].getX() >= 0 && maze[i][j].getX() <= cols-1)
				{
					Wall* wall;
					wall = &maze[i][j];
					neibors.push_back(wall);
					/*std::cout << &maze[i][j] << '\n';
					std::cout << wall;*/
				}
			}
			if ((curWal.getY() - maze[i][j].getY() == 1 || curWal.getY() - maze[i][j].getY() == -1) )
			{
				if ((curWal.getX() - maze[i][j].getX() == 0) && !maze[i][j].getVisiteg() && maze[i][j].getY() >= 0 && maze[i][j].getY() <= rows - 1)
				{
					Wall* wall;
					wall = &maze[i][j];
					neibors.push_back(wall);
				}
			}

			//ИГАРБ ПРИДУМАЛ ЕСЛИ РАЗНИЦ А НЕ БОЛЬШЕ ОДНОГО ТО КАФ!!



		}
	}
	return neibors;
}

Wall** Maze::move()
{
	int h = 10;
	Wall* curWal = new Wall;
	Wall* wall;

	std::vector <Wall*> neibs = serchNeibor();
	std::vector <Wall*> stack;


	do
	{
		neibs = serchNeibor();
		if (!neibs.empty())
		{
			for (int i = 0; i < rows; ++i)
			{
				for (int j = 0; j < cols; ++j)
				{
					if (maze[i][j].getCurrent())
					{
						curWal = &maze[i][j];

					}
				}
			}
			neibs = serchNeibor();
			int x = neibs.size();
			auto currentTime = std::chrono::high_resolution_clock::now().time_since_epoch().count();
			std::mt19937 gen(static_cast<unsigned int>(currentTime));// Использование времени в качестве стартового значения для генератора случайных чисел
			std::uniform_int_distribution<int> distribution(1, x);// Определение диапазона случайных чисел (в данном случае, от 1 до 10)
			int randomNumber = distribution(gen);// Генерация случайного числа
			switch (randomNumber)
			{
			case 1:
				curWal->setCurrent(0);
				neibs[0]->setCurrent(1);
				neibs[0]->setVisited();
				//Wall* wall;
				wall = neibs[0];
				stack.push_back(wall);
				//std::cout << neibs[0] << ' ' << wall << '\n';
				if (curWal->getX() - neibs[0]->getX() != 0)
				{
					if (curWal->getX() - neibs[0]->getX() < 0 ) //вправо
					{
						curWal->disRight();
						neibs[0]->disLeft();
						std::cout << "пошел вправо " << '\n';
					}
					else {
						curWal->disLeft(); //влево
						neibs[0]->disRight();
						std::cout << "пошел влево " << '\n';
					}
				}
				else {
					if (curWal->getY() - neibs[0]->getY() > 0) //вверх
					{
						curWal->disTop();
						neibs[0]->disBot();
						std::cout << "пошел вверх " << '\n';

					}
					else {
						curWal->disBot(); //вниз
						neibs[0]->disTop();
						std::cout << "пошел вниз " << '\n';

					}
				}
				break;
			case 2:
				curWal->setCurrent(0);
				neibs[1]->setCurrent(1);
				neibs[1]->setVisited();
				wall = neibs[1];
				stack.push_back(wall);
				if (curWal->getX() - neibs[1]->getX() != 0)
				{
					if (curWal->getX() - neibs[1]->getX() < 0) //вправо
					{
						curWal->disRight();
						neibs[1]->disLeft();
						std::cout << "пошел вправо " << '\n';
					}
					else {
						curWal->disLeft(); //вправо
						neibs[1]->disRight();
						std::cout << "пошел влево " << '\n';
					}
				}
				else {
					if (curWal->getY() - neibs[1]->getY() > 0) //вверз //////////////////ИСПАРОВЛЯЮ 
					{
						curWal->disTop();
						neibs[1]->disBot();
						std::cout << "пошел вверх " << '\n';
					}
					else {
						curWal->disBot(); //вправо
						neibs[1]->disTop();
						std::cout << "пошел вниз " << '\n';
					}
				}
				break;
			case 3:
				curWal->setCurrent(0);
				neibs[2]->setCurrent(1);
				neibs[2]->setVisited();
				//Wall* wall;
				wall = neibs[2];
				stack.push_back(wall);
				if (curWal->getX() - neibs[2]->getX() != 0)
				{
					if (curWal->getX() - neibs[2]->getX() < 0) //вправо
					{
						curWal->disRight();
						neibs[2]->disLeft();
						std::cout << "пошел вправо " << '\n';
					}
					else {
						curWal->disLeft(); //вправо
						neibs[2]->disRight();
						std::cout << "пошел влево " << '\n';
					}
				}
				else {
					if (curWal->getY() - neibs[2]->getY() > 0) //вверз
					{
						curWal->disTop();
						neibs[2]->disBot();
						std::cout << "пошел вверх " << '\n';
					}
					else {
						curWal->disBot(); //вправо
						neibs[2]->disTop();
						std::cout << "пошел вниз " << '\n';
					}
				}
				break;
			case 4:
				curWal->setCurrent(0);
				neibs[3]->setCurrent(1);
				neibs[3]->setVisited();
				//Wall* wall;
				wall = neibs[3];
				stack.push_back(wall);
				if (curWal->getX() - neibs[3]->getX() != 0)
				{
					if (curWal->getX() - neibs[3]->getX() < 0) //вправо
					{
						curWal->disRight();
						neibs[3]->disLeft();
						std::cout << "пошел вправо" << '\n';
					}
					else {
						curWal->disLeft(); //вправо
						neibs[3]->disRight();
						std::cout << "пошел влево" << '\n';
					}
				}
				else {
					if (curWal->getY() - neibs[3]->getY() > 0) //вверз
					{
						curWal->disTop();
						neibs[3]->disBot();
						std::cout << "пошел вверх" << '\n';
					}
					else {
						curWal->disBot(); //вправо
						neibs[3]->disTop();
						std::cout << "пошел вниз" << '\n';
					}
				}
				break;
			}
		}
		else {
			if (!stack.empty())
			{
				while (neibs.empty())
				{
					stack.back()->setCurrent(0);
					stack.pop_back();
					std::cout << "Вернулся: " << '\n';
					if (stack.empty())
					{
						return maze;
					}
					stack.back()->setCurrent(1);
					neibs = serchNeibor();
				}

			}
		}
	} while (!stack.empty());
	return maze;
}

void Maze::drawMaze()
{

	for (int i = 0; i < rows; ++i)
	{
		std::cout << "\n";

		for (int j = 0; j < cols; ++j)
		{

			maze[i][j].drawWall(cols,rows);
			//std::cout << '\t';

		}
	}
}

Wall** Maze::getMaze()
{
	return maze;
}

int Maze::getCols()
{
	return cols;
}

int Maze::getRows()
{
	return rows;
}


//-------------------------------------------------------------------------------------------------

class Entity
{
protected:
	int x = 0;
	int y = 0;
	std::string name;
	Texture entTexture;
	Sprite entSprite;
	bool isPlaced = true;
public:
	Entity(Maze maze);
	~Entity();
	void setName(std::string name);
	void draw(Maze maze);
	int getX();
	int getY();
	bool getIsPlased();
	auto searchNeibor(Maze maze);
	void setisPlaced(bool x);
};

Entity::Entity(Maze maze)
{
	auto currentTime = std::chrono::high_resolution_clock::now().time_since_epoch().count();
	std::mt19937 gen(static_cast<unsigned int>(currentTime));// Использование времени в качестве стартового значения для генератора случайных чисел
	std::uniform_int_distribution<int> distribution(0, maze.getCols() - 1);// Определение диапазона случайных чисел (в данном случае, от 1 до 10)
	int randomNumber = distribution(gen);// Генерация случайного числа
	x = randomNumber;
	auto currentTime1 = std::chrono::high_resolution_clock::now().time_since_epoch().count();
	std::mt19937 gen1(static_cast<unsigned int>(currentTime1));// Использование времени в качестве стартового значения для генератора случайных чисел
	std::uniform_int_distribution<int> distribution1(0, maze.getRows() - 1);// Определение диапазона случайных чисел (в данном случае, от 1 до 10)
	int randomNumber1 = distribution1(gen);// Генерация случайного числа
	y = randomNumber1;

}

Entity::~Entity()
{
}

void Entity::setName(std::string name)
{
	this->name = name;
}

void Entity::draw(Maze maze)
{
	if (isPlaced)
	{
		entTexture.loadFromFile("" + name + ".PNG");
		entSprite.setTexture(entTexture);
		entSprite.setPosition(sf::Vector2f(this->x * maze.getCols(), this->y * maze.getRows()));
		window.draw(entSprite);
	}
}

int Entity::getX()
{
	return x;
}

int Entity::getY()
{
	return y;
}

bool Entity::getIsPlased()
{
	return isPlaced;
}

auto Entity::searchNeibor(Maze maze)
{
	Wall** maze1;
	maze1 = maze.getMaze();
	std::vector <Wall> neibors;
	if (y > 0)
	{
		if (!maze1[x][y - 1].getBot() && !maze1[x][y].getTop()) // верх
		{
			neibors.push_back(maze1[x][y - 1]);
		}
	}
	if (y < 19)
	{
		if (!maze1[x][y + 1].getTop() && !maze1[x][y].getBot()) // низ
		{
			neibors.push_back(maze1[x][y + 1]);
		}
	}
	if (x > 0)
	{
		if (!maze1[x - 1][y].getRight() && !maze1[x][y].getLeft())  // лево
		{
			neibors.push_back(maze1[x - 1][y]);
		}
	}
	if (x < 19)
	{
		if (!maze1[x + 1][y].getLeft() && !maze1[x][y].getRight())  // право
		{
			neibors.push_back(maze1[x + 1][y]);
		}
	}
	return neibors;
}

void Entity::setisPlaced(bool x)
{
	isPlaced = x;
}





//------------------------------------------------------------------------------------------------------------
class Enemy : public Entity
{

public:
	Enemy(Maze maze);
	~Enemy();
	void move(Maze maze);
	



};

Enemy::Enemy(Maze maze) : Entity(maze)
{
}

Enemy::~Enemy()
{
}

void Enemy::move(Maze maze)
{
	std::vector <Wall> path;
	path = this->searchNeibor(maze);
	auto currentTime = std::chrono::high_resolution_clock::now().time_since_epoch().count();
	std::mt19937 gen(static_cast<unsigned int>(currentTime));// Использование времени в качестве стартового значения для генератора случайных чисел
	std::uniform_int_distribution<int> distribution(0, path.size()-1);// Определение диапазона случайных чисел (в данном случае, от 1 до 10)
	int randomNumber = distribution(gen);// Генерация случайного числа
	switch (randomNumber)
	{
	case 0:	
		if (x - path[0].getX() != 0)
		{
			if (x - path[0].getX() < 0) //вправо
			{
				x = path[0].getX();
				y = path[0].getY();
				this->setName("enemyRight");
			}
			else {
				x = path[0].getX();
				y = path[0].getY();
				this->setName("enemyLeft");
			}
		}
		else {
			if (y - path[0].getY() > 0) //вверх
			{
				x = path[0].getX();
				y = path[0].getY();
				this->setName("enemyTop");

			}
			else {
				x = path[0].getX();
				y = path[0].getY();
				this->setName("enemyBot");

			}
		}
		break;
	case 1:
		if (x - path[1].getX() != 0)
		{
			if (x - path[1].getX() < 0) //вправо
			{
				x = path[1].getX();
				y = path[1].getY();
				this->setName("enemyRight");
			}
			else {
				x = path[1].getX();
				y = path[1].getY();
				this->setName("enemyLeft");
			}
		}
		else {
			if (y - path[1].getY() > 0) //вверх
			{
				x = path[1].getX();
				y = path[1].getY();
				this->setName("enemyTop");

			}
			else {
				x = path[1].getX();
				y = path[1].getY();
				this->setName("enemyBot");

			}
		}
		break;
	case 2:
		if (x - path[2].getX() != 0)
		{
			if (x - path[2].getX() < 0) //вправо
			{
				x = path[2].getX();
				y = path[2].getY();
				this->setName("enemyRight");
			}
			else {
				x = path[2].getX();
				y = path[2].getY();
				this->setName("enemyLeft");
			}
		}
		else {
			if (y - path[2].getY() > 0) //вверх
			{
				x = path[2].getX();
				y = path[2].getY();
				this->setName("enemyTop");

			}
			else {
				x = path[2].getX();
				y = path[2].getY();
				this->setName("enemyBot");

			}
		}
		break;
	case 3:
		if (y - path[3].getY() > 0)
		{
			if (x - path[3].getX() < 0) //вправо
			{
				x = path[3].getX();
				y = path[3].getY();
				this->setName("enemyRight");
			}
			else {
				x = path[3].getX();
				y = path[3].getY();
				this->setName("enemyLeft");
			}
		}
		else {
			if (y - path[3].getY() != 0) //вверх
			{
				x = path[3].getX();
				y = path[3].getY();
				this->setName("enemyTop");

			}
			else {
				x = path[3].getX();
				y = path[3].getY();
				this->setName("enemyBot");

			}
		}
		break;
	default:
		break;
	}

}



//------------------------------------------------------------------------------------------------------------

class Player : public Entity
{

public:

	Player(Maze maze);
	~Player();
	void move(sf::Event event, Maze maze);
	//void win(Door door);
	void shoot(Enemy *enemy, sf::Event event, Maze maze);
	bool isMeet(Enemy enemy);
	
};

Player::Player(Maze maze) : Entity(maze)
{

}

Player::~Player()
{
}

void Player::move(sf::Event event, Maze maze)
{
	Wall** maze1;
	maze1 = maze.getMaze();
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Left)) {
		if(!maze1[x][y].getLeft() && x > 0)
		{ 
			setName("pkayerleft2");
		--x;
		}
	}
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Right)) {
		if (!maze1[x][y].getRight() && x < 19)
		{
			setName("pkayerRight2");
			++x;
		}
	}
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Up)) {
		if (!maze1[x][y].getTop() && y > 0)
		{
			setName("pkayerTop2");
			--y;
		}
	}
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::Down)) {
		if (!maze1[x][y].getBot() /*&& y < 19*/)
		{
			setName("pkayerBot2");
			++y;
		}
	}

}

void Player::shoot(Enemy *enemy, sf::Event event, Maze maze)
{
	
	//Enemy* enemy1 = &enemy;
	//std::cout << &enemy << '\n' << enemy1;
	if (sf::Keyboard::isKeyPressed(sf::Keyboard::LShift)) {
		for (int i = 0; i < searchNeibor(maze).size(); ++i)
		{
			if (searchNeibor(maze)[i].getX() == enemy->getX() && searchNeibor(maze)[i].getY() == enemy->getY())
			{
				enemy->setisPlaced(false);
			}
			
		}
	}
}

bool Player::isMeet(Enemy enemy)
{
	if (enemy.getX() == this->x && enemy.getY() == this->y && enemy.getIsPlased())
	{
		return true;
	}
	else {
		return false;
	}
}

//------------------------------------------------------------------------------------------------------------

class Key : public Entity
{
private:
public:
	Key(Maze maze);
	~Key();
	void isCollect(Player player);


};

Key::Key(Maze maze) : Entity(maze)
{
}

Key::~Key()
{
}

void Key::isCollect(Player player)
{
	if (player.getX() == x && player.getY() == y)
	{
		isPlaced = false;
	}
}
//------------------------------------------------------------------------------------------------------------

class Door : public Entity
{
private:
	bool isDoorOpen = false;
public:
	Door(Maze maze);
	~Door();
	void isOpen(Key key);
	bool getIsDoorOpen();

};

Door::Door(Maze maze) :  Entity(maze)
{
}

Door::~Door()
{
}

void Door::isOpen(Key key)
{
	if (!key.getIsPlased())
	{
		name = "doorClose";
		isDoorOpen = true;
	}
}

bool Door::getIsDoorOpen()
{
	return isDoorOpen;
}

//------------------------------------------------------------------------------------------------------------
//class Factory
//{
//public:
//	virtual Entity* createEntity() = 0;
//	virtual ~Factory() {}
//};
//
//class EnemyFactory : public Factory
//{
//public:
//	Entity* createEntity(Maze maze) {
//		return new Enemy(maze);
//	}
//};
//
//class PlayerFactory : public Factory
//{
//public:
//	Entity* createEntity(Maze maze) {
//		return new Player(maze);
//	}
//};
//
//class DoorFactory : public Factory
//{
//public:
//	Entity* createEntity(Maze maze) {
//		return new Door(maze);
//	}
//};
//
//class KeyFactory : public Factory
//{
//public:
//	Entity* createEntity(Maze maze) {
//		return new Key(maze);
//	}
//};



int main()
{
	setlocale(LC_ALL, "Russian");
	int k = 0;
	Maze maze1;
	maze1.currentWall(true);
	maze1.move();
	//-------------------
	Player player(maze1);
	player.setName("pkayerBot1");
	Door door(maze1);
	door.setName("doorOpen");
	Key key(maze1);
	key.setName("key");
	Enemy enemy(maze1);
	enemy.setName("enemyBot");
	//--------------------------
	/*PlayerFactory* PlayerFactory = new PlayerFactory(maze1);
	ArchersFactory* archers_factory = new ArchersFactory;
	CavalryFactory* cavalry_factory = new CavalryFactory;*/

	
	while (window.isOpen()) // цикл обработки событий, пока окно программы не закрыто
	{
		sf::Event event; // описываем объект события
		while (window.pollEvent(event)) // получаем событие из очереди
		{
			if (event.type == sf::Event::Closed) // проверяем, если это закрытие окна, то закрываем окно
				window.close();
		}
		
		
		window.clear(sf::Color::Blue); // очищаем окно
		maze1.drawMaze();
		key.draw(maze1);
		door.draw(maze1);
		enemy.draw(maze1);
		player.move(event,maze1);
		player.draw(maze1);
		player.shoot(&enemy, event, maze1);
		if (k == 40)
		{
			enemy.move(maze1);
			k = 0;
		}
		key.isCollect(player);
		door.isOpen(key);
		if (player.isMeet(enemy))
		{
			window.clear(sf::Color::Black);
			break;
		}
		if (door.getIsDoorOpen() && door.getX() == player.getX() && door.getY() == player.getY())
				{
			window.clear(sf::Color::Black);
					break;
				}
		sleep(sf::milliseconds(40));
		window.display();  // отрисовка буфера экрана в окне
		++k;

	}
	

	


	
	
}

