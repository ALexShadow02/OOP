#include "vector.h"
int main()
{
	Vector V1;
	Vector V2(3.7,6.1);
	Vector V3(V2);
	V2=V2*2;
	V1 = V3 - V2;
	V1.GetData();
	return 0;
}
