#include<stdio.h>

int main() {
	const int N = 500000; //I shoot the number
	short a[N+1];
	int i,j;
	int count = 0;
	for(i = 2; i < N; i++) a[i] = 0;

	for(i = 2; i < N; i++) {
		if (a[i] == 1) continue;
		count++;
		for(j = 2*i; j < N; j += i) {
			a[j] = 1;
			if (count == 10001) {
				printf("%d\n", i);
				break;
			}
		}
	}
}