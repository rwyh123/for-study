#pragma once

// ����������� �����
struct Point
{
	int x, y;
	Point(int x, int y) : x(x), y(y) {}
	Point() : x(0), y(0) {}
};

bool operator < (const Point& p1, const Point& p2);


