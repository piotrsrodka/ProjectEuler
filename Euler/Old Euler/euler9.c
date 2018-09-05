#include<stdio.h>
int main() {
	int a, b, c;
	a = 3;
	b = 4;
	c = 5;
	while(a<b && a<1000) {
		a++;
		b = a;
		while(b<c && b < 1000) {
			b++;
			c = b;
			while(c<1000) {
				if ((a+b+c == 1000) && (a*a + b*b == c*c))
					printf("%d, %d, %d\n",a,b,c);
				c++;
			}
		}
	}
}