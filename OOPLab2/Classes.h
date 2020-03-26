#include <iostream>
#include <cassert>
#include <cstring>
#include <vector>
using namespace std;
/*class Ustring {
private:
	int length;
	char* data;
public:
	Ustring():length(0),data(nullptr) {
	}
	Ustring(int len) :length(len) {
		assert(len >= 0);
		if (len > 0) data = new char[len + 1];
		else data = nullptr;
	}
	Ustring(int len,string word):length(len) {
		assert(len >= 0);
		assert(len==word.length());
		if (len > 0) {
			data = new char[len + 1];
			for (int i = 0; i < word.length(); i++) data[i] = word[i];
		}
		else data = nullptr;
	}
	char getSym(int index) {
		assert(index <= length - 1);
		return data[index];
	}
	void Erase() {
		delete[] data;
		data = nullptr;
		length = 0;
	}
	int getLength() {
		return length;
	}
	void newSize(int size) {
		Erase();
		if (size <= 0) return;
		data = new char[size];
		length = size;
	}
	char operator[](int index) {
		assert(index >= 0 && index <= length - 1);
		return data[index];
	}
	void operator=(const char word[]) {
		for (int i = 0; i < length; i++) {
			data[i] = word[i];
		}
	}
	void print() {
		for (int l = 0; l < length; l++) cout << data[l];
	}
	~Ustring() {
		delete[] data;
	}
};*/
class Ustring {
	vector<char> syms;
	int length = 0;
public:
	Ustring(string wor) {
		for (int i = 0; i < wor.length(); i++) syms.push_back(wor[i]);
		length = wor.length();
	}
	char getSym(int ind) {
		assert(ind > 0 && ind <= length);
		return syms[ind-1];
	}
	void eraseSym(int ind) {
		assert(ind > 0 && ind <= length);
		syms.erase(syms.begin()+ind-1);
	}
	void addSym(char sym) {
		syms.push_back(sym);
	}
	int getLen() {
		return length;
	}
	void print() {
		for (char sym : syms) cout << sym;
	}
	friend ostream& operator<<(ostream &out,Ustring str) {
		for (int i = 0; i < str.length;i++) {
			out << str.syms[i];
		}
		return out;
	}
};
class Text {
	vector<Ustring> lines;
	int num_lines=0;
public:
	int getNumLines() {
		return num_lines;
	}
	void addLine(Ustring str) {
		lines.push_back(str);
		num_lines++;
	}
	void delLine(int line) {
		assert(line > 0 && line <= num_lines);
		lines.erase(lines.begin() + line-1);
	}
	void delBeg() {
		lines.erase(lines.begin());
	}
	void delEnd() {
		lines.pop_back();
	}
	Ustring getLine(int in) {
		assert(in > 0 && in <= num_lines);
		return lines[in-1];
	}
	void printLine(int in) {
		assert(in > 0 && in <= num_lines);
		lines[in-1].print();
	}
	void print() {
		for (Ustring& lin : lines) {
			lin.print();
			cout << endl;
		}
	}
	friend ostream& operator<<(ostream& out, Text &txt) {
		for (int i = 0; i < txt.num_lines; i++) {
			out << txt.lines[i]<<endl;
		}
		return out;
	}
};