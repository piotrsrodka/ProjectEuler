#include<iostream>
#include<ctime>
using namespace std;
int main() {
const int N = 30000;
long max = 500;
for(int i = 1; i < N; i++) {
	long long triangle = i*(1+i)/2;
	//cout << triangle << ": ";
	int count = 0;
	for(long j = 1; j*j <= triangle; j++) {
		if (triangle % j == 0) {
			count+=2;
			//cout << j << ", " << triangle/j << ", ";
			if (count > max) {
				cout << i << ", " << triangle <<": "<< count << endl;
				max = count;
				goto finish;
			}
		}
	}
}
finish:
cout << clock()/float(CLOCKS_PER_SEC) << " s" << endl;
return 0;
}