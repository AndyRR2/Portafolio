/*GESTION CLIENTES SUPERMERCADo
Se desea gestionar la información de los clientes de un supermercado mayorista
(apellido, nombre, dni, fecha de nacimiento, y datos de la cuenta que son el código numérico de
cliente y el saldo que debe). Defina una estructura para guardar los datos de un cliente en donde
la fecha de nacimiento y los datos de la cuenta son de tipo struct. Cargue toda la información de 5
clientes.
Realice un programa que inicialmente muestre un listado de los clientes con apellido, nombre y
código. Luego, presentar el siguiente menú:
01. Aumentar el saldo deudor (debe sumar el nuevo valor a la cuenta del cliente).
02. Disminuir saldo deudor: Si al restar el saldo deudor la cuenta del cliente queda saldada
mostrar el mensaje: “Cuenta saldada, no tiene deuda”, de lo contrario mostrar el valor
actualizado.
03. Salir
Si la opción ingresada es 1 o 2 pedir el código del cliente al cual se aplica la operación y el monto.
El programa debe finalizar con la opción salir, con cualquier otra opción debe retornar siempre al
menú principal.*/
#include <stdio.h>
#define TAMA 50

struct 
{
    int codigo;
    float debe;
}typedef datos;

struct 
{
    int dia;
    int mes;
    int anno;
}typedef fecha;

struct 
{
    char nombre[TAMA];
    char apellido[TAMA];
    int dni;
    fecha fech;
    datos cuenta;
}typedef informacion;

informacion cargarCLIENTE();
void mostrarCLIENTE(informacion CLIENTE);
int main(){
    informacion CLIENTE[TAMA];
    int opcion;
    float aumento, disminu;
    for (int i = 0; i < 1; i++)
    {
        CLIENTE[i]=cargarCLIENTE();
    }
    for (int i = 0; i < 1; i++)
    {
        mostrarCLIENTE(CLIENTE[i]);
    }
    //menu
    printf("Menu:\n");
    printf("1-Aumentar saldo\n");
    printf("2-Disminuir saldo\n");
    printf("3-Salir\n");

    printf("Entre la opcion del Menu: ");
    scanf("%d",&opcion);
    fflush(stdin);
    while (opcion!=3)
    {
        for (int i = 0; i < 1; i++)
        {
            if (opcion==1)
       {
        printf("Entre el aumento del saldo deudor: ");
        scanf("%f",&aumento);
        fflush(stdin);
        CLIENTE[i].cuenta.debe=CLIENTE[i].cuenta.debe+aumento;
        printf("Saldo deudor actual: %f\n",CLIENTE[i].cuenta.debe);
       }else if (opcion==2)
       {
        printf("Entre la disminucion del saldo deudor: ");
        scanf("%f",&disminu);
        fflush(stdin);
        CLIENTE[i].cuenta.debe=CLIENTE[i].cuenta.debe-disminu;
        if (CLIENTE[i].cuenta.debe==0)
        {
            printf("Cuenta Saldada\n");
        }else{
            printf("Saldo deudor actual: %f\n",CLIENTE[i].cuenta.debe);
        }
        }else if (opcion==3)
        {
            printf("Salir\n");
        }else
        {
            printf("Opcion incorrecta\n");
        }
        }
        printf("Entre la opcion del Menu: ");
        scanf("%d",&opcion);
        fflush(stdin);
    }

    return(0);
}

informacion cargarCLIENTE(){
informacion CLIENTE;
printf("Entre el nombre: ");
gets(CLIENTE.nombre);
fflush(stdin);
printf("Entre el apellido: ");
gets(CLIENTE.apellido);
fflush(stdin);
printf("Entre el DNI: ");
scanf("%d",&CLIENTE.dni);
fflush(stdin);
printf("Entre la fecha: ");
scanf("%d %d %d",&CLIENTE.fech.dia,&CLIENTE.fech.mes,&CLIENTE.fech.anno);
fflush(stdin);
printf("Entre el codigo del cliente: ");
scanf("%d",&CLIENTE.cuenta.codigo);
fflush(stdin);
printf("Entre el saldo que debe: ");
scanf("%f",&CLIENTE.cuenta.debe);
fflush(stdin);
    return(CLIENTE);
}
void mostrarCLIENTE(informacion CLIENTE){
    printf("Nombre: ");
    puts(CLIENTE.nombre);
    printf("Apellido: ");
    puts(CLIENTE.apellido);
    printf("Codigo: %d\n",CLIENTE.cuenta.codigo);
}

    
    
