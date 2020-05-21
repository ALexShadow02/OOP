#include "classes.h"
int main()
{
	Coord beg = {2.16,1.08};
	Coord end = {1.04,3.19};
	LineSeg sega(beg,end);
	sega.GetData();
	UpperString name1("rObert");
	LowerString name2("RobERt");
}
