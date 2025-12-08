namespace SpaceScreens;
using System;
using SpaceCharacter;
using SpaceEnemies;

public class Screens{
    public void InitialMessage(){
        Console.WriteLine("\n");
        Console.WriteLine("╔═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║-This game consists of choosing a character class which has different attributes respectively.                             ║"); 
        Console.WriteLine("║-10 enemies of three different types are generated randomly and each enemy is fought one by one.                           ║");
        Console.WriteLine("║-If an enemy dies, tracking tends to a higher level therefore better statistics.                                           ║"); 
        Console.WriteLine("║-If the player kills enough enemies they will level up, increase their stats and improve their attributes of their choice. ║"); 
        Console.WriteLine("║-You win if you defeat all enemies.                                                                                        ║");
        Console.WriteLine("╚═══════════════════════════════════════════════════════════════════════════════════════════════════════════════════════════╝");
        Console.WriteLine("\n");
        Console.WriteLine("Press Enter to continue.\n");
        Console.ReadLine();
    }
    public void MainScreen(){
        Console.WriteLine("           ╔════════+════════╗");
        Console.WriteLine("           ║ \"Dungeon Path.\" ║");
        Console.WriteLine("           ╚════════+════════╝");
        Console.WriteLine("               1-Continue     ");
        Console.WriteLine("               2-New Game     ");
        Console.WriteLine("               3-Exit         ");
    }
    public void Class(){
        Console.WriteLine("         ╔═════════════════════╗");
        Console.WriteLine("         ║ Select your Class   ║");
        Console.WriteLine("         ╚═════════════════════╝");
        Console.WriteLine(@"          
   1-Warrior   2-Mage       3-Assasin
  ╔══════════╗ ╔══════════╗ ╔══════════╗          
  ║ \  @     ║ ║       ▄  ║ ║    Ø/\,  ║
  ║  \/█|██| ║ ║   \Ô__|  ║ ║  \/█     ║
  ║  _/ \_   ║ ║   /█\ |  ║ ║  _/ \_   ║
  ║          ║ ║   ! !    ║ ║          ║
  ║ Str: 30  ║ ║ Str: 10  ║ ║ Str: 10  ║
  ║ Dext: 20 ║ ║ Dext: 20 ║ ║ Dext: 30 ║
  ║ Int: 10  ║ ║ Int: 30  ║ ║ Int: 20  ║
  ╚══════════╝ ╚══════════╝ ╚══════════╝");
    }
    public void ShowChTab(Character Ch, int lp, int mp){    
        Console.WriteLine(" ╔══════════════════════════════════════╗ ");
        Console.WriteLine(" ║ Name: " + Ch.Description.Name.PadRight(10) + " Nickname: " + Ch.Description.Nickname.PadRight(10) + "║ ");
        Console.WriteLine(" ║ Birthdate: " + Ch.Description.Birthdate.ToString("dd/MM/yyyy") + "   Age: " + Ch.Description.Age.ToString().PadRight(5) + "   ║");
        Console.WriteLine(" ╚══════════════════════════════════════╝");
        Console.WriteLine("   " + Ch.Attributes.Caption + "                    ");
        Console.WriteLine(" ╔══════════════════════════════════════╗ ╔══════════════════════════════════════════════════════════╗");
        Console.WriteLine(" ║ Class: " + Ch.Attributes.Type.PadRight(10) + "  Level: " + Ch.Attributes.Level.ToString().PadRight(10) + " ║ ║ Equipment:                                               ║");
        Console.WriteLine(" ║══════════════════════════════════════║ ║══════════════════════════════════════════════════════════║");
        Console.WriteLine(" ║ Strength: " + Ch.Attributes.Strength.ToString().PadRight(10) + "Health: " + Ch.Attributes.Health.ToString().PadRight(4) + "/"+lp.ToString().PadRight(4)+"║ ║ Helmet: " + Ch.Equipment.Helmet.PadRight(45)+ "    ║");
        Console.WriteLine(" ║ Dexterity: " + Ch.Attributes.Dexterity.ToString().PadRight(7) + "  Mana: " + Ch.Attributes.Mana.ToString().PadRight(4) + "/"+mp.ToString().PadRight(4)+"  ║ ║ Chest: " + Ch.Equipment.Chest.PadRight(45)+ "     ║");
        Console.WriteLine(" ║ Intelligence: " + Ch.Attributes.Intelligence.ToString().PadRight(5) + " Attack: " + Ch.Attributes.Attack.ToString().PadRight(8) + " ║ ║ Belt: " + Ch.Equipment.Belt.PadRight(45)+ "      ║");
        Console.WriteLine(" ║                     Defense: " + Ch.Attributes.Defense.ToString().PadRight(8) + "║ ║ Boots: " + Ch.Equipment.Boots.PadRight(45)+ "     ║");
        Console.WriteLine(" ╚══════════════════════════════════════╝ ║ Gloves: " + Ch.Equipment.Gloves.PadRight(45)+ "    ║");
        Console.WriteLine("                                          ║ Ring: " + Ch.Equipment.Ring.PadRight(45)+ "      ║");
        Console.WriteLine("                                          ║ Amulet: " + Ch.Equipment.Amulet.PadRight(46)+ "   ║");
        Console.WriteLine("                                          ║ Rigth Hand: " + Ch.Equipment.RigthHand.PadRight(45)+ "║");
        Console.WriteLine("                                          ║ Left Hand: " + Ch.Equipment.LeftHand.PadRight(45)+ " ║");
        Console.WriteLine("                                          ╚══════════════════════════════════════════════════════════╝");
        Console.WriteLine("\n");
    }
    public void ShowEquipment(Character Ch){
        Console.WriteLine("╔═══════════════════════════════════════════════╗");
        Console.WriteLine("║ Equipment:                                 ║");
        Console.WriteLine("║═══════════════════════════════════════════════║");
        Console.WriteLine("║ Helmet:    " + Ch.Equipment.Helmet.PadRight(35)+ " ║");
        Console.WriteLine("║ Chest: " + Ch.Equipment.Chest.PadRight(35)+ " ║");
        Console.WriteLine("║ Belt: " + Ch.Equipment.Belt.PadRight(35)+ " ║");
        Console.WriteLine("║ Boots:    " + Ch.Equipment.Boots.PadRight(35)+ " ║");
        Console.WriteLine("║ Gloves:  " + Ch.Equipment.Gloves.PadRight(35)+ " ║");
        Console.WriteLine("║ Ring:   " + Ch.Equipment.Ring.PadRight(35)+ " ║");
        Console.WriteLine("║ Amulet:  " + Ch.Equipment.Amulet.PadRight(35)+ " ║");
        Console.WriteLine("║ Rigth Hand: " + Ch.Equipment.RigthHand.PadRight(35)+ " ║");
        Console.WriteLine("║ Left Hand: " + Ch.Equipment.LeftHand.PadRight(35)+ " ║");
        Console.WriteLine("╚═══════════════════════════════════════════════╝");
    }
    public void DungeonScreen(Character Ch, Enemies Enem, int lp, int mp, int Elp, int exp){
        int cost1 = mp*35/100;
        int cost2 = mp*20/100;
        int damage = (Ch.Attributes.Attack + Ch.Attributes.Intelligence*10 + Ch.Attributes.Dexterity*5 + Ch.Attributes.Strength);
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ "+Enem.Description.Name.PadRight(29)+" Health: "+Enem.Attributes.Healt.ToString().PadRight(4)+"/"+Elp.ToString().PadRight(4)+"        ║");
        Console.WriteLine("║ Level : "+Enem.Attributes.Level.ToString().PadRight(2) + "                                             ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.WriteLine(Enem.Attributes.Caption.PadLeft(10)+ " ");
        Console.WriteLine(@"----------------------------------------------------------");
        Console.WriteLine(Ch.Attributes.Caption.PadRight(10) + "   ");
        Console.WriteLine("╔════════════════════════════════════════════════════════╗ ╔════════════════════╗");
        Console.WriteLine("║ ╔═══════════════╗     ╔═══════════════╗  "+Ch.Description.Nickname.PadRight(10)+"    ║ ║ 5-Open Inventory   ║");
        Console.WriteLine("║ ║ 1-Attack      ║     ║ 3-Escape      ║  Level: "+Ch.Attributes.Level.ToString().PadRight(3)+"    ║ ╚════════════════════╝");
        Console.WriteLine("║ ╚═══════════════╝     ╚═══════════════╝                ║");
        Console.WriteLine("║ ╔═══════════════╗     ╔═══════════════╗  LP: "+Ch.Attributes.Health.ToString().PadRight(4)+"/"+lp.ToString().PadRight(4)+" ║");
        Console.WriteLine("║ ║ 2-Power       ║     ║ 4-Heal        ║                ║");
        Console.WriteLine("║ ║ Cost: "+cost1.ToString().PadRight(4)+"MP  ║     ║ Cost: "+cost2.ToString().PadRight(4)+"MP  ║  MP: "+Ch.Attributes.Mana.ToString().PadRight(4)+"/"+mp.ToString().PadRight(4)+" ║");
        Console.WriteLine("║ ║ Damage : "+damage.ToString().PadRight(4) + " ║     ║ Heal: "+((lp*30)/100).ToString().PadRight(4)+"LP  ║                ║");
        Console.WriteLine("║ ╚═══════════════╝     ╚═══════════════╝                ║");
        Console.WriteLine("║                               Experience: " +Ch.Attributes.Exp.ToString().PadRight(5)+ "/" +exp.ToString().PadRight(5)+"  ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
    }
    public void InventoryScreen(Character Ch, Enemies Enem, int lp, int mp, int Elp, int exp){
        int cost1 = mp*35/100;
        int cost2 = mp*20/100;
        int damage = (Ch.Attributes.Attack + Ch.Attributes.Intelligence*10 + Ch.Attributes.Dexterity*5 + Ch.Attributes.Strength);
        Console.WriteLine("╔════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ "+Enem.Description.Name.PadRight(29)+" Healt: "+Enem.Attributes.Healt.ToString().PadRight(4)+"/"+Elp.ToString().PadRight(4)+"         ║");
        Console.WriteLine("║ Level : "+Enem.Attributes.Level.ToString().PadRight(2) + "                                             ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝");
        Console.WriteLine(Enem.Attributes.Caption.PadLeft(10)+ " ");
        Console.WriteLine(@"----------------------------------------------------------");
        Console.WriteLine(Ch.Attributes.Caption.PadRight(10) + "   ");
        Console.WriteLine("╔════════════════════════════════════════════════════════╗ ╔══════════════════════════════════════════════════════════╗");
        Console.WriteLine("║ ╔═══════════════╗     ╔═══════════════╗  "+Ch.Description.Nickname.PadRight(10)+"    ║ ║ Equipment:                                               ║");
        Console.WriteLine("║ ║ 1-Attack      ║     ║ 3-Escape      ║  Level: "+Ch.Attributes.Level.ToString().PadRight(3)+"    ║ ║══════════════════════════════════════════════════════════║");
        Console.WriteLine("║ ╚═══════════════╝     ╚═══════════════╝                ║ ║ Helmet:    " + Ch.Equipment.Helmet.PadRight(45)+ " ║");
        Console.WriteLine("║ ╔═══════════════╗     ╔═══════════════╗  LP: "+Ch.Attributes.Health.ToString().PadRight(4)+"/"+lp.ToString().PadRight(4)+" ║ ║ Chest: " + Ch.Equipment.Chest.PadRight(45)+ "     ║");
        Console.WriteLine("║ ║ 2-Power       ║     ║ 4-Heal        ║                ║ ║ Belt: " + Ch.Equipment.Belt.PadRight(45)+ "      ║");
        Console.WriteLine("║ ║ Cost: "+cost1.ToString().PadRight(4)+"MP  ║     ║ Cost: "+cost2.ToString().PadRight(4)+"MP  ║  MP: "+Ch.Attributes.Mana.ToString().PadRight(4)+"/"+mp.ToString().PadRight(4)+" ║ ║ Boots:    " + Ch.Equipment.Boots.PadRight(45)+ "  ║");
        Console.WriteLine("║ ║ Damage : "+damage.ToString().PadRight(4) + " ║     ║ Heal: "+((lp*30)/100).ToString().PadRight(4)+"LP  ║                ║ ║ Gloves:  " + Ch.Equipment.Gloves.PadRight(45)+ "   ║");
        Console.WriteLine("║ ╚═══════════════╝     ╚═══════════════╝                ║ ║ Ring:   " + Ch.Equipment.Ring.PadRight(45)+ "    ║");
        Console.WriteLine("║                               Experience: " +Ch.Attributes.Exp.ToString().PadRight(5)+ "/" +exp.ToString().PadRight(5)+"  ║ ║ Amulet:  " + Ch.Equipment.Amulet.PadRight(46)+ "  ║");
        Console.WriteLine("╚════════════════════════════════════════════════════════╝ ║ Rigth Hand: " + Ch.Equipment.RigthHand.PadRight(45)+ "║");
        Console.WriteLine("                                                           ║ Left Hand: " + Ch.Equipment.LeftHand.PadRight(45)+ " ║");
        Console.WriteLine("                                                           ╚══════════════════════════════════════════════════════════╝");
        Console.WriteLine("                                                           ╔═════════════════════╗");
        Console.WriteLine("                                                           ║ 6-Close Inventory   ║");
        Console.WriteLine("                                                           ╚═════════════════════╝");
    }
    public void EnterToDungeon(){
        Console.WriteLine("   ╔══════════════════════════════════╗");
        Console.WriteLine("   ║  You enter a mysterious Dungeon  ║");
        Console.WriteLine("   ╚══════════════════════════════════╝");
    }
    public void EnemiesAppear(){
        Console.WriteLine("      ╔═══════════════════════════╗  ");
        Console.WriteLine("      ║ There are Monsters inside ║  ");
        Console.WriteLine("      ╚═══════════════════════════╝  ");
        Console.WriteLine("        ╔══════════════════════╗  ");
        Console.WriteLine("        ║ Fight for your life. ║  ");
        Console.WriteLine("        ╚══════════════════════╝  ");
    }
    public void EnemyKilledScreen(string type){
        Console.WriteLine("   Enemy killed");
        switch (type){
                        case "Dragon":
                        Console.WriteLine(@"
                                         /\_   ___/\/\/\/\/\
                                        / ° \  \    o  ///  
                                        vvvvv    ¨¨\  \\\ D_D_D
                                        vvvvv.    ./ /_/_/_/_
                                        \______\   \__/
                        ");break;
                        case "Undead":
                        Console.WriteLine(@"
                                              _/_/_/_/_
                                        |__\   \        |
                                         _°|\   \      _|
                                         \   \   \   _/_______
                                          nn¨¨\   \___\__|__|_
                                            nn..   \//
                                            \___/
                        ");break;
                        case "Demon":
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
    public Character ChKilled(Character ch){
        switch (ch.Attributes.Type){
            case "Warrior": 
            ch.Attributes.Caption=@" 
                  ¨ ''            
                  /█\ 
            ____ _/ \_ |██| @
            ";break;
            case "Mage":
            ch.Attributes.Caption=@"
              ¨ ''
              /█\ 
            Ô ! !  _____▄
            ";break;
            case "Assasin":
            ch.Attributes.Caption=@"
                ¨ ''  
                /█\
            __ _/ \_ Ø __,
            ";break;
        }
        Console.WriteLine(ch.Attributes.Caption);
        return(ch);
    }
    public void LevelUp(Character Ch){
        string entry;
        bool result=false;
        Console.WriteLine("+++You Level Up+++");
        Console.WriteLine("Enter to Continue...");
        Console.ReadLine();
        int amount=3, option=0;
        Console.WriteLine("You have 3 Attribute points to spend.");
        while (amount!=0){
            Console.WriteLine("1-Spend on Strength");
            Console.WriteLine("2-Spend on Dexterity");
            Console.WriteLine("3-Spend on Intelligence");
            entry = Console.ReadLine();
            result = int.TryParse(entry,out option);
            while (!result || (option!=1&&option!=2&&option!=3)){
                Console.WriteLine("Not valid Option.");
                Console.WriteLine("Select another Option:");
                entry = Console.ReadLine();
                result = int.TryParse(entry,out option);
            }
            switch (option){
                case 1:Ch.Attributes.Strength += 1;break;
                case 2:Ch.Attributes.Dexterity += 1;break;
                case 3:Ch.Attributes.Intelligence += 1;break;
            }
            amount--;
            Console.WriteLine("You have {0} Attribute points left to spend.",amount);
        }
    }
    public void YouWon(){
        Console.WriteLine("              ╔═══════════╗");
        Console.WriteLine("              ║ !You Won¡ ║");
        Console.WriteLine("              ╚═══════════╝");
    }
    public void YouLose(){
        Console.WriteLine("         ╔═════════════════════╗");
        Console.WriteLine("         ║ Your Life reached 0 ║");
        Console.WriteLine("         ╚═════════════════════╝");
        Console.WriteLine("             ╔═════════════╗");
        Console.WriteLine("             ║  You Died.  ║");
        Console.WriteLine("             ╚═════════════╝");
    }
    public void End(){
        Console.WriteLine("            ╔═════════════════╗");
        Console.WriteLine("            ║ End of the Game ║");
        Console.WriteLine("            ╚═════════════════╝");
    }
    public void ShowEnemies(Enemies Enem){
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine(" ╬ " + Enem.Description.Name.PadRight(39) + "╬");
        Console.WriteLine(" ╬ Type: " + Enem.Description.Type.PadRight(33) + "╬");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine("   " + Enem.Attributes.Caption+ "             ");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine(" ╬ Level: " + Enem.Attributes.Level.ToString().PadRight(32) + "╬");
        Console.WriteLine(" ╬ Healt: " + Enem.Attributes.Healt.ToString().PadRight(32) + "╬");
        Console.WriteLine(" ╬ Attack: " + Enem.Attributes.Attack.ToString().PadRight(31) + "╬");
        Console.WriteLine(" ╬ Defense: " + Enem.Attributes.Defense.ToString().PadRight(30) + "╬");
        Console.WriteLine(" @════════<<<<══════vvvv══════>>>>════════@");
        Console.WriteLine("--------------------------------------------\n");
    }
}