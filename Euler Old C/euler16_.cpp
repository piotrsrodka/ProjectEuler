#include<iostream>
#include<cmath>

using namespace std;


int main()
{
  cout<<"please input a number (n). This program will determine the sum of the digits of the decimal representation of 2^n:";
  int n=0;
  cin>>n;
  int decrep[n];
  long int sum=0;
  for(int i=0;i<n;i++) decrep[i]=0; // Initialise the decimal representation array.
  decrep[n-1]=2;
  for(int j = 1; j < n; j++) {
		for(int i = 0; i < n; i++) {
			if(decrep[i]==0)continue;        // skip powers of 10 that are zero.
			else {
			  decrep[i]*=2;                // Multilpy each digit by 2 and propagate up through powers of 10.
			  decrep[i-1] += decrep[i] / 10;
			  decrep[i] = decrep[i] % 10;
			}
		}
   }
  for(int i = 0; i < n; i++) sum += decrep[i];
  cout<<"The sum is "<< sum <<" The decimal number is ";
  int sum2=0;
  for(int i = 0; i < n; i++) {
	sum2 += decrep[i];
    if(sum2 == 0 && decrep[i] == 0) continue;
    else cout << decrep[i];
   }
  cout<<"\n";
  return 0;
}