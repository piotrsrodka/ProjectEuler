#include<iostream>
#include<ctime>

using namespace std;

int main() {
const long million = 1000000;
long long n;
long max = 1;
long count;
int max_number;
long long biggest = 1;
for(int i = 1; i < million; i+=2) {
	n = i;
	count = 1;
	while (n > 1) {
		if (!(n % 2)) n = n / 2;
		else n = 3 * n + 1;
		if (n > biggest) biggest = n;
		count++;
	}
	if (count > max) {
//		cout << i << ": " << count << endl;
		max = count;
		max_number = i;
	}
}
cout << max_number << ": " << max << " with " << biggest << endl;
cout << clock()/float(CLOCKS_PER_SEC) << " s" << endl;
return 0;
}