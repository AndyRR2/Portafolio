namespace EspacioPantallas;
using System;
using EspacioPersonaje;
using EspacioEnemigos;

public class Pantallas{
    public void MensajeInicial(){
        Console.WriteLine("\n");
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║-Este juego consiste en elegir una clase de personaje la cual tendra diferentes atributos respectivamente.                                 ║"); 
        Console.WriteLine("║-Se generan 10 enemigos de tres tipos diferentes aleatoriamente y se combate con cada uno de los enemigos uno por uno.                     ║");
        Console.WriteLine("║-Si un enemigo muere, el siguiente tendra un nivel mayor por lo tanto mejores estadisticas.                                                ║"); 
        Console.WriteLine("║-Si el jugador mata suficientes enemigos subira de nivel, aumenta sus estadisticas y tendra la opcion de mejorar sus atributos a eleccion. ║"); 
        Console.WriteLine("║-Ganas si derrotas todos los enemigos.                                                                                                     ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine("\n");
        Console.WriteLine("Presione Enter para continuar.\n");
        Console.ReadLine();
    }
    public void PantallaPrincipal(){
        Console.WriteLine("           ╔════════+════════╗");
        Console.WriteLine("           ║ \"Dungeon Path.\" ║");
        Console.WriteLine("           ╚════════+════════╝");
        Console.WriteLine("               1-Continuar    ");
        Console.WriteLine("             2-Nueva Partida  ");
        Console.WriteLine("                 3-Salir      ");
    }
    public void Clases(){
        Console.WriteLine("         ╔═════════════════════╗");
        Console.WriteLine("         ║ Seleccione su clase ║");
        Console.WriteLine("         ╚═════════════════════╝");
        Console.WriteLine(@"          
   1-Guerrero   2-Mago       3-Asesino
  ╔══════════╗ ╔══════════╗ ╔══════════╗          
  ║ \  @     ║ ║       ▄  ║ ║    Ø/\,  ║
  ║  \/█|██| ║ ║   \Ô__|  ║ ║  \/█     ║
  ║  _/ \_   ║ ║   /█\ |  ║ ║  _/ \_   ║
  ║          ║ ║   ! !    ║ ║          ║
  ║ Fue: 30  ║ ║ Fue: 10  ║ ║ Fue: 10  ║
  ║ Dext: 20 ║ ║ Dext: 20 ║ ║ Dext: 30 ║
  ║ Int: 10  ║ ║ Int: 30  ║ ║ Int: 20  ║
  ╚══════════╝ ╚══════════╝ ╚══════════╝");
    }
    public void MostrarFichaPj(Personaje Pj, int pv, int pm){    
        Console.WriteLine(" ╔══════════════════════════════════════╗ ");
        Console.WriteLine(" ║ Nombre: " + Pj.Datos.Nombre.PadRight(10) + " Apodo: " + Pj.Datos.Apodo.PadRight(10) + " ║ ");
        Console.WriteLine(" ║ Nacimiento: " + Pj.Datos.Fechanac.ToString("dd/MM/yyyy") + "   Edad: " + Pj.Datos.Edad.ToString().PadRight(5) + " ║");
        Console.WriteLine(" ╚══════════════════════════════════════╝");
        Console.WriteLine("   " + Pj.Atributos.Caption + "                    ");
        Console.WriteLine(" ╔══════════════════════════════════════╗ ╔══════════════════════════════════════════════════════════╗");
        Console.WriteLine(" ║ Clase: " + Pj.Atributos.Tipo.PadRight(10) + "  Nivel: " + Pj.Atributos.Nivel.ToString().PadRight(10) + " ║ ║ Equipamiento:                                            ║");
        Console.WriteLine(" ║══════════════════════════════════════║ ║══════════════════════════════════════════════════════════║");
        Console.WriteLine(" ║ Fuerza: " + Pj.Atributos.Fuerza.ToString().PadRight(10) + " Salud: " + Pj.Atributos.Salud.ToString().PadRight(4) + "/"+pv.ToString().PadRight(4)+"  ║ ║ Casco:    " + Pj.Equipamiento.Casco.PadRight(45)+ "  ║");
        Console.WriteLine(" ║ Destreza: " + Pj.Atributos.Destreza.ToString().PadRight(7) + "  Mana: " + Pj.Atributos.Mana.ToString().PadRight(4) + "/"+pm.ToString().PadRight(4)+"   ║ ║ Armadura: " + Pj.Equipamiento.Armadura.PadRight(45)+ "  ║");
        Console.WriteLine(" ║ Inteligencia: " + Pj.Atributos.Inteligencia.ToString().PadRight(5) + "Ataque: " + Pj.Atributos.Ataque.ToString().PadRight(8) + "  ║ ║ Cinturon: " + Pj.Equipamiento.Cinturon.PadRight(45)+ "  ║");
        Console.WriteLine(" ║                    Defensa: " + Pj.Atributos.Defensa.ToString().PadRight(8) + " ║ ║ Botas:    " + Pj.Equipamiento.Botas.PadRight(45)+ "  ║");
        Console.WriteLine(" ╚══════════════════════════════════════╝ ║ Guantes:  " + Pj.Equipamiento.Guantes.PadRight(45)+ "  ║");
        Console.WriteLine("                                          ║ Anillo:   " + Pj.Equipamiento.Anillo.PadRight(45)+ "  ║");
        Console.WriteLine("                                          ║ Amuleto:  " + Pj.Equipamiento.Amuleto.PadRight(46)+ " ║");
        Console.WriteLine("                                          ║ Mano Der: " + Pj.Equipamiento.ManoDer.PadRight(45)+ "  ║");
        Console.WriteLine("                                          ║ Mano Izq: " + Pj.Equipamiento.ManoIzq.PadRight(45)+ "  ║");
        Console.WriteLine("                                          ╚══════════════════════════════════════════════════════════╝");
        Console.WriteLine("\n");
    }
    public void MostrarEquipamiento(Personaje Pj){
        Console.WriteLine("╔═══════════════════════════════════════════════╗");
        Console.WriteLine("║ Equipamiento:                                 ║");
        Console.WriteLine("║═══════════════════════════════════════════════║");
        Console.WriteLine("║ Casco:    " + Pj.Equipamiento.Casco.PadRight(35)+ " ║");
        Console.WriteLine("║ Armadura: " + Pj.Equipamiento.Armadura.PadRight(35)+ " ║");
        Console.WriteLine("║ Cinturon: " + Pj.Equipamiento.Cinturon.PadRight(35)+ " ║");
        Console.WriteLine("║ Botas:    " + Pj.Equipamiento.Botas.PadRight(35)+ " ║");
        Console.WriteLine("║ Guantes:  " + Pj.Equipamiento.Guantes.PadRight(35)+ " ║");
        Console.WriteLine("║ Anillo:   " + Pj.Equipamiento.Anillo.PadRight(35)+ " ║");
        Console.WriteLine("║ Amuleto:  " + Pj.Equipamiento.Amuleto.PadRight(35)+ " ║");
        Console.WriteLine("║ Mano Der: " + Pj.Equipamiento.ManoDer.PadRight(35)+ " ║");
        Console.WriteLine("║ Mano Izq: " + Pj.Equipamiento.ManoIzq.PadRight(35)+ " ║");
        Console.WriteLine("╚═══════════════════════════════════════════════╝");
    }
    public void PantallaMazmorra(Personaje Pj, Enemigos Enem, int pv, int pm, int Epv, int exp){
        int costo1 = pm*35/100;
        int costo2 = pm*20/100;
        int danio = (Pj.Atributos.Ataque + Pj.Atributos.Inteligencia*10 + Pj.Atributos.Destreza*5 + Pj.Atributos.Fuerza);
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ "+Enem.Datos.Nombre.PadRight(29)+" Salud: "+Enem.Atributos.Salud.ToString().PadRight(4)+"/"+Epv.ToString().PadRight(4)+"         ║");
        Console.WriteLine("║ Nivel : "+Enem.Atributos.Nivel.ToString().PadRight(2) + "                                             ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.WriteLine(Enem.Atributos.Caption.PadLeft(10)+ " ");
        Console.WriteLine(@"----------------------------------------------------------");
        Console.WriteLine(Pj.Atributos.Caption.PadRight(10) + "   ");
        Console.WriteLine("╔════════════════════════════════════════════════════════╗ ╔════════════════════╗");
        Console.WriteLine("║ ╔═══════════════╗     ╔═══════════════╗  "+Pj.Datos.Apodo.PadRight(10)+"    ║ ║ 5-Abrir Inventario ║");
        Console.WriteLine("║ ║ 1-Atacar      ║     ║ 3-Escapar     ║  Nivel: "+Pj.Atributos.Nivel.ToString().PadRight(3)+"    ║ ╚════════════════════╝");
        Console.WriteLine("║ ╚═══════════════╝     ╚═══════════════╝                ║");
        Console.WriteLine("║ ╔═══════════════╗     ╔═══════════════╗  PV: "+Pj.Atributos.Salud.ToString().PadRight(4)+"/"+pv.ToString().PadRight(4)+" ║");
        Console.WriteLine("║ ║ 2-Poder       ║     ║ 4-Curarse     ║                ║");
        Console.WriteLine("║ ║ Costo: "+costo1.ToString().PadRight(4)+"PM ║     ║ Costo: "+costo2.ToString().PadRight(4)+"PM ║  PM: "+Pj.Atributos.Mana.ToString().PadRight(4)+"/"+pm.ToString().PadRight(4)+" ║");
        Console.WriteLine("║ ║ Daño : "+danio.ToString().PadRight(4) + "   ║     ║ Cura: "+((pv*30)/100).ToString().PadRight(4)+"PV  ║                ║");
        Console.WriteLine("║ ╚═══════════════╝     ╚═══════════════╝                ║");
        Console.WriteLine("║                               Experiencia: " +Pj.Atributos.Exp.ToString().PadRight(5)+ "/" +exp.ToString().PadRight(5)+" ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
    }
    public void PantallaConEquipamiento(Personaje Pj, Enemigos Enem, int pv, int pm, int Epv, int exp){
        int costo1 = pm*35/100;
        int costo2 = pm*20/100;
        int danio = (Pj.Atributos.Ataque + Pj.Atributos.Inteligencia*10 + Pj.Atributos.Destreza*5 + Pj.Atributos.Fuerza);
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ "+Enem.Datos.Nombre.PadRight(29)+" Salud: "+Enem.Atributos.Salud.ToString().PadRight(4)+"/"+Epv.ToString().PadRight(4)+"         ║");
        Console.WriteLine("║ Nivel : "+Enem.Atributos.Nivel.ToString().PadRight(2) + "                                             ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.WriteLine(Enem.Atributos.Caption.PadLeft(10)+ " ");
        Console.WriteLine(@"----------------------------------------------------------");
        Console.WriteLine(Pj.Atributos.Caption.PadRight(10) + "   ");
        Console.WriteLine("╔════════════════════════════════════════════════════════╗ ╔══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ ╔═══════════════╗     ╔═══════════════╗  "+Pj.Datos.Apodo.PadRight(10)+"    ║ ║ Equipamiento:                                            ║");
        Console.WriteLine("║ ║ 1-Atacar      ║     ║ 3-Escapar     ║  Nivel: "+Pj.Atributos.Nivel.ToString().PadRight(3)+"    ║ ║══════════════════════════════════════════════════════════║");
        Console.WriteLine("║ ╚═══════════════╝     ╚═══════════════╝                ║ ║ Casco:    " + Pj.Equipamiento.Casco.PadRight(45)+ "  ║");
        Console.WriteLine("║ ╔═══════════════╗     ╔═══════════════╗  PV: "+Pj.Atributos.Salud.ToString().PadRight(4)+"/"+pv.ToString().PadRight(4)+" ║ ║ Armadura: " + Pj.Equipamiento.Armadura.PadRight(45)+ "  ║");
        Console.WriteLine("║ ║ 2-Poder       ║     ║ 4-Curarse     ║                ║ ║ Cinturon: " + Pj.Equipamiento.Cinturon.PadRight(45)+ "  ║");
        Console.WriteLine("║ ║ Costo: "+costo1.ToString().PadRight(4)+"PM ║     ║ Costo: "+costo2.ToString().PadRight(4)+"PM ║  PM: "+Pj.Atributos.Mana.ToString().PadRight(4)+"/"+pm.ToString().PadRight(4)+" ║ ║ Botas:    " + Pj.Equipamiento.Botas.PadRight(45)+ "  ║");
        Console.WriteLine("║ ║ Daño : "+danio.ToString().PadRight(4) + "   ║     ║ Cura: "+((pv*30)/100).ToString().PadRight(4)+"PV  ║                ║ ║ Guantes:  " + Pj.Equipamiento.Guantes.PadRight(45)+ "  ║");
        Console.WriteLine("║ ╚═══════════════╝     ╚═══════════════╝                ║ ║ Anillo:   " + Pj.Equipamiento.Anillo.PadRight(45)+ "  ║");
        Console.WriteLine("║                               Experiencia: " +Pj.Atributos.Exp.ToString().PadRight(5)+ "/" +exp.ToString().PadRight(5)+" ║ ║ Amuleto:  " + Pj.Equipamiento.Amuleto.PadRight(46)+ " ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝ ║ Mano Der: " + Pj.Equipamiento.ManoDer.PadRight(45)+ "  ║");
        Console.WriteLine("                                                           ║ Mano Izq: " + Pj.Equipamiento.ManoIzq.PadRight(45)+ "  ║");
        Console.WriteLine("                                                           ╚══════════════════════════════════════════════════════════╝");
        Console.WriteLine("                                                           ╔═════════════════════╗");
        Console.WriteLine("                                                           ║ 6-Cerrar Inventario ║");
        Console.WriteLine("                                                           ╚═════════════════════╝");
    }
    public void EntrasAlNivel(){
        Console.WriteLine("   ╔══════════════════════════════════╗");
        Console.WriteLine("   ║ Entras a una Mazmorra misteriosa ║");
        Console.WriteLine("   ╚══════════════════════════════════╝");
    }
    public void AparecenEnemigos(){
        Console.WriteLine("         ╔══════════════════════╗");
        Console.WriteLine("         ║ Hay Monstruos dentro ║");
        Console.WriteLine("         ╚══════════════════════╝");
        Console.WriteLine("          ╔════════════════════╗");
        Console.WriteLine("          ║ Lucha por tu vida. ║");
        Console.WriteLine("          ╚════════════════════╝");
    }
    public void EnemigoAbatido(string tipo){
        Console.WriteLine("   Enemigo abatido");
        switch (tipo){
                        case "Dragon":
                        Console.WriteLine(@"
                                         /\_   ___/\/\/\/\/\
                                        / ° \  \    o  ///  
                                        vvvvv    ¨¨\  \\\ D_D_D
                                        vvvvv.    ./ /_/_/_/_
                                        \______\   \__/
                        ");break;
                        case "No Muerto":
                        Console.WriteLine(@"
                                              _/_/_/_/_
                                        |__\   \        |
                                         _°|\   \      _|
                                         \   \   \   _/_______
                                          nn¨¨\   \___\__|__|_
                                            nn..   \//
                                            \___/
                        ");break;
                        case "Demonio":
                        Console.WriteLine(@"
                                               /\      /\
                                       _      / /      \ \
                                      /  \    \ \______/ /\
                                      \ o \    \   o  /_/ /
                                      / .. \    \       __\___ 
                                      \VVVVV\    \ VVV\/   / /
                                           |_\    \ __|  __\_\_
                                         /VVV \    \VV\ /    
                                         \_____\    \__/
                        ");break;
                    }
    }
    public Personaje PjAbatido(Personaje pj){
        switch (pj.Atributos.Tipo){
            case "Guerrero": 
            pj.Atributos.Caption=@" 
                  ¨ ''            
                  /█\ 
            ____ _/ \_ |██| @
            ";break;
            case "Mago":
            pj.Atributos.Caption=@"
              ¨ ''
              /█\ 
            Ô ! !  _____▄
            ";break;
            case "Asesino":
            pj.Atributos.Caption=@"
                ¨ ''  
                /█\
            __ _/ \_ Ø __,
            ";break;
        }
        Console.WriteLine(pj.Atributos.Caption);
        return(pj);
    }
    public void SubisteDeNivel(Personaje Pj){
        string entrada;
        bool result=false;
        Console.WriteLine("+++Subiste de nivel+++");
        Console.WriteLine("Enter para continuar...");
        Console.ReadLine();
        int cant=3, opcion=0;
        Console.WriteLine("Tienes 3 puntos de Atributos para gastar.");
        while (cant!=0){
            Console.WriteLine("1-Gastar en Fuerza");
            Console.WriteLine("2-Gastar en Destreza");
            Console.WriteLine("3-Gastar en Inteligencia");
            entrada = Console.ReadLine();
            result = int.TryParse(entrada,out opcion);
            while (!result || (opcion!=1&&opcion!=2&&opcion!=3)){
                Console.WriteLine("Opcion no valida.");
                Console.WriteLine("Seleccione otra opcion:");
                entrada = Console.ReadLine();
                result = int.TryParse(entrada,out opcion);
            }
            switch (opcion){
                case 1:Pj.Atributos.Fuerza += 1;break;
                case 2:Pj.Atributos.Destreza += 1;break;
                case 3:Pj.Atributos.Inteligencia += 1;break;
            }
            cant--;
            Console.WriteLine("Le quedan {0} puntos de Atributos para gastar.",cant);
        }
    }
    public void Ganaste(){
        Console.WriteLine("              ╔═══════════╗");
        Console.WriteLine("              ║ !Ganaste¡ ║");
        Console.WriteLine("              ╚═══════════╝");
    }
    public void Perdiste(){
        Console.WriteLine("         ╔════════════════════╗");
        Console.WriteLine("         ║ Tu Salud llego a 0 ║");
        Console.WriteLine("         ╚════════════════════╝");
        Console.WriteLine("             ╔═════════════╗");
        Console.WriteLine("             ║ Has Muerto. ║");
        Console.WriteLine("             ╚═════════════╝");
    }
    public void Fin(){
        Console.WriteLine("            ╔═══════════════╗");
        Console.WriteLine("            ║ Fin del Juego ║");
        Console.WriteLine("            ╚═══════════════╝");
    }
    public void MostrarEnemigo(Enemigos Enem){
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine(" ╬ " + Enem.Datos.Nombre.PadRight(39) + "╬");
        Console.WriteLine(" ╬ Tipo: " + Enem.Datos.Tipo.PadRight(33) + "╬");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine("   " + Enem.Atributos.Caption+ "             ");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine(" ╬ Nivel: " + Enem.Atributos.Nivel.ToString().PadRight(32) + "╬");
        Console.WriteLine(" ╬ Salud: " + Enem.Atributos.Salud.ToString().PadRight(32) + "╬");
        Console.WriteLine(" ╬ Ataque: " + Enem.Atributos.Ataque.ToString().PadRight(31) + "╬");
        Console.WriteLine(" ╬ Defensa: " + Enem.Atributos.Defensa.ToString().PadRight(30) + "╬");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine("--------------------------------------------\n");
    }
}