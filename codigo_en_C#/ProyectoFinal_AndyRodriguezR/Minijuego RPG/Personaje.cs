namespace EspacioPersonaje;
using System;
public class Personaje{
    public datos Datos{get;set;}
    public atributos Atributos {get;set;}
    public equipamiento Equipamiento {get;set;}
    public class datos{
        private string nombre;
        private string apodo;
        private DateTime fechanac;
        private int edad;
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apodo { get => apodo; set => apodo = value; }
        public DateTime Fechanac { get => fechanac; set => fechanac = value; }
        public int Edad { get => edad; set => edad = value; }
    }
    public class atributos{
        private string caption;
        private string tipo;
        private int inteligencia;
        private int destreza;
        private int fuerza;
        private int nivel=1;
        private int defensa=100;
        private int ataque=100;
        private int salud=1000;
        private int mana=300;
        private int exp=0;
        
        public string Caption { get => caption; set => caption = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Inteligencia { get => inteligencia; set => inteligencia = value; }
        public int Destreza { get => destreza; set => destreza = value; }
        public int Fuerza { get => fuerza; set => fuerza = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Salud { get => salud; set => salud = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Exp { get => exp; set => exp = value; }
    }
    public class equipamiento{
        private string casco;
        private string armadura;
        private string guantes;
        private string cinturon;
        private string botas;
        private string anillo;
        private string amuleto;
        private string manoIzq;
        private string manoDer;

        public string Casco { get => casco; set => casco = value; }
        public string Armadura { get => armadura; set => armadura = value; }
        public string Guantes { get => guantes; set => guantes = value; }
        public string Cinturon { get => cinturon; set => cinturon = value; }
        public string Botas { get => botas; set => botas = value; }
        public string Anillo { get => anillo; set => anillo = value; }
        public string Amuleto { get => amuleto; set => amuleto = value; }
        public string ManoIzq { get => manoIzq; set => manoIzq = value; }
        public string ManoDer { get => manoDer; set => manoDer = value; }
    }
}
