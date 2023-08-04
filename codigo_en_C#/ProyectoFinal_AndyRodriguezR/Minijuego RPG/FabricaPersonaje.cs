namespace EspacioFabricaPersonaje;
using System;
using EspacioPersonaje;
using EspacioEnemigos;
using EspacioConstantes;
using EspacioMecanicas;
using EspacioTomarApi;

public class FabricaPersonaje{
    public Personaje CrearPersonaje(Personaje Pj, TomarApi tomaApi){
        Random random = new Random();
        Pj.Equipamiento = new Personaje.equipamiento();
        string entrada,fech;
        bool result;
        int dia, mes, year, clase;
        DateTime fecha;
        entrada = Console.ReadLine();
        result = int.TryParse(entrada,out clase);
        while (!result || (clase!=1 && clase!=2 && clase!=3)){
            Console.WriteLine("Opcion no valida.");
            Console.WriteLine("Entre otra opcion: ");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada,out clase);
        }
        //entrar nombre
        Console.WriteLine("Entre nombre: ");
        entrada = Console.ReadLine();
        while (!EsPalabra(entrada)){
            Console.WriteLine("El nombre no puede contener números o caracteres especiales.");
            Console.WriteLine("Entre nombre:");
            entrada = Console.ReadLine();
        }
        while (entrada=="" || entrada==" "){
            Console.WriteLine("El nombre no puede estar vacio.");
            Console.WriteLine("Entre nombre:");
            entrada = Console.ReadLine();
        }
        while (entrada.Length>10){
            Console.WriteLine("El tamaño del nombre solo admite 10 caracteres.");
            Console.WriteLine("Entre nombre: ");
            entrada = Console.ReadLine();
        }
        Pj.Datos.Nombre=entrada;
        //entrar nombre -fin
        //entrar apodo
        Console.WriteLine("Entre apodo: ");
        entrada = Console.ReadLine();
        while (!EsPalabra(entrada)){
            Console.WriteLine("El apodo no puede contener números o caracteres especiales.");
            Console.WriteLine("Entre apodo:");
            entrada = Console.ReadLine();
        }
        while (entrada=="" || entrada==" "){
            Console.WriteLine("El apodo no puede estar vacio.");
            Console.WriteLine("Entre apodo:");
            entrada = Console.ReadLine();
        }
        while (entrada.Length>10){
            Console.WriteLine("El tamaño del apodo solo admite 10 caracteres.");
            Console.WriteLine("Entre apodo: ");
            entrada = Console.ReadLine();
        }
        Pj.Datos.Apodo=entrada;
        //entrar apodo -fin
        Console.WriteLine("Entre la fecha de nacimiento: ");
        //entrar dia
        Console.WriteLine("Dia: ");
        entrada = Console.ReadLine();
        result = int.TryParse(entrada, out dia);
        while (!result || dia<0 || dia>31){
            Console.WriteLine("El dia entrado no es valido");
            Console.WriteLine("Dia: ");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada, out dia);
        }
        //entrar dia -fin
        //entrar mes
        Console.WriteLine("Mes: ");
        entrada = Console.ReadLine();
        result = int.TryParse(entrada, out mes);
        while (!result || mes<0 || mes>12){
            Console.WriteLine("El mes entrado no es valido");
            Console.WriteLine("Mes: ");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada, out mes);
        }
        //entrar mes -fin
        //entrar year
        Console.WriteLine("Año: ");
        entrada = Console.ReadLine();
        result = int.TryParse(entrada, out year);
        while (!result || year<1920 || year>2023){
            Console.WriteLine("El año entrado no es valido");
            Console.WriteLine("Año: ");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada, out year);
        }
        //entrar year -fin
        //arma fecha
        fech = mes + "/" + dia + "/" + year;
        fecha = DateTime.Parse(fech);
        Pj.Datos.Fechanac=fecha;
        //arma fecha -fin
        //arma Equipamiento
        int aleatorio=0;
        aleatorio = random.Next(tomaApi.ListaCascos.Count);
        Pj.Equipamiento.Casco=tomaApi.ListaCascos[aleatorio];
        tomaApi.ListaCascos.RemoveAt(aleatorio);

        aleatorio = random.Next(tomaApi.ListaArmaduras.Count);
        Pj.Equipamiento.Armadura=tomaApi.ListaArmaduras[aleatorio];
        tomaApi.ListaArmaduras.RemoveAt(aleatorio);

        aleatorio = random.Next(tomaApi.ListaGuantes.Count);
        Pj.Equipamiento.Guantes=tomaApi.ListaGuantes[aleatorio];
        tomaApi.ListaGuantes.RemoveAt(aleatorio);

        aleatorio = random.Next(tomaApi.ListaCinturones.Count);
        Pj.Equipamiento.Cinturon=tomaApi.ListaCinturones[aleatorio];
        tomaApi.ListaCinturones.RemoveAt(aleatorio);

        aleatorio = random.Next(tomaApi.ListaBotas.Count);
        Pj.Equipamiento.Botas=tomaApi.ListaBotas[aleatorio];
        tomaApi.ListaBotas.RemoveAt(aleatorio);

        aleatorio = random.Next(tomaApi.ListaAnillos.Count);
        Pj.Equipamiento.Anillo=tomaApi.ListaAnillos[aleatorio];
        tomaApi.ListaAnillos.RemoveAt(aleatorio);

        aleatorio = random.Next(tomaApi.ListaAmuletos.Count);
        Pj.Equipamiento.Amuleto=tomaApi.ListaAmuletos[aleatorio];
        tomaApi.ListaAmuletos.RemoveAt(aleatorio);
        
        //arma Equipamiento-fin
        Pj.Datos.Edad=CalcEdad(fecha);
        switch (clase){
            case 1: Pj.Atributos.Fuerza = 30;Pj.Atributos.Destreza=20;Pj.Atributos.Inteligencia=10;Pj.Atributos.Tipo="Guerrero";
                    Pj.Atributos.Caption = @"        
                \  @
                 \/█|██|
                 _/ \_";
                 aleatorio = random.Next(tomaApi.ListaEscudos.Count);
                 Pj.Equipamiento.ManoIzq=tomaApi.ListaEscudos[aleatorio];
                 tomaApi.ListaEscudos.RemoveAt(aleatorio);

                 aleatorio = random.Next(tomaApi.ListaEspadas.Count);
                 Pj.Equipamiento.ManoDer=tomaApi.ListaEspadas[aleatorio];
                 tomaApi.ListaEspadas.RemoveAt(aleatorio);
                 break;
            case 2: Pj.Atributos.Fuerza = 10;Pj.Atributos.Destreza=20;Pj.Atributos.Inteligencia=30;Pj.Atributos.Tipo="Mago";
            Pj.Atributos.Caption = @"       
                     ▄
                 \Ô__|
                 /█\ |
                 ! !";
                 aleatorio = random.Next(tomaApi.ListaBaculos.Count);
                 Pj.Equipamiento.ManoIzq=tomaApi.ListaBaculos[aleatorio];
                 tomaApi.ListaBaculos.RemoveAt(aleatorio);

                 aleatorio = random.Next(tomaApi.ListaCristales.Count);
                 Pj.Equipamiento.ManoDer=tomaApi.ListaCristales[aleatorio];
                 tomaApi.ListaCristales.RemoveAt(aleatorio);
                 break;
            case 3: Pj.Atributos.Fuerza = 10;Pj.Atributos.Destreza=30;Pj.Atributos.Inteligencia=20;Pj.Atributos.Tipo="Asesino";
            Pj.Atributos.Caption = @"    
                   Ø/\,
                 \/█
                 _/ \_";
                 aleatorio = random.Next(tomaApi.ListaDagas.Count);
                 Pj.Equipamiento.ManoIzq=tomaApi.ListaDagas[aleatorio];
                 tomaApi.ListaDagas.RemoveAt(aleatorio);

                 aleatorio = random.Next(tomaApi.ListaDagas.Count);
                 Pj.Equipamiento.ManoDer=tomaApi.ListaDagas[aleatorio];
                 tomaApi.ListaDagas.RemoveAt(aleatorio);
                 break;
        }
        return(Pj);
    }
    public string DropearItem(Personaje Pj,TomarApi tomarApi){        
        Random random = new Random();
        int NumList = random.Next(0,6);
        int NumNombre=0;
        int cantidad=0;
        string nombre=null;
        switch (NumList)
        {
            case 0: cantidad = tomarApi.ListaCascos.Count;
                    NumNombre = random.Next(cantidad);
                    nombre = tomarApi.ListaCascos[NumNombre];
                    Pj.Equipamiento.Casco = nombre ;
            break;
            case 1: cantidad = tomarApi.ListaArmaduras.Count;
                    NumNombre = random.Next(cantidad);
                    nombre = tomarApi.ListaArmaduras[NumNombre];
                    Pj.Equipamiento.Armadura = nombre ;
            break;
            case 2: cantidad = tomarApi.ListaGuantes.Count;
                    NumNombre = random.Next(cantidad);
                    nombre = tomarApi.ListaGuantes[NumNombre];
                    Pj.Equipamiento.Guantes = nombre ;
            break;
            case 3: cantidad = tomarApi.ListaCinturones.Count;
                    NumNombre = random.Next(cantidad);
                    nombre = tomarApi.ListaCinturones[NumNombre];
                    Pj.Equipamiento.Cinturon = nombre ;
            break;
            case 4: cantidad = tomarApi.ListaBotas.Count;
                    NumNombre = random.Next(cantidad);
                    nombre = tomarApi.ListaBotas[NumNombre];
                    Pj.Equipamiento.Botas = nombre ;
            break;
            case 5: cantidad = tomarApi.ListaAnillos.Count;
                    NumNombre = random.Next(cantidad);
                    nombre = tomarApi.ListaAnillos[NumNombre];
                    Pj.Equipamiento.Anillo = nombre ;
            break;
            case 6: cantidad = tomarApi.ListaAmuletos.Count;
                    NumNombre = random.Next(cantidad);
                    nombre = tomarApi.ListaAmuletos[NumNombre];
                    Pj.Equipamiento.Amuleto = nombre ;
            break;
        }
        return(nombre);
    }
    public Enemigos GenerarEnemigo(Enemigos Enem, int nivel){
        Constantes Const = new Constantes(); 
        Mecanicas Mec = new Mecanicas();
        Enem.Datos.Tipo = Const.monstruo[Mec.GeneraAleatorio(1,3)];
        Enem.Datos.Nombre = Enem.Datos.Tipo + " " + Const.nombres[Mec.GeneraAleatorio(1,10)];
        Enem.Atributos.Nivel = nivel;
        switch (Enem.Datos.Tipo){
            case "Dragon":
            Enem.Atributos.Caption = @"                                     /\____/\/\/\/\/\
                                    / °    o  ///  
                                    vvvvv¨¨\  \\\ D_D_D
                                    vvvvv../ /_/_/_/_
                                    \________/";
            Enem.Atributos.Salud = 1000 + Enem.Atributos.Nivel*100;
            Enem.Atributos.Ataque = 100 + Enem.Atributos.Nivel*10;
            Enem.Atributos.Defensa = 100 + Enem.Atributos.Nivel*5;
            break;
            case "No Muerto":
            Enem.Atributos.Caption  = @"                                   _/_/_/_/_
                                  |__      |
                                   _°|    _|
                                   \    _/_______
                                   nn¨¨\\__|__|_
                                    nn..//
                                    \___/";
            Enem.Atributos.Salud = 800 + Enem.Atributos.Nivel*100;
            Enem.Atributos.Ataque = 80 + Enem.Atributos.Nivel*10;
            Enem.Atributos.Defensa = 90 + Enem.Atributos.Nivel*5;
            break;
            case "Demonio":
            Enem.Atributos.Caption  = @"                                    /\      /\
                                  _/ /      \ \
                                 / \ \______/ /\
                                 \ o    o  /_/ /
                                 / ..       __ \___ 
                                 \VVVVVVVV\/   / /
                                     |___|  __\_\_
                                    /VVVVV\ /    
                                    \______/";
            Enem.Atributos.Salud = 900 + Enem.Atributos.Nivel*100;
            Enem.Atributos.Ataque = 90 + Enem.Atributos.Nivel*10;
            Enem.Atributos.Defensa = 80 + Enem.Atributos.Nivel*5;
            break;
        }
        return(Enem);
    } 
    public static int CalcEdad(DateTime fecha){
        int Edad;
        DateTime hoy = DateTime.Today;
        Edad = hoy.Year - fecha.Year;
        if (fecha > hoy.AddYears(-Edad)){
            Edad--;
        }
        return(Edad);
    }
    public static bool EsPalabra(string palabra){
        foreach (char letra in palabra){ 
            /*if (!char.IsLetterOrDigit(letra)){
                return(false);  
            }else if (char.IsDigit(letra)){
                return(false);
            }*/
            if (!char.IsLetter(letra)){
                return(false);  
            }
        }
        return(true);
    }
}




