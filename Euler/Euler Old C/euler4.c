#include<stdio.h>
#include<math.h>

int palindrome(int);
int reverse(int tab[], int size);

int main() {
int i;
int j;
for (i = 999; i > 900; i--)
	for (j = 999; j > 900; j--)
		if (palindrome(i*j)) printf("%d * %d = %d\n", i, j, i*j);
//palindrome(821808);
}

int palindrome(int n) 
{
	int i = 0;
	int m = n;
	int copy = n;
	while (m > 0) {
		m /= 10;
		i++;
	}
	//printf("Liczba %d cyfrowa: %d\n", i, n);
	int a[i];
	m = i;
	i = 0;
	while (n > 0) {
		a[i] = n % 10;
		//printf("%d, ", a[i]);
		n = n - a[i];
		n = n / 10;
		i++;
	}
	//printf("\n");
	if(reverse(a, m) == copy) return 1;
	//for (i = 0; i < m; i++)
		//printf("%d, ", a[i]);
	//printf("\n");	
	return 0;
}

int reverse(int tab[], int size) 
{
	int tmp;
	int i;
	for(i = 0; i < size/2; i++) {
		tmp = tab[i];
		tab[i] = tab[size - 1 - i];
		tab[size - 1 - i] = tmp;
	}
	tmp = 0;
	for(i = 0; i < size; i++) {
		tmp += tab[i]*pow(10,i);
	}
	return tmp;
}