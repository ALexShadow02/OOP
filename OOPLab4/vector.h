#include <iostream>
using namespace std;
class Vector {
	float x;
	float y;
public:
	Vector() :x(0.0), y(0.0) {
	}
	Vector(float xc, float yc) :x(xc), y(yc) {
	}
	Vector(const Vector& vec) :x(vec.x), y(vec.y) {
	}
	float length() {
		return sqrt(x * x + y * y);
	}
	void GetData() {
		cout << "The coordinates are (" << x << ";" << y << ")" << endl;
		cout << "The length is " << length() << endl;
	}
	friend Vector operator*(Vector vec,float num) {
		return Vector(vec.x*num,vec.y*num);
	}
	friend Vector operator*(float num,Vector vec) {
		return Vector(vec.x * num, vec.y * num);
	}
	friend Vector operator*=(Vector vec,float num) {
		return Vector(vec.x * num, vec.y * num);
	}
	friend Vector operator-(Vector vec1,Vector vec2) {
		return Vector(vec1.x-vec2.x,vec1.y-vec2.y);
	}
};