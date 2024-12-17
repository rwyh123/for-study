#pragma once
#include "SFML/graphics.hpp"
#include <string>
using std::string;
// ����������� �������� ���������
struct GameObjectCommand;


// ������� ����������� �����, ����������� ���������� ����� ������� ��������
class GameObject
{
public:
	static sf::RenderWindow* window;
	static void SetRenderWindow(sf::RenderWindow* w);
	// ����� ��������� �������
	virtual void Draw(sf::Vector2f position) = 0;
	// �����, ������������ ��������� ������� �� ��������� ���� ����
	// �, � - ���������� ������� � ������� ����, event - ������� ����������, ������� ������ ����� ����������
	virtual GameObjectCommand Act(int x, int y, sf::Event event) = 0;
	// ���������� ��� �������
	virtual string GetName() = 0;
	// ����������, ����� �� ������ ��� ������������ � ������ ��������, ���� ��� �������� � ����� ������
	virtual bool DeadInConflict(GameObject* conflictedObject) = 0;
	// ��������� ���������, ������ �� ���������� �������� �� ������
	virtual int GetDrawingPriority() = 0;
	virtual ~GameObject() {};
};

