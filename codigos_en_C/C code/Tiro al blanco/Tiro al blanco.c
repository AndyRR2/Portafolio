/*Tiro al blanco
a) En una Kermés se presenta el juego de tiro al blanco con dardos. El costo de un tiro es de
$100. Los premios según la puntería son:
- El círculo rojo con valor 10 tiene un premio de $500.
- El círculo de valor 9 tiene un premio de $200.
- El círculo de valor 8 recupera los $100.
- El círculo de valor 7 recupera $50.
- El resto de círculos no tiene premio.
Realice un programa que permita ingresar cuantos tiros va a realizar el jugador. Luego, simule los
tiros. Por último, muestre cuánta plata gastó, cuánta plata ganó y el saldo final del jugador.
Utilice las siguientes funciones:
void cargarTiros(int *puntos, int tiros); //Función para cargar los puntajes de los tiros.
int calcularGanancia(int *puntos, int tiros); //Función que calcula cuánto ganó el jugador.
b) Modifique el programa anterior para que funcione con un número indeterminado de usuarios.
Además de mostrar los resultados de cada jugador, al finalizar el juego para todos los usuarios,
muestre el monto total pagado por los mismos, el monto total en premios y el saldo final. Elija la
marca final que considere apropiada.
Para esto modifique la función calcularGanancia con el siguiente prototipo:
void calcularGanancia(int *puntos, int tiros, int *totalPagos, int *totalPremios)
donde:
- totalPagos: acumula el pago efectuado por los jugadores
- totalPremios: acumula la cantidad de premios ganados por los jugadores*/
#include <stdio.h>
#include <stdlib.h>
#include <time.h>

void cargarTiros(int *puntos,int tiros);
void calcularGanancia(int *puntos, int tiros, int*totalPagos,int *totalPremios);
int main(){
    srand(time(NULL));
    int puntos=0,inicial,tiros,final;
    int *ganancia,gastado,usu=0,totalPagos=0,totalPremios=0;
    printf("Nuevo usuario(1=si, 0=no): ");
    scanf("%d",&usu);

    while (usu!=0)
    {
    printf("Entre la cantidad de tiros que va a hacer: ");
    scanf("%d",&tiros);
    inicial=tiros*100;
    puntos=inicial;
    cargarTiros(&puntos,tiros);
    calcularGanancia(&puntos,tiros,&totalPagos,&totalPremios);
    if (puntos<=0)
    {
        printf("Ganancia: 0\n");
    }else
    {
        printf("Ganancia: %d\n",puntos);
    }
    
    if (puntos<=0)
    {
        printf("Gastado: %d\n",puntos*-1);
    }else
    {
        printf("Gastado: 0\n");
    }
    final=inicial+puntos;
    printf("Saldo final: %d\n",final);
    printf("Nuevo usuario(1=si, 0=no)");
    scanf("%d",&usu);
    }
    printf("Total de pagos efectuados: %d\n",totalPagos);
    if (totalPremios<0)
    {
        printf("Total de premios acumulados: 0");
    }else
    {
        printf("Total de premios acumulados: %d\n",totalPremios);

    }
    return(0);
}
void cargarTiros(int *puntos,int tiros){
    int *arreglo;
    arreglo=(int*)malloc(tiros*sizeof(int));
    for (int i = 0; i < tiros; i++)
    {
    *arreglo=rand()%10+1;
    *puntos=(*puntos)-100;
    switch (*arreglo)
    {
    case 10 : *puntos=(*puntos)+500; break;
    case 9 : *puntos=(*puntos)+200; break;
    case 8 : *puntos=(*puntos)+100; break;
    case 7 : *puntos=(*puntos)+50; break; 
    }
    arreglo++;
    }
}

void calcularGanancia(int *puntos, int tiros, int*totalPagos,int *totalPremios){
    int *ganancia;
*puntos=(*puntos)-tiros*100;
*totalPagos=(*totalPagos)+tiros*100;
*totalPremios=(*totalPremios)+*puntos;

}
