#include <iostream>
#include <cstdlib>
#include <ctime>
using namespace std;
class Expression final {
public:
	double a, c, d;
	Expression(double _a, double _c, double _d) {
		a = _a;
		c = _c;
		d = _d;
	}
	double GetValue() {
		if (a >= 4 || a == 0) throw - 1;
		return (2 * c - d / 23) / (log(1 - a / 4));
	}
};
int main()
{
	srand(time(0));
	try {
		Expression exp(rand()%5+1,rand()%10+1,rand()%10+1);
		cout<<exp.GetValue()<<endl;
    }
	catch (int err) {
		cout << "Invalid operand 'a' in the expression" << endl;
	}
}
