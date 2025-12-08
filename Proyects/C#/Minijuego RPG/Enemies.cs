namespace SpaceEnemies;
using System;


public class Enemies{
    public description Description {get;set;}
    public attributes Attributes{get;set;}
    public class description{
        private string type;
        private string name;

        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
    }
    
    public class attributes{
        private string caption;
        private int level=1;
        private int defense=300;
        private int attack=500;
        private int health=1000;
        
        public string Caption { get => caption; set => caption = value; }
        public int Level { get => level; set => level = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Healt { get => health; set => health = value; }
    }
    
}

