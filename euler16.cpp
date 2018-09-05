#include<iostream>
#include<ctime>
#include<cmath>
#include<cstdio>
#include<cstdlib>
#include<cstring>
using namespace std;

void reverse(short liczba[], int n);
string gramatyka(int);
void elapsed(void);
long long suma(short * a, int n);

int main() {

const int LEN = 400;
int len;
short liczba[LEN];
short mem;
int power;

// Ustaw tablicê na wartoœci ujemne poza liczb¹
for (int i = 0; i < LEN; i++)
	liczba[i] = -1;

liczba[0] = 2;

power = 2;
while(power <= 1000) {

// Policz liczbê cyfr liczby
for (len = 0; len < LEN; len++) 
	if (liczba[len] == -1) break;
//cout << "Liczba ma " << len << " cyfr"+gramatyka(len) << endl;
	
// Wypisz liczbê
//cout << "Liczba: ";
//for (int i = 0; i < len; i++)
//	cout << liczba[i];
//cout << endl;

//cout << "Mnozenie razy dwa..." << endl;

// Odwróæ tablicê (bo ³atwiej mno¿yæ od ty³u)
reverse(liczba, len);

// Mno¿enie
mem = 0;
for (int i = 0; i < len; i++) {
	liczba[i] = liczba[i] * 2 + mem;
	mem = 0;
	if (liczba[i] > 9) {
		mem++;
		liczba[i] = liczba[i] % 10;
		if (i == len - 1) {
			len++;
			liczba[i+1] = 1;
			break;
		}	
	}
}

// Wypisz wyniki
//cout << "Liczba ma " << len << " cyfr"+gramatyka(len) << endl;

// Odwróæ z powrotem liczbê
reverse(liczba, len);

// Wypisz j¹
if(power == 1000) {
cout << "Wynik: " << power << ": ";
for (int i = 0; i < len; i++)
	cout << liczba[i];
cout << ", len: " << len << ", suma cyfr: " << suma(liczba, len) << endl;
}

power++;

}

elapsed();

return 0;
}

long long suma(short * a, int n) {
long long sum = 0;
	for(int i = 0; i < n; i++)
		sum += a[i];
return sum;
}

void reverse(short liczba[], int n) {
	short tmp;
	for (int i = 0; i < n/2; i++) {
		tmp = liczba[i];
		liczba[i] = liczba[n-i-1];
		liczba[n-i-1] = tmp;
	}
}

string gramatyka(int liczba) {
if (liczba == 0) return "";
if (liczba == 1) return "e";
if (liczba > 1 && liczba < 5) return "y";
if (liczba > 4) return "";
}

void elapsed(){
cout << "Czas dzialania: " << 1000.0*clock()/float(CLOCKS_PER_SEC) << " ms" << endl;
}