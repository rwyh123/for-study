#pragma once
#include "Maze.h"
#include <string>
#include "SFML/Graphics.hpp"
#include <vector>
#include "Background.h"
#include "Dashboard.h"
using std::string;

// ����� ����
static class Game
{
	// �������� ���������� �� ������������ ��������� �������, ��� ������� ���� �����
	static int timerTickCounter;
	// ������� ����������� ����
	static Background background;
public:
	static vector<string> levelMap; // ����� ������
	static sf::RenderWindow window; // ���� ����������
	static Dashboard dashboard; // ������ ����������� ����
	// -------------- ��������������� ���� ��� �������, ���������� ��������� �������� ������� ����
	static int walls;
	static int players;
	static int doors;
	static int coins;
	static int bullets;
	static int diamonds;
	static int times;
	static int bonusthief;
	static int timefag;
	static int monster;
	
	// ----------------------------
	static Maze maze; // ��������
	static int score; // ����
	static int timeLeft; // ������� ������� �� �������
	static bool isOver; // ������� ����� ����
	static sf::Event event; // ����� ������� SFML, ������������ ��� ��������� ������� ������
	static void CreateGameWindow(); // ������� ���� ����
	static void StartGame(); // ��������� ����
	static void PaintScene(); // ������������ � ���� ����� ����
	static void TimerTick(); // ���������� ������� �������� � �������� �������� �� ������ � ������ ��������
};

