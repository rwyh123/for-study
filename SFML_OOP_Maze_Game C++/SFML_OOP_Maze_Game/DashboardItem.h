#pragma once
#include "SFML/Graphics.hpp"
#include <string>
using std::string;

//����� - ������� ���������
class DashboardItem
{
	sf::Texture texture; // ��������, ������������ ������� ��� ����������
	sf::Sprite sprite; // ������, ��������� �� ��������
	sf::Font font; // ����� ��� ����������� ������ ����������
	sf::Text text;	// ������ ��� ����������� ������ ����������
	int* value;
public:
	// ����������� �������� ����������, observedValue - ��������� �� ����������, ������� ����������� ��������� � ������������ ���������
	DashboardItem(const string& textureFile, const string& fontFile, int* observedValue);
	// ������������ ��������� �� ������
	virtual void Draw(sf::RenderWindow& window, sf::Vector2f position);
	// ���������� ������ ������� ����������
	sf::FloatRect GetSpriteSize();
};

