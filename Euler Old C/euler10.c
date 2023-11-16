#include<stdio.h>
#include<stdlib.h>

int main() 
{
	const long N = 2000000;
	short *a;
	
	a = (short*)malloc(N*sizeof(short));
	
	if (a == NULL) {
		printf("malloc error");
		return -1;
	}
	
	long i,j;
	long count = 0;
	double suma = 0.0;
	a[1] = 1;
	for(i = 2; i < N; i++) 
	{
		a[i] = 0;
	}
	
	for(i = 2; i < N; i++) 
	{
		if (a[i] == 1) continue;
		count++;
		suma += i;
		for(j = 2*i; j < N; j += i)
		{
			a[j] = 1;
		}
	}
	printf("%.0f\n",suma);
	
	return 0;
}