using System;
using EspacioPersonaje;
using EspacioFabricaPersonaje;
using EspacioPantallas;
using EspacioEnemigos;
using EspacioPersonajesJson;
using EspacioMecanicas;
using EspacioConstantes;
using EspacioTomarApi;

public class Program{
    private static void Main(){
        string entrada;
        bool flag = true;
        Personaje PjPrincipal;
        TomarApi tomarApi = new TomarApi();
        tomarApi.ObtenerItem();
    /*Opcional-Escribe las listas de los items
        Console.WriteLine("Cascos: ");
        foreach (var item in tomaApi.ListaCascos)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Armaduras: ");
        foreach (var item in tomaApi.ListaArmaduras)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Guantes: ");
        foreach (var item in tomaApi.ListaGuantes)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Cinturones: ");
        foreach (var item in tomaApi.ListaCinturones)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Botas: ");
        foreach (var item in tomaApi.ListaBotas)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Anillos: ");
        foreach (var item in tomaApi.ListaAnillos)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Amuletos: ");
        foreach (var item in tomaApi.ListaAmuletos)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Espadas: ");
        foreach (var item in tomaApi.ListaEspadas)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Escudos: ");
        foreach (var item in tomaApi.ListaEscudos)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Dagas: ");
        foreach (var item in tomaApi.ListaDagas)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Baculos: ");
        foreach (var item in tomaApi.ListaBaculos)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
        Console.WriteLine("Cristales: ");
        foreach (var item in tomaApi.ListaCristales)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
    */
    //Instancias de clases a usar----------------------------------------------------------------------------------
        Pantallas print = new Pantallas();//para mostrar por pantalla lo necesario
        FabricaPersonaje fabrica = new FabricaPersonaje();//para cambiar valores del personaje cuando sea necesario
        Mecanicas mec = new Mecanicas();//mecanicas y calculos
        Constantes cons = new Constantes();//instancia constantes de partida
        cons.Valores = new Constantes.ValoresMaxDePartida();
        PersonajesJson pers = new PersonajesJson();//para guardar o cargar personaje
        PjPrincipal = new Personaje();//instancia nuevo personaje principal
        PjPrincipal.Atributos = new Personaje.atributos();
        PjPrincipal.Datos = new Personaje.datos();
        var ListaEnemigos = new List<Enemigos>();//instancia lista de enemigos vacia
    //Instacias de clases a usar - fin-----------------------------------------------------------------------------
        
    //Comienza el juego
    print.MensajeInicial();
    //Pantalla principal------------------------------------------------------------------------------------------------------------
        int opcion=0;//variable caontinuar/nueva partida/salir
        int opcion2=3;
        int opcion3=6;

        while (flag==true)
        {
        print.PantallaPrincipal();//muestra opciones de pantalla principal
        entrada = Console.ReadLine();
        bool result = int.TryParse(entrada,out opcion);
        while (!result || (opcion!=1 && opcion!=2 && opcion!=3)){//no se ingreso una opcion valida
            Console.WriteLine("   Opcion no valida.");
            Console.WriteLine("   Entre otra opcion: ");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada,out opcion);
        }
        
        //cuando no hay partida guardada y se selecciona "continuar"-----------------------------------------------------------------
        while (opcion==1 && (!pers.ExisteArch("Personaje") || !pers.ExisteArch("Enemigos") || !pers.ExisteArch("Constantes"))){
            Console.WriteLine("   No hay ninguna partida guardada.");
            Console.WriteLine("   Entre otra opcion: ");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada,out opcion);
        }
        //cuando no hay partida guardada y se selecciona "continuar"-fin------------------------------------------------------------  
        
        Console.Clear();
        
