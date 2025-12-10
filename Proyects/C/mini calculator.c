/*Reduced Calculator
There is a calculator that has a reduced set of instructions, operations arithmetic 
you can perform is just addition and subtraction. 
It takes your help as a programmer to design such an algorithm enter two numbers and 
an operation code to return the result. 
For this you must design and make use of the following functions given two integers a and b: 
● sum(a,b): Return your sum. 
● product(a,b):return your product (multiplication). 
● subtraction(a,b): Return your subtraction. 
● division(a,b): returns its entire division. Where a is the dividend and b is the divisor. 
● rest(a,b): Returns the rest of the entire division. 
● power(a,b): return a raised to b. That is to say: a is the base and b is the exponent. 
ATTENTION: Reuse functions if necessary to define new functions. Observations: 
● Work with positive integers. 
● You can only use the addition and subtraction operators.*/

#include <stdio.h>
#include <math.h>
int sum(int a, int b);
int subtraction(int a, int b);
int product(int a, int b);
int division(int a, int b);
int rest(int a, int b);
int power(int a, int b);
int mult(int a, int x);

int main (){
int selec, a, b;
float op;
printf("Possible operation to perform\n");
printf("1-Sum\n2-Subtraction\n3-Product\n4-Division\n5-Rest\n6-Power\n");
printf("Type the operation number: ");
scanf("%d",&selec);
printf("Enter the first number: ");
scanf("%d",&a);
printf("Enter the second number: ");
scanf("%d",&b);

switch (selec){
case 1 : op=sum(a,b); break;
case 2 : op=subtraction(a,b); break;
case 3 : op=product(a,b); break;
case 4 : op=division(a,b); break;
case 5 : op=rest(a,b); break;
case 6 : op=power(a,b); break;
}
printf("Result = %.2f",op);

    return (0);
}

int sum(int a, int b){
 int aux;
 aux=a+b;
 return (aux);
}

int subtraction(int a, int b){
 int aux;
 aux=a-b;
 return (aux);
}

int product(int a, int b){
 int aux,i;
 aux=a;
 for (i = 1; i <b; i++)
 {
    aux=aux+a;
 }
 return (aux);
}

int division(int a, int b){
 int aux1, aux2, num=0, c=0;
 if (a>=b){
    aux1=a,
    aux2=b;
    num=a;
 }else if(b>a){
    aux1=b,
    aux2=a;
    num=b;
 }
 while (num!=0){
    num=num-aux2;
    c++;
 }
 return (c);
}

int rest(int a, int b){
 int aux1, aux2, num=0, cos=0, rest;
 if (a>=b){
    aux1=a,
    aux2=b;
    num=a;
 }else if(b>a){
    aux1=b,
    aux2=a;
    num=b;
 }
    num=num-aux2;
 while (num>=0){
    num=num-aux2;
    cos=cos+1;
 }
 rest=aux1;
 while (cos!=0)
 {
    rest=rest-aux2;
    cos=cos-1;
 }
 
 return (rest);
}

int power(int a, int b){
 int c, pow, x;
 c=b;
 x=a;
 while (c>1)
 {
    pow=mult(a, x);
    a=mult(a, x);
    c=c-1;
 }
 
return (pow);
}

int mult(int a, int x){
    int res;
    res=0;
    while (x!=0){
        res=res+a;
        x=x-1;
    }
    return(res);
}
