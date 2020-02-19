//Находим позицию самой правой единички
int getPos(int num) {
	return log2(num & -num);
}
int toggleLastBits(int &n, int &k) {
	int num = (1 << k) - 1;
	return (n ^ num);
}
int increment(int &n)
{
	int k = getPos(~n);
	n = ((1 << k) | n);
	if (k != 0)
		n = toggleLastBits(n, k);
	return n;
}
bool equal(int &n1,int &n2) {
	int xoro = n1 ^ n2;
	return xoro == 0 ? true : false;
}