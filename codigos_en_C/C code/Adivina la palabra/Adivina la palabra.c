/*Adivinando la Palabra
Programar un prototipo para un juego llamado Adivinando la Palabra. El juego funciona así:
● Primero se debe ingresar una palabra. Luego según la cantidad de caracteres, se debe
mostrar en pantalla guiones incógnita reemplazando los caracteres.
● Un usuario tiene que adivinar la palabra ingresando alguna letra.
○ Si la letra se encuentra en la palabra, se debe volver a mostrar en pantalla los
guiones incógnita, salvo las letras encontradas por el usuario.
○ Si el usuario ingresa una letra que no está en la palabra se debe descontar un
intento. Y tiene un máximo de 3 intentos para adivinar la palabra.
Si el participante gana se debe mostrar un mensaje informando que adivinó la palabra o si perdió,
informar que agotó los tres intentos.
Ejemplo:
1- Ingresa palabra: programacion
2- Muestra en pantalla: - - - - - - - - - - - -
3- Ingresa una letra: a
4- Muestra en pantalla: - - - - - a - a - - - - Intentos: 3
5- Ingresa una letra: e
6- Muestra en pantalla: - - - - - a - a - - - - Intentos: 2*/
#include <stdio.h>
#include <string.h>
#define TAMA 25
int main(){
char palabra[TAMA],adivina[TAMA],repetida[TAMA],letra;
int i,j=0,caracteres,nopasa=0,intentos=0,encontro,longitud,gana=0,cont=0;
printf("Entrar palabra: ");
gets(palabra);
caracteres=strlen(palabra);
for (int i = 0; i < caracteres; i++)
{
    adivina[i]='-';
    repetida[i]='-';
}
adivina[caracteres]='\0';
repetida[caracteres]='\0';
puts(adivina);
while (intentos!=3&&cont!=caracteres)
{
    fflush(stdin);
    printf("entrar letra: ");
    fflush(stdin);
    scanf("%c",&letra);
    fflush(stdin);
for (int i = 0; i < caracteres; i++)
{
    if (palabra[i]==letra)
    {   
        encontro=1;
        adivina[i]=letra;
        for (int j = 0; j < caracteres; j++)
        {
            if (adivina[i]==repetida[j])
        {
            nopasa=1;
        }
        }
        if (nopasa==0)
        {
            cont++;
            repetida[j]=letra;
        }
        nopasa=0;  
    }
}
if(encontro==0)
{
    intentos++;
}
encontro=0;
puts(adivina);
}
if (cont==caracteres)
{
    printf("Ganador");
}else{
    printf("Agoto los tres intentos");
}


    return(0);
}