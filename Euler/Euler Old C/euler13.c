#include<iostream>
#include<fstream>
#include<ctime>

using namespace std;

int main() {
long long liczba;
double suma = 0;
ifstream plik;
plik.open("euler13.txt", ifstream::in);
for(int i = 1; i <= 100; i++) {
	plik >> liczba;
	cout << liczba << endl;
	suma += liczba;
}
plik.close();
cout << endl << (long long)suma << endl;
cout << clock()/float(CLOCKS_PER_SEC) << " s" << endl;
cin.ignore();
return 0;
}