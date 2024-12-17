#include "Game.h"
#include "GameObjectsFactory.h"

vector<string> Game::levelMap{
		"WWWWWWWWWWWWWWWWWWWW",
		"WWWWWWW    C       D",
		"WWWWWWWCWWWWWWWWWWWW",
		"WWWWWWW WWWWWWWWWWWW",
		"WWWWWWW WWWWWWWWWWWW",
		"WWWWWWW WWWWWWWWWWWW",
		"WWWWWWW WWWWWWWWWWWW",
		"WWWWWWW WWWWWWWWWWWW",
		"WWWWWWW WWWWWWWWWWWW",
		"WWWWWWW WWWWWWWWWWWW",
		"W   M  C     WWWWWWW",
		"WWWWWWWWWWWW WWWWWWW",
		"WWWWWWWWWWWW WWWWWWW",
		"WWWW    C    WWWWWWW",
		"WWWWWWWWWWWW WWWWWWW",
		"WWWWWWWWWWWW WWWWWWW",
		"WWWWWWWWWWWW WWWWWWW",
		"WWWWWWWWWWWW WWWWWWW",
		"WW  E T  P Y      WW",
		"WWWWWWW  S    C WWWW",
		"WWWWWWWWWWWWWWWWWWWW",
	};

sf::Event Game::event;
int Game::walls = 0;
int Game::players = 0;
int Game::doors = 0;
int Game::coins = 0;
int Game::diamonds = 0;
int Game::times = 0;
int Game::bonusthief = 0;
int Game::timefag = 0;
int Game::monster = 0;
sf::RenderWindow Game::window;
Dashboard Game::dashboard;
Maze Game::maze;
int Game::score = 0;
int Game::timeLeft = 60000;
bool Game::isOver = false;
int Game::timerTickCounter = 0;
Background Game::background("assets\\background\\background.jpg");

void Game::CreateGameWindow()
{
	auto size = background.GetSize();
	// ������������� ������ �� ������������� ������� - ��������� ��� �������� �����������.
	int sizeX = size.width > maze.GetWidth() * maze.cellSize ? (int)size.width : maze.GetWidth() * maze.cellSize;
	int sizeY = size.height > maze.GetHeight() * maze.cellSize ? (int)size.height : maze.GetHeight() * maze.cellSize;
	window.create(sf::VideoMode(sizeX, sizeY), "SFML Maze game");
	window.setFramerateLimit(10);
	GameObject::SetRenderWindow(&window);
	// ����������� ������� ��������� � ����
		// ������� "����������" �������� �� ������� ����, ��� ����� ����� ��������� ����������
	// �������� ������ ���� ���������. ��� ����� ������� �������� ������� ���� ����
	sf::Vector2u wSize = window.getSize();
	// ��� ����� ������� � �������� ������ ���� ��������� ������ ����?
	// ���� ������ ���� �������� �� 2 � ������� �� ����������� �������� �������� ������ ���������
	float xMaze = wSize.x / 2 - maze.GetWidth() * maze.cellSize / 2;
	// ���������� ��������� � �
	float yMaze = wSize.y / 2 - maze.GetHeight() * maze.cellSize / 2;
	// ����� ���������� ��� ���������� � �������� ������� ����� ��� ������ ���������
	maze.SetPosition(sf::Vector2f(xMaze, yMaze));
}

void Game::StartGame()
{
	CreateGameWindow();
	int timeLeftInSec = Game::timeLeft / 1000;
	dashboard.AddItem(new DashboardItem("assets\\bitmaps\\score.png", "assets\\fonts\\Grotesque-Bourgeoisie.ttf", &Game::score));
	dashboard.AddItem(new DashboardItem("assets\\bitmaps\\timer.png", "assets\\fonts\\Grotesque-Bourgeoisie.ttf", &timeLeftInSec));
	sf::Clock clock;
	while (window.isOpen()  && !isOver)
	{
		// ������������ ������� ������� � �����
		if (window.pollEvent(event))
		{
			// ������������ ����� �� �������� � ����� ������� ����?
			if (event.type == sf::Event::Closed)
				// ����� ��������� ���
				window.close();
		}
		// ��������� ����
		TimerTick();
		window.display();
		if (timerTickCounter == 0)
		{
			Game::timeLeft -= clock.getElapsedTime().asMilliseconds();
			timeLeftInSec = Game::timeLeft / 1000;
			clock.restart();
			if (Game::timeLeft <= 0)
			{
				Game::timeLeft = 0;
				Game::isOver = true;
			}
		}
	}
	maze.ClearMap();
}

void Game::PaintScene()
{
	window.clear();
	background.Draw(window);
	for (auto& a : maze.animations)
	{
		if (a.gameObject != nullptr)
			a.gameObject->Draw(a.location);
	}
	dashboard.Draw(window, sf::Vector2f(0, 0));
}

void Game::TimerTick()
{
	if (timerTickCounter == 0) maze.BeginAct();
	for (auto& e : maze.animations)
	{
		e.location = sf::Vector2f(e.location.x + 8 * e.command.deltaX, e.location.y + 8 * e.command.deltaY);
	}
	if (timerTickCounter == 2)
		maze.EndAct();
	timerTickCounter++;
	if (timerTickCounter == 3) timerTickCounter = 0;
	PaintScene();
}
