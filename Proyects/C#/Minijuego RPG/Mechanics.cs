namespace SpaceMechanics;
using System;
using SpaceEnemies;
using SpaceCharacter;
public class Mechanics{
    public Character GainLpCharacter(Character Ch, int gainLp, int costMp, int maxLp){
        if (costMp <= Ch.Attributes.Mana){
            if (Ch.Attributes.Health + gainLp >= maxLp){
                Ch.Attributes.Health = maxLp;
            }else{
                Ch.Attributes.Health += gainLp;
            }
            Ch.Attributes.Mana = Ch.Attributes.Mana - costMp;
            Console.WriteLine("You heal a little...");
        }else{
            Console.WriteLine("You fail, don't have enough mana...");
            Console.WriteLine("Press enter to continue...");
            Console.ReadLine();
        }
        return(Ch);
    }
    public Enemies LoseLpEnemie(Enemies Enem,Character Ch, int option, int costMp){
        switch (option){
            case 1:
            Enem.Attributes.Healt -= (Ch.Attributes.Attack-(Enem.Attributes.Defense*10)/100);
            if (Enem.Attributes.Healt<0){
                Enem.Attributes.Healt=0;
            }
            Console.WriteLine("You use Attack, weakened the enemy...");
            break;
            case 2:
            if (Ch.Attributes.Mana >= costMp){
            Enem.Attributes.Healt -= (Ch.Attributes.Attack + Ch.Attributes.Intelligence*10 + Ch.Attributes.Dexterity*5 + Ch.Attributes.Strength);
            Ch.Attributes.Mana -= costMp;
            Console.WriteLine("You use Power, weakened the enemy...");
            }else{
                Console.WriteLine("You fail, don't have enough mana...");
                Console.WriteLine("Press enter to continue...");
                Console.ReadLine();
            }
            break;
        }
        return(Enem);
    }
    public Character LoseLpCharacter(Enemies Enem,Character Ch){
        Ch.Attributes.Health = Ch.Attributes.Health - (Enem.Attributes.Attack -(Ch.Attributes.Defense*10)/100);
        if (Ch.Attributes.Health<0){
            Ch.Attributes.Health=0;
        }
        return(Ch);
    }    
    public List<Enemies> DestroyEnemie(List<Enemies> ListEnem,Enemies Enem){
        ListEnem.Remove(Enem);
        return(ListEnem);
    }
    public Character UpdateValuesCh(Character Ch, int level, int lp, int mp){
        Ch.Attributes.Level = level;
        Ch.Attributes.Health = lp + Ch.Attributes.Strength*10 + Ch.Attributes.Dexterity*5 + Ch.Attributes.Intelligence*3 + level*200;
        Ch.Attributes.Mana = mp + Ch.Attributes.Intelligence*10 + Ch.Attributes.Level*100;
        Ch.Attributes.Attack += Ch.Attributes.Dexterity*10 + Ch.Attributes.Strength*5 + Ch.Attributes.Intelligence*3 + level*10;
        Ch.Attributes.Defense += +Ch.Attributes.Strength*10 +Ch.Attributes.Dexterity*5 + Ch.Attributes.Intelligence*3 + level*10;
        return(Ch);
    } 
    public Enemies UpdateValuesE(Enemies Enem){
        Enem.Attributes.Healt += Enem.Attributes.Level*750;
        Enem.Attributes.Attack += Enem.Attributes.Level*70;
        Enem.Attributes.Defense += Enem.Attributes.Level*50;
        return(Enem);
    }
    public int GenerateRandom(int a, int b){
        Random random = new Random();
        int rand = random.Next(a-1,b);
        return(rand);    
    }
}