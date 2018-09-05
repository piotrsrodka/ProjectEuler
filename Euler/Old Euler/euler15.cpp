#include<iostream>
#include<ctime>

using namespace std;

int main() {
double k = 20.0;
double result = 2.0;
for(double i = 1.0; i < k; i = i + 1.0) {
	result *= (k+i)/i;
}
cout << (long long)(result) << endl;
cout << 1000.0*clock()/float(CLOCKS_PER_SEC) << " ms" << endl;

return 0;
}