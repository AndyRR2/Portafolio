/*Calculadora Reducida
Se cuenta con una calculadora que tiene un set de instrucciones reducido, las operaciones
aritméticas que puede realizar son solo sumas y restas.
Se necesita la ayuda de usted como programador para que diseñe un algoritmo tal que se
ingresen dos números y un código de operación para que devuelva el resultado.
Para esto debe diseñar y hacer uso de las siguientes funciones que dados dos números enteros a
y b:
● suma(a,b): retorne su suma.
● producto(a,b):retorne su producto (multiplicación).
● resta(a,b): retorne su resta.
● division(a,b): retorne su división entera. Donde a es el dividendo y b el divisor.
● resto(a,b): retorne el resto de la división entera.
● potencia(a,b): retorne a elevado a la b. Es decir: a es la base y b el exponente.
ATENCIÓN: Reutilice las funciones en caso de ser necesario para definir nuevas funciones.
Observaciones:
● Trabajar con números enteros positivos.
● Solo puede utilizar los operadores de suma y resta.*/
#include <stdio.h>
#include <math.h>
int suma(int a, int b);
int resta(int a, int b);
int producto(int a, int b);
int division(int a, int b);
int resto(int a, int b);
int potencia(int a, int b);
int mult(int a, int x);

int main (){
int selec, a, b;
float op;
printf("Operacion posibles de realizar\n");
printf("1-Suma\n2-Resta\n3-Producto\n4-Division\n5-Resto\n6-Potencia\n");
printf("Tecleee el numero de la operacion: ");
scanf("%d",&selec);
printf("Entre el primer numero: ");
scanf("%d",&a);
printf("Entre el segundo numero: ");
scanf("%d",&b);

switch (selec){
case 1 : op=suma(a,b); break;
case 2 : op=resta(a,b); break;
case 3 : op=producto(a,b); break;
case 4 : op=division(a,b); break;
case 5 : op=resto(a,b); break;
case 6 : op=potencia(a,b); break;
}
printf("Resultado = %.2f",op);

    return (0);
}

int suma(int a, int b){
 int aux;
 aux=a+b;
 return (aux);
}

int resta(int a, int b){
 int aux;
 aux=a-b;
 return (aux);
}

int producto(int a, int b){
 int aux;
 aux=a;
 for (int i = 1; i <b; i++)
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

int resto(int a, int b){
 int aux1, aux2, num=0, cos=0, resto;
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
 resto=aux1;
 while (cos!=0)
 {
    resto=resto-aux2;
    cos=cos-1;
 }
 
 return (resto);
}

int potencia(int a, int b){
 int c, poten, x;
 c=b;
 x=a;
 while (c>1)
 {
    poten=mult(a, x);
    a=mult(a, x);
    c=c-1;
 }
 
return (poten);
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