#pragma once
#include "GameObject.h"

// �����-�������, ��������� ��������� ������� �������
class GameObjectsFactory
{
public:
	static GameObject* CreateObjectInstance(char objectType); // ������� ������� ������ �� ��� ����������� ����������� �� �����
};