namespace SpaceCharacter;
using System;
public class Character{
    public description Description{get;set;}
    public attributes Attributes {get;set;}
    public equipment Equipment {get;set;}
    public class description{
        private string name;
        private string nickname;
        private DateTime birthdate;
        private int age;
        public string Name { get => name; set => name = value; }
        public string Nickname { get => nickname; set => nickname = value; }
        public DateTime Birthdate { get => birthdate; set => birthdate = value; }
        public int Age { get => age; set => age = value; }
    }
    public class attributes{
        private string caption;
        private string type;
        private int intelligence;
        private int dexterity;
        private int strength;
        private int level=1;
        private int defense=100;
        private int attack=100;
        private int health=1000;
        private int mana=300;
        private int exp=0;
        
        public string Caption { get => caption; set => caption = value; }
        public string Type { get => type; set => type = value; }
        public int Intelligence { get => intelligence; set => intelligence = value; }
        public int Dexterity { get => dexterity; set => dexterity = value; }
        public int Strength { get => strength; set => strength = value; }
        public int Level { get => level; set => level = value; }
        public int Defense { get => defense; set => defense = value; }
        public int Attack { get => attack; set => attack = value; }
        public int Health { get => health; set => health = value; }
        public int Mana { get => mana; set => mana = value; }
        public int Exp { get => exp; set => exp = value; }
    }
    public class equipment{
        private string helmet;
        private string chest;
        private string gloves;
        private string belt;
        private string boots;
        private string ring;
        private string amulet;
        private string leftHand;
        private string rigthHand;

        public string Helmet { get => helmet; set => helmet = value; }
        public string Chest { get => chest; set => chest = value; }
        public string Gloves { get => gloves; set => gloves = value; }
        public string Belt { get => belt; set => belt = value; }
        public string Boots { get => boots; set => boots = value; }
        public string Ring { get => ring; set => ring = value; }
        public string Amulet { get => amulet; set => amulet = value; }
        public string LeftHand { get => leftHand; set => leftHand = value; }
        public string RigthHand { get => rigthHand; set => rigthHand = value; }
    }
}
