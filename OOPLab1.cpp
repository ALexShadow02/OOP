#include <iostream>
#include "Functions.h"
using namespace std;
int main()
{
	int n;
	cout << "Enter a number for incrementing :" << endl; cin >> n;
	cout << increment(n) << endl;
	cout << "Enter two int numbers for checking if they're equal:" << endl;
	int f; int s;
	cin >> f; cin >> s;
	equal(f, s) == 1 ? cout << "They're equal" << endl : cout << "They're not equal" << endl;
	return 0;
}