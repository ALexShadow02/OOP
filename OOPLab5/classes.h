#include <iostream>
#include <cassert>
#include <vector>
using namespace std;
struct Coord {
	double x;
	double y;
};
class Line {
protected:
	Coord beg;
	Coord end;
public:
	Line(Coord begi, Coord endi) :beg(begi), end(endi) {
	}
	float GetLength() {
		return sqrt(pow(end.x - beg.x, 2) + pow(end.y - beg.y, 2));
	}
};
class LineSeg :public Line {
	float angle;
public:
	LineSeg(Coord begi, Coord endi) :Line(begi, endi) {
		angle = GetAngle();
	}
	float GetAngle() {
		return atan2(abs(end.y - beg.y), end.x - beg.x);
	}
	void GetData() {
		cout << "The coordinates are (" << beg.x << ";" << beg.y << ") and (" << end.x << ";" << end.y << ")" << endl;
		cout << "The length is " << GetLength() << endl;
		cout << "The angle is " << GetAngle() << endl;
	}
};
class Ustring {
protected:
	vector<char> syms;
	int length;
public:
	Ustring() {
		syms.resize(0);
		length = 0;
	}
	Ustring(string wor) {
		for (int i = 0; i < wor.length(); i++) syms.push_back(wor[i]);
		length = wor.length();
	}
	char GetSym(int ind) {
		assert(ind >= 0 && ind < length);
		return syms[ind];
	}
	void EraseSym(int ind) {
		assert(ind >= 0 && ind < length);
		syms.erase(syms.begin() + ind);
		length--;
	}
	void virtual AddSym(char sym) {
		syms.push_back(sym);
		length++;
	}
	int GetLen() {
		return length;
	}
	void Print() {
		for (char sym : syms) cout << sym;
	}
	char operator[](int index) {
		assert(index >= 0 && index <= length - 1);
		return syms[index];
	}
	friend ostream& operator<<(ostream &out,const Ustring &str) {
		for (const char sym : str.syms) out << sym;
		return out;
	}
};
class UpperString : public Ustring {
public:
	UpperString():Ustring() {
	}
	UpperString(string wor) {
		for (int i = 0; i < wor.length(); i++) syms.push_back(toupper(wor[i]));
		length = wor.length();
	}
	void AddSym(char sym) {
		syms.push_back(toupper(sym));
		length++;
	}
};
class LowerString : public Ustring {
public:
	LowerString() :Ustring() {
	}
	LowerString(string wor) {
		for (int i = 0; i < wor.length(); i++) syms.push_back(tolower(wor[i]));
		length = wor.length();
	}
	void AddSym(char sym) {
		syms.push_back(tolower(sym));
		length++;
	}
};