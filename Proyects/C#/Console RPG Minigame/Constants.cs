namespace SpaceConstants;
using System;
public class Constants{
    public MaxValues Values{get;set;}
    public class MaxValues{
        private int chLpMax;
        private int chMpMax;
        private int enemLpMax;
        private int requiredExp=2000;

        public int ChLpMax { get => chLpMax; set => chLpMax = value; }
        public int ChMpMax { get => chMpMax; set => chMpMax = value; }
        public int EnemLpMax { get => enemLpMax; set => enemLpMax = value; }
        public int RequiredExp { get => requiredExp; set => requiredExp = value; }
    }
    public string[] names = {"from the abyss","of blood","ghostly","ancient","from the underworld","incendiary","poisonous","frozen","dark","executor"};
    public string[] monster = {"Dragon","Undead","Demon"};

    
}












