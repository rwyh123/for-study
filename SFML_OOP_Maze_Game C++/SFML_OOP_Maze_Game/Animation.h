#pragma once
#include "SFML/Graphics.hpp"
#include "GameObjectCommand.h"
#include "GameObject.h"
#include "Point.h"

// �������� �������� ��� �������.
// � �������� ����������� �� ����� ������ � ������ ������ ����� ���� ���������� (�������, � �� ���������� �����������)
struct Animation
{
    // �������, ����������� �������� � ��������� ����
    GameObjectCommand command;
    // ��������� �� ������� ������
    GameObject* gameObject;
    // �������, ��� ������ ���� ��������� ������ (������������ ��� ��������)
    sf::Vector2f location;
    // �������� ������� ������� �� ������� ���� �� ��������� ���� ����
    Point targetLogicalLocation;
};