    //nueva partida-----------------------------------------------------------------------------------------------------------
        if (opcion==2){
            //creacion de personaje----------------------------------------------------------------------------------------------
            if (pers.ExisteArch("Personaje")){
                PjPrincipal = new Personaje();//(vuelve a instanciar al personaje principal en caso de empezar nueva partida sin cerrar el juego teniendo una guardada)
                PjPrincipal.Atributos = new Personaje.atributos();
                PjPrincipal.Datos = new Personaje.datos();   
            }
            print.Clases();//muestra las distintas clases a elegir
            PjPrincipal = fabrica.CrearPersonaje(PjPrincipal,tomarApi);//pide datos para crear personaje
            PjPrincipal = mec.ActualizarValores(PjPrincipal,1,PjPrincipal.Atributos.Salud,PjPrincipal.Atributos.Mana);//actualiza los valores segun atributos y nivel
            
            pers.GuardarPjPrincipal(PjPrincipal,"Personaje");//guarda el personaje en archivo json
            //creacion de personaje-fin-------------------------------------------------------------------------------------------
        
            //Console.Clear();
        
            //creacion de enemigos------------------------------------------------------------------------------------------------
            if (pers.ExisteArch("Enemigos")){
                ListaEnemigos = new List<Enemigos>();//(vuelve a instanciar los enemigos en caso de empezar nueva partida sin cerrar el juego teniendo una guardada)
            }
            for (int i = 0; i < 10; i++){//instancia cada uno de los enemigos y los fabrica
                Enemigos Enem = new Enemigos();//instancia nuevo enemigo
                Enem.Datos = new Enemigos.datos();
                Enem.Atributos =new Enemigos.atributos();
                Enem = fabrica.GenerarEnemigo(Enem,1);//genera aleatoriamente un enemigo
                ListaEnemigos.Add(Enem);//agrega al enemigo a la lista de enemigos
            }
            
            pers.GuardarEnemigo(ListaEnemigos,"Enemigos");
            //creacion de enemigos-fin--------------------------------------------------------------------------------------------  

            //establecer constantes--------------------------------------------------------------------------------
            if (pers.ExisteArch("Constantes")){
                cons = new Constantes();//(vuelve a instanciar las constantes en caso de empezar nueva partida sin cerrar el juego teniendo una guardada)
                cons.Valores = new Constantes.ValoresMaxDePartida();
            }
            cons.Valores.PjPvMaximo = PjPrincipal.Atributos.Salud;//guarda la salud inicial
            cons.Valores.PjPmMaximo = PjPrincipal.Atributos.Mana;//guarda el mana inicial
            cons.Valores.EnemPvMaximo = ListaEnemigos[0].Atributos.Salud;//establece vida del enemigo actual
            
            pers.GuardarConstantes(cons,"Constantes");
            //establecer constantes-fin----------------------------------------------------------------------------

        //continuar con la partida guardada------------------------------------------------------------------------
        }else if(opcion==1){
            PjPrincipal = pers.LeerPjPrincipal("Archivos/Personaje.json");//lee el personaje guardado
            ListaEnemigos = pers.LeerEnemigo("Archivos/Enemigos.json");//lee los enemigos guardados
            cons = pers.LeerConstantes("Archivos/Constantes.json");
        //continuar con la partida guardada - fin------------------------------------------------------------------
        
        //salir del juego (con flag en false no entra al siguiente if y termina el juego)
        }else if (opcion==3){
            flag = false;
        }
    //nueva partida - fin-----------------------------------------------------------------------------------------------------------
        opcion=0;//reinicia opcion del menu inicial para evitar entrar a alguno de los if anteriores sin razon al iterar
    //Pantalla principal-fin-------------------------------------------------------------------------------------------------------  
    
    /*Opcional-Pantalla de ficha de enemigos----------------------------------    
        foreach (var Enem in ListaEnemigos){//muestra ficha de los enemigos
            print.MostrarEnemigo(Enem);
        }
    Pantalla de ficha de enemigos-fin----------------------------------------- */

    //Desarrollo del juego------------------------------------------------------------------------------------------------------------------------     
        int costoPm1,costoPm2; //variables necesarias para calculos de daño y otros
        
