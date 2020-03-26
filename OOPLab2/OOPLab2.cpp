#include "Classes.h"
using namespace std;
int main()
{
	Ustring str1("Richard");
	Ustring str2("hits you");
	Text story;
	story.addLine(str1);
	story.addLine(str2);
	cout << story << endl;
	return 0;
}
