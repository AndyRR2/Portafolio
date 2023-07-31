/*Gestion de publicaciones
Se necesita almacenar información para gestionar la biblioteca de la FACET.
01. A partir de la siguiente información sobre las publicaciones disponibles, organice la misma
de forma estructurada.
○ Título.
○ Editorial.
○ Edición. (1,2,...)
○ Fecha de publicación.
○ Autor (Apellido y Nombre)
○ ISBN. (número de 10-13 dígitos)
○ Categoría. (Libro: L - Revista: R - Tesis: T)
○ Cantidad de ejemplares.
02. Utilice typedef para definir el tipo de dato fecha y autor. Úselos en la estructura principal
donde organiza la información de las publicaciones.
03. Escriba un módulo que permita cargar en el sistema los datos de una publicación.
04. Escriba un módulo que muestre la información de una publicación cualquiera.
05. Escriba un programa para la prueba de los módulos anteriores, cargue y muestre una
publicación.
06. Luego, declare un arreglo del tipo de dato definido en el inciso 01 y carguelo con 5
publicaciones, finalmente muestre las mismas.
Retome el punto 1 del trabajo práctico N° 9. Realice los ajustes que crea necesarios.
★ A partir del tipo base predefinido en el punto 01, declare un arreglo de estructuras de
nombre INVENTARIO que permita almacenar la información de n publicaciones.
★ Escriba un módulo que permita cargar el arreglo completo.
★ Escriba un módulo que muestre todas las publicaciones.
★ Escriba un módulo que modifique la categoría de todas publicaciones según:
○ Si tiene ISBN corresponde Libro
○ Si su ISBN es 0 y la editorial es FACET se trata de una Tesis.
○ Si su ISBN es 0 y la editorial es distinta a FACET es Revista.
★ Escriba un módulo que a partir del ISBN como dato, reste o sume la cantidad de
ejemplares de una publicación. Enviar como parámetros la información necesaria y realizar
los controles pertinentes.*/
#include <stdio.h>
#include <string.h>
struct 
{
    int dia;
    int mes;
    int anno;
}typedef fecha;

struct 
{
    char nombre[25];
    char apellido[25];
}typedef autor;

struct{              
    char titulo[25];
    char editorial[25];
    int edicion;
    fecha fechapub;
    autor autorpub;
    int isbn;
    char categoria[25];
    int cantidad;
}typedef publicacion;

publicacion cargarDatos (publicacion *INVENTARIO, int cant);
void modificarDatos (publicacion *INVENTARIO, int cant);
void mostrarDatos (publicacion *INVENTARIO, int cant);

int main(){
publicacion DATOS[5],*INVENTARIO;
int cant;
INVENTARIO=DATOS;
printf("Entre la cantidad de publicaciones: ");
scanf("%d",&cant);
fflush(stdin);

    cargarDatos (INVENTARIO,cant);
    modificarDatos (INVENTARIO,cant);
    mostrarDatos (INVENTARIO,cant);


    return(0);
}

publicacion cargarDatos (publicacion *INVENTARIO, int cant){
    for (int i = 0; i < cant; i++)
{
    printf("Entre el titulo de la publicacion: ");
    gets(INVENTARIO->titulo);
    fflush(stdin);
    printf("Entre la editorial de la publicacion: ");
    gets((*INVENTARIO).editorial);
    fflush(stdin);
    printf("Entre la edicion de la publicacion: ");
    scanf("%d",&(*INVENTARIO).edicion);
    fflush(stdin);
    printf("Entre la fecha de la publicacion: ");
    scanf("%d %d %d",&(*INVENTARIO).fechapub.dia,&(*INVENTARIO).fechapub.mes,&(*INVENTARIO).fechapub.anno);
    fflush(stdin);
    printf("Entre el nombre del autor de la publicacion: ");
    gets((*INVENTARIO).autorpub.nombre);
    fflush(stdin);
    printf("Entre el apellido del autor de la publicacion: ");
    gets((*INVENTARIO).autorpub.apellido);
    fflush(stdin);
    printf("Entre el isbn de la publicacion: ");
    scanf("%d",&(*INVENTARIO).isbn);
    fflush(stdin);
    printf("Entre la categoria de la publicacion: ");
    gets((*INVENTARIO).categoria);
    fflush(stdin);
    printf("Entre la cantidad de ejemplares de la publicacion: ");
    scanf("%d",&(*INVENTARIO).cantidad);
    fflush(stdin);
    INVENTARIO++; 
}
}
void modificarDatos (publicacion *INVENTARIO, int cant){
   for (int i = 0; i < cant; i++)
{
if ((*INVENTARIO).isbn==0)
{
    puts("Si es isbn=0");
    if (strcmp((*INVENTARIO).editorial,"FACET")==0)
    {
       puts("Si es editorial=FACET");
       strcpy((*INVENTARIO).categoria,"Tesis");
    }else
    {
        puts("No es editorial=FACET");
        strcpy((*INVENTARIO).categoria,"Revista");
    }
}else
{
    puts("No es isbn=0");
    strcpy((*INVENTARIO).categoria,"Libro");
}
INVENTARIO++;
} 
}

void mostrarDatos (publicacion *INVENTARIO, int cant){
for (int i = 0; i < cant; i++)
{
printf("Titulo: ");
puts((*INVENTARIO).titulo);
printf("Editorial: ");
puts((*INVENTARIO).editorial);
printf("Edicion: %d\n",(*INVENTARIO).edicion);
printf("Fecha: %d-%d-%d\n",(*INVENTARIO).fechapub.dia,(*INVENTARIO).fechapub.mes,(*INVENTARIO).fechapub.anno);
printf("Nombre: ");
puts((*INVENTARIO).autorpub.nombre);
printf("Apellido: ");
puts((*INVENTARIO).autorpub.apellido);
printf("ISBN: %d\n",(*INVENTARIO).isbn);
printf("Categoria: ");
puts((*INVENTARIO).categoria);
printf("Cantidad: %d\n",(*INVENTARIO).cantidad);
INVENTARIO++;
}
}