        if (flag){//si flag es true sigue el programa
        //Pantalla de ficha de personaje-------------------------------------------------------------------------------------------------------
            Console.WriteLine("   Ficha de Personaje:\n");
            print.MostrarFichaPj(PjPrincipal, cons.Valores.PjPvMaximo, cons.Valores.PjPmMaximo);//muestra Ficha con datos y aributos iniciales
            Console.WriteLine("   Presione Enter para continuar.\n");
            Console.ReadLine();//presiona enter y continua el programa
            //Console.Clear();
        //Pantalla de ficha de personaje-fin---------------------------------------------------------------------------------------------------
        
        //Mensajes----------------------------------------------------------------------------------------------------------
            print.EntrasAlNivel();
            Console.ReadLine();
            print.AparecenEnemigos();
            Console.ReadLine();
            //Console.Clear();
        //Mensajes-fin------------------------------------------------------------------------------------------------------
        
        //Repeticion de escenario-----------------------------------------------------------------------------------------------------------
            opcion2=0;
            while (ListaEnemigos.Count!=0 && PjPrincipal.Atributos.Salud>0 && opcion2!=3 ){
                costoPm1 = cons.Valores.PjPmMaximo*35/100;//establece un nuevo costo del poder segun el PM
                costoPm2 = cons.Valores.PjPmMaximo*20/100;//establece un nuevo costo del curar segun el PM
                if (PjPrincipal.Atributos.Tipo=="Mago"){
                    costoPm1 -= (costoPm1*50)/100;
                    costoPm2 -= (costoPm2*50)/100;
                }
                if (opcion3==6){
                    print.PantallaMazmorra(PjPrincipal,ListaEnemigos[0],cons.Valores.PjPvMaximo,cons.Valores.PjPmMaximo,cons.Valores.EnemPvMaximo, cons.Valores.RequierExp);//muestra pantalla de combate
                }else if (opcion3==5){
                    print.PantallaConEquipamiento(PjPrincipal,ListaEnemigos[0],cons.Valores.PjPvMaximo,cons.Valores.PjPmMaximo,cons.Valores.EnemPvMaximo, cons.Valores.RequierExp);
                }
                string entrada2 = Console.ReadLine();
                result = int.TryParse(entrada2, out opcion2);
                while (((!result) || (opcion2!=1&&opcion2!=2&&opcion2!=3&&opcion2!=4&&opcion2!=5&&opcion2!=6))&& entrada2!="D"){//no se ingreso una opcion valida
                    Console.WriteLine("Opcion invalida.");
                    Console.WriteLine("Entre otra opcion: ");
                    entrada2 = Console.ReadLine();
                    result = int.TryParse(entrada2, out opcion2);
                }
                if (entrada2 == "D"){//opcion oculta del administrador (destruir enemigo)
                ListaEnemigos[0].Atributos.Salud=0;
                }   

            //acciones segun la opcion2---------------------------------------------------------------------------------------
                switch (opcion2){//realiza acciones segun la opcion
                    case 1:
                    ListaEnemigos[0]=mec.RestarPvEnemigo(ListaEnemigos[0],PjPrincipal,1,costoPm1);//ejecuta ataque
                    break;
                    case 2:
                    ListaEnemigos[0]=mec.RestarPvEnemigo(ListaEnemigos[0],PjPrincipal,2,costoPm1);//ejecuta poder
                    break;
                    case 3:
                    Console.WriteLine("   Escapaste...");
                    break;
                    case 4:PjPrincipal=mec.GanarPvPersonaje(PjPrincipal,(cons.Valores.PjPvMaximo*30)/100 + (cons.Valores.PjPmMaximo*30)/100,costoPm2,cons.Valores.PjPvMaximo);//ejecuta curacion
                    break;
                    case 5: opcion3=5;
                    break;
                    case 6: opcion3=6;
                    break;
                }    
            //acciones segun la opcion2-fin-----------------------------------------------------------------------------------
            
            //continuacion del juego si no se ha escapado-----------------------------------------------------------------------------------------
                if (opcion2!=3){
                //cuando se abate a un enemigo---------------------------------------------------------------------------------------------    
                    if (ListaEnemigos[0].Atributos.Salud<=0){
                    //Console.Clear();
                    print.EnemigoAbatido(ListaEnemigos[0].Datos.Tipo);
                    string item = fabrica.DropearItem(PjPrincipal,tomarApi);
                    Console.WriteLine("El monstruo ha dropeado el objeto: " + item);
                    Console.WriteLine("Se ha reemplazado el objeto en tu equipamiento");
                    Console.ReadLine();
                    //subir de nivel de Pj----------------------------------------------------------------------------------------------
                        PjPrincipal.Atributos.Exp += cons.Valores.EnemPvMaximo;//gana experiencia
                        if (cons.Valores.RequierExp <= PjPrincipal.Atributos.Exp){//sube de nivel si cumple el requerimiento de experiencia
                            //Console.Clear();
                            print.SubisteDeNivel(PjPrincipal);///mensaje y aumento de atributos
                            PjPrincipal = mec.ActualizarValores(PjPrincipal,PjPrincipal.Atributos.Nivel+1,cons.Valores.PjPvMaximo,cons.Valores.PjPmMaximo);//sube un nivel
                            cons.Valores.RequierExp = PjPrincipal.Atributos.Exp*2;//actualiza el requerimiento de experiencia  
                            cons.Valores.PjPvMaximo = PjPrincipal.Atributos.Salud;//guarda una nueva salud inicial
                            cons.Valores.PjPmMaximo = PjPrincipal.Atributos.Mana;//guarda un nuevo mana inicial
                        }
                    //subir de nivel de Pj-fin------------------------------------------------------------------------------------------

                    //pasar al siguiente enemigo-------------------------------------------------------------------------------------    
                        ListaEnemigos = mec.DestruirEnemigo(ListaEnemigos, ListaEnemigos[0]);//destruye al enemigo actual
                        if (ListaEnemigos.Count!=0){//si aun quedan enemigos en la lista
                            foreach (var Enem in ListaEnemigos){//sube de nivel a los enemigos restantes
                                Enem.Atributos.Nivel += 1;
                            }
                            ListaEnemigos[0] = mec.ActualizarValoresE(ListaEnemigos[0]);//actualiza valores de enemigos + un nivel
                            cons.Valores.EnemPvMaximo = ListaEnemigos[0].Atributos.Salud;//reestablece vida del enemigo actual 
                        }
                    //pasar al siguiente enemigo-fin---------------------------------------------------------------------------------
                    
                //cuando se abate a un enemigo-fin----------------------------------------------------------------------------------------

                //turno enemigo---------------------------------------------------------------------------------------
                    }else if (opcion2!=5 && opcion2!=6){
                        Console.WriteLine("El enemigo ataca, pierdes salud...");
                        Console.ReadLine();
                        PjPrincipal = mec.RestarPvPersonaje(ListaEnemigos[0], PjPrincipal);//ejecuta ataque enemigo
                    }
                //turno enemigo-fin-----------------------------------------------------------------------------------   
                }
                pers.GuardarPjPrincipal(PjPrincipal,"Personaje");//guarda el personaje al final de la ronda en archivo json 
                pers.GuardarEnemigo(ListaEnemigos,"Enemigos");//se guarda la nueva lista de enemigos el final de la ronda en archivo json 
                pers.GuardarConstantes(cons,"Constantes");//guarda las constantes (necesarias para calculos y muestras por pantallas)
                //Console.Clear();
            //continuacion del juego si no se ha escapado-fin-------------------------------------------------------------------------------------    
            }
        //Repeticion de escenario-fin-------------------------------------------------------------------------------------------------------
        
        //cuando ganas el juego-----------------------------------------    
            if (ListaEnemigos.Count==0){
                Console.WriteLine("   Abatiste a todos los enemigos.");
                print.Ganaste(); 
            }
        //cuando ganas el juego-fin------------------------------------- 

        //cuando pierdes------------------------------------------------
            if (PjPrincipal.Atributos.Salud<=0){
                PjPrincipal = print.PjAbatido(PjPrincipal);
                print.Perdiste();
            }  
        //cuando pierdes-fin-------------------------------------------- 
        Console.ReadLine();
        }
        //estado final al terminar--------------------------------------------------------------------------------------------------------------
            Console.WriteLine("   Estado final del personaje: ");
            print.MostrarFichaPj(PjPrincipal,cons.Valores.PjPvMaximo,cons.Valores.PjPmMaximo); 
            print.Fin();
            Console.ReadLine();  
        //estado final al terminar-fin----------------------------------------------------------------------------------------------------------
    }
        Console.WriteLine("   Juego Cerrado...");
        Console.WriteLine("\n");
        if (PjPrincipal.Atributos.Salud<=0 || ListaEnemigos.Count==0)
        {
            File.Delete("Archivos/Constantes.json"); 
            File.Delete("Archivos/Enemigos.json");
            File.Delete("Archivos/Personaje.json");
        }
    }
    //Desarrollo del juego-fin--------------------------------------------------------------------------------------------------------------------
}


