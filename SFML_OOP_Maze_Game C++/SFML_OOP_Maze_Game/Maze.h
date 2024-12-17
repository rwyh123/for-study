#pragma once
#include <vector>
#include "Animation.h"

using std::vector;

class Maze
{
	int width; // ������ ���������
	int height; // ������ ���������
	sf::Vector2f position{ 0, 0 }; // ������� ��������� ��������� � ����
public:
	int cellSize = 24; // ������ ������ �������� ���� � ��������
	vector<Animation> animations; // ������ �������� ��� ������� �� �������� �� ��������� ���� ����
	vector<vector<GameObject*>> levelMap; // ��������� ������ ���������� �� ������� �������. ���������� ��� � ���� ������� ������� ���� � ����������� ���������

	void SetPosition(sf::Vector2f position); // ������������� ������� ��� ����������� ��������� � ����
	int GetWidth(); // �������� ������ ���������
	int GetHeight(); // �������� ������ ���������
	void CreateMap(vector<string>& levelMap); // ������� ����� ������
	void ClearMap(); // ������� ����� ������
	void BeginAct(); // ������ ���������� ���� ����, �� ������ ����� ��� ������� �������� ����� ���������� ������������ �� ���������� ��������
	void EndAct(); // ���������� ���� ����, ���������� ������ ����, ����������� ��� ���, ��� ����, ��� ����������� � �.�.
	void AddAnimation(const GameObjectCommand& command, GameObject* object, int x, int y); // ���������� ������� � ���� � �������� �������� ����

private:
	// ���������� ������ ���� ������������ �� ���������� ������� �������
	// �������� 2 ������� ��������� �� ��������� ���� � ����� ������
	// ��� ��� �������� ����������� �� ���������� ���� �������
	std::vector<vector<vector<GameObject*>>> GetCandidatesPerLocation(); 
	// ����������, ��� �� ���������� �� ���������� ������� �������� ��� ��� ������� ��������� �������, ��� ��� ��� �����
	GameObject* SelectWinnerCandidatePerLocation(std::vector<vector<vector<GameObject*>>>& objects, int x, int y);
};

