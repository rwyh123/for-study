#pragma once
#include "SFML/Graphics.hpp"
#include <string>

// �����, ������������ ��� �� ������� ����
class Background
{
	sf::Texture texture; // �������� ����
	sf::Sprite sprite; // ������ ����
public:
	Background(std::string fileName); // ����������, ������� ��� �� ����� �����������
	virtual void Draw(sf::RenderWindow& window); // ������������ ��� � ������ �����
	sf::FloatRect GetSize(); // ���������� ������ ����
};

