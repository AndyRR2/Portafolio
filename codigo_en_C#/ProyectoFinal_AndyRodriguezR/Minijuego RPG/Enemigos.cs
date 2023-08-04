namespace EspacioEnemigos;
using System;


public class Enemigos{
    public datos Datos {get;set;}
    public atributos Atributos{get;set;}
    public class datos{
        private string tipo;
        private string nombre;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
    
    public class atributos{
        private string caption;
        private int nivel=1;
        private int defensa=300;
        private int ataque=500;
        private int salud=1000;
        
        public string Caption { get => caption; set => caption = value; }
        public int Nivel { get => nivel; set => nivel = value; }
        public int Defensa { get => defensa; set => defensa = value; }
        public int Ataque { get => ataque; set => ataque = value; }
        public int Salud { get => salud; set => salud = value; }
    }
    
}

