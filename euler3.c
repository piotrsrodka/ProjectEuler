#include<stdio.h>
#include<math.h>
int modulo(double a, double b);
double epsilon();

int main() {
double n = 600851475143.0;
double i;
i = 2.0;
while (i <= n) {
	if (!modulo(n, i)) {
		printf("%.0f %% %.0f = %d\n",n,i,modulo(n, i));
		n /= i;
	}
	i = i + 1.0;
}
}

int modulo(double a, double b) {
if (a/b - floor(a/b) < epsilon()) return 0;
return 1;
}

double epsilon() {
double x = 1.0;
while (1.00 + x != 1.00) {
	x /= 2.0;
}
return 2.0*x;
}