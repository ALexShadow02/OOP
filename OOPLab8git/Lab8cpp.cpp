#include <iostream>
using namespace std;
int add(int,int);
int mult(int,int);
int main()
{
	int (*delegate)(int,int) = add;
	cout << delegate(3,17) << endl;
	delegate = mult;
	cout << delegate(5,20) << endl;
}
int add(int a,int b) {
	return a + b;
}
int mult(int a,int b) {
	return a * b;
}