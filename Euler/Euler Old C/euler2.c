#include<stdio.h>
int main() {
int n[40] = {1, 2};
int suma = 2;
int i = 2;
printf("%d, %d\n",1, n[0]);
printf("%d, %d\n",2, n[1]);
do {
	n[i] = n[i-1] + n[i-2];
	if (n[i] > 4000000) break;
	if (n[i] % 2 == 0) suma += n[i];
	printf("%d, %d, %.0f\n", i+1, n[i], suma);
	i++;	
} while(1);
printf("%d\n",suma);
}