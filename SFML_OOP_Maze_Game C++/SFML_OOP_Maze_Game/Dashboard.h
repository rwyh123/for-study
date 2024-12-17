#pragma once
#include "SFML/Graphics.hpp"
#include <vector>
#include "DashboardItem.h"
using std::vector;

// �����, ����������� ��������� ������� �����������
// ��������� ��������� ��������� � ������, ������������ ������ � ������������
class Dashboard
{
	vector<DashboardItem*> items; // ������ �����������
public:
	Dashboard();
	virtual ~Dashboard();
	virtual void Draw(sf::RenderWindow& window, sf::Vector2f position); // ��������� ������
	void AddItem(DashboardItem* item); // ��������� ��������� �� ������
};

