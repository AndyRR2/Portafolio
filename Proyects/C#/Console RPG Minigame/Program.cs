using System;
using SpaceCharacter;
using SpaceCharacterFactory;
using SpaceScreens;
using SpaceEnemies;
using SpaceCharacterJson;
using SpaceMechanics;
using SpaceConstants;
using SpaceTakeApi;

public class Program{
    private static void Main(){
        string entry;
        bool flag = true;
        Character MainCh;
        TakeApi takeApi = new TakeApi();
        takeApi.TakeItem();
    /*//Optional-Writes items lists
        Console.WriteLine("Helmets: ");
        foreach (var item in TakeApi.HelmetsList)
        {
            Console.WriteLine("{0}",item);
        }
        Console.WriteLine("\n");
    //Optional-Writes items lists-End*/
    //Class instances to use----------------------------------------------------------------------------------
        Screens print = new Screens();
        CharacterFactory factory = new CharacterFactory();
        Mechanics mec = new Mechanics();
        Constants cons = new Constants();
        cons.Values = new Constants.MaxValues();
        CharacterJson charact = new CharacterJson();
        MainCh = new Character();
        MainCh.Attributes = new Character.attributes();
        MainCh.Description = new Character.description();
        var EnemiesList = new List<Enemies>();
    //Class instances to use - End-----------------------------------------------------------------------------
        
    //Game Starts
    print.InitialMessage();
    //Main Screen------------------------------------------------------------------------------------------------------------
        int option=0;//variable continue/new game/exit
        int option2=3;
        int option3=6;

        while (flag==true)
        {
            print.MainScreen();
            entry = Console.ReadLine();
            bool result = int.TryParse(entry,out option);
            while (!result || (option!=1 && option!=2 && option!=3)){//it is not a valid option
                Console.WriteLine("   Not valid Option.");
                Console.WriteLine("   Enter another Option: ");
                entry = Console.ReadLine();
                result = int.TryParse(entry,out option);
            }
            
            //when there is no saved game and "continue" is selected-----------------------------------------------------------------
            while (option==1 && (!charact.FileExists("Character") || !charact.FileExists("Enemies") || !charact.FileExists("Constants"))){
                Console.WriteLine("   There are none saved game.");
                Console.WriteLine("   Enter another Option: ");
                entry = Console.ReadLine();
                result = int.TryParse(entry,out option);
            }
            //when there is no saved game and "continue" is selected-End------------------------------------------------------------  
            
            Console.Clear();
            
            //New Game-----------------------------------------------------------------------------------------------------------
            if (option==2){
                //create character----------------------------------------------------------------------------------------------
                if (charact.FileExists("Character")){
                    MainCh = new Character();
                    MainCh.Attributes = new Character.attributes();
                    MainCh.Description = new Character.description();   
                }
                print.Class();
                MainCh = factory.CreateCharacter(MainCh,takeApi);
                MainCh = mec.UpdateValuesCh(MainCh,1,MainCh.Attributes.Health,MainCh.Attributes.Mana);
                
                charact.SaveMainCh(MainCh,"Character");//save character in json file
                //create character- End-------------------------------------------------------------------------------------------
            
                //Console.Clear();
            
                //create enemies------------------------------------------------------------------------------------------------
                if (charact.FileExists("Enemies")){
                    EnemiesList = new List<Enemies>();
                }
                for (int i = 0; i < 10; i++){//creates each one of enemies
                    Enemies Enem = new Enemies();
                    Enem.Description = new Enemies.description();
                    Enem.Attributes =new Enemies.attributes();
                    Enem = factory.GenerateEnemie(Enem,1);
                    EnemiesList.Add(Enem);
                }
                
                charact.SaveEnemy(EnemiesList,"Enemies");
                //create enemies-End--------------------------------------------------------------------------------------------  

                //establish constants--------------------------------------------------------------------------------
                if (charact.FileExists("Constants")){
                    cons = new Constants();
                    cons.Values = new Constants.MaxValues();
                }
                cons.Values.ChLpMax = MainCh.Attributes.Health;
                cons.Values.ChMpMax = MainCh.Attributes.Mana;
                cons.Values.EnemLpMax = EnemiesList[0].Attributes.Healt;//establishes current enemy life
                
                charact.SeveConstant(cons,"Constants");
                //establish constants-End----------------------------------------------------------------------------

            //continue saved game------------------------------------------------------------------------
            }else if(option==1){
                MainCh = charact.ReadMainCh("Archivos/Character.json");
                EnemiesList = charact.ReadEnemy("Archivos/Enemies.json");
                cons = charact.ReadConstant("Archivos/Constants.json");
            //continue saved game - End------------------------------------------------------------------
            
            //exit game (With the flag set to false, the game doesn't enter the next if statement and ends)
            }else if (option==3){
                flag = false;
            }
            //New game - End-----------------------------------------------------------------------------------------------------------
                
            option=0;//restar option variable
            //Main Screen - End-------------------------------------------------------------------------------------------------------  
            
            /*Optional for Control-Enemies Tab Screen----------------------------------    
                foreach (var Enem in EnemiesList){
                    print.MostrarEnemigo(Enem);
                }
            Optional for Control-Enemies Tab Screen-End----------------------------------------- */

            //Game progress------------------------------------------------------------------------------------------------------------------------     
            int costMp1,costMp2;
            
            if (flag){
                //Character Tab Screen-------------------------------------------------------------------------------------------------------
                Console.WriteLine("   Character Tab:\n");
                print.ShowChTab(MainCh, cons.Values.ChLpMax, cons.Values.ChMpMax);
                Console.WriteLine("   Press Enter to continue.\n");
                Console.ReadLine();
                //Console.Clear();
                //Character Tab Screen-End---------------------------------------------------------------------------------------------------
            
                //Messages----------------------------------------------------------------------------------------------------------
                print.EnterToDungeon();
                Console.ReadLine();
                print.EnemiesAppear();
                Console.ReadLine();
                //Console.Clear();
                //Messages-End------------------------------------------------------------------------------------------------------
            
                //Esenary repetition-----------------------------------------------------------------------------------------------------------
                option2=0;
                while (EnemiesList.Count!=0 && MainCh.Attributes.Health>0 && option2!=3 ){
                    costMp1 = cons.Values.ChMpMax*35/100;//establishes a new power cost
                    costMp2 = cons.Values.ChMpMax*20/100;//establishes a new power cost
                    if (MainCh.Attributes.Type=="Mage"){
                        costMp1 -= (costMp1*50)/100;
                        costMp2 -= (costMp2*50)/100;
                    }
                    if (option3==6){
                        print.DungeonScreen(MainCh,EnemiesList[0],cons.Values.ChLpMax,cons.Values.ChMpMax,cons.Values.EnemLpMax, cons.Values.RequiredExp);
                    }else if (option3==5){
                        print.InventoryScreen(MainCh,EnemiesList[0],cons.Values.ChLpMax,cons.Values.ChMpMax,cons.Values.EnemLpMax, cons.Values.RequiredExp);
                    }
                    string entry2 = Console.ReadLine();
                    result = int.TryParse(entry2, out option2);
                    while (((!result) || (option2!=1&&option2!=2&&option2!=3&&option2!=4&&option2!=5&&option2!=6))&& entry2!="D"){
                        Console.WriteLine("Not valid Option.");
                        Console.WriteLine("Enter another Option: ");
                        entry2 = Console.ReadLine();
                        result = int.TryParse(entry2, out option2);
                    }
                    if (entry2 == "D"){//Hidden developer option (destroy enemy)
                    EnemiesList[0].Attributes.Healt=0;
                    }   

                    //actions for option2---------------------------------------------------------------------------------------
                    switch (option2){
                        case 1:
                        EnemiesList[0]=mec.LoseLpEnemie(EnemiesList[0],MainCh,1,costMp1);//execute attack
                        break;
                        case 2:
                        EnemiesList[0]=mec.LoseLpEnemie(EnemiesList[0],MainCh,2,costMp1);//execute power
                        break;
                        case 3:
                        Console.WriteLine("   You escaped...");
                        break;
                        case 4:MainCh=mec.GainLpCharacter(MainCh,(cons.Values.ChLpMax*30)/100 + (cons.Values.ChMpMax*30)/100,costMp2,cons.Values.ChLpMax);//execute heal
                        break;
                        case 5: option3=5;
                        break;
                        case 6: option3=6;
                        break;
                    }    
                    //actions for option2-fin-----------------------------------------------------------------------------------
                
                    //continuation of the game if he didn't escape-----------------------------------------------------------------------------------------
                    if (option2!=3){
                        //where an enemy is killed---------------------------------------------------------------------------------------------    
                        if (EnemiesList[0].Attributes.Healt<=0){
                        //Console.Clear();
                        print.EnemyKilledScreen(EnemiesList[0].Description.Type);
                        string item = factory.DropItem(MainCh,takeApi);
                        Console.WriteLine("The monster drop an item: " + item);
                        Console.WriteLine("You equiped the item automatically");
                        Console.ReadLine();
                            //level up Character----------------------------------------------------------------------------------------------
                            MainCh.Attributes.Exp += cons.Values.EnemLpMax;//gain experience
                            if (cons.Values.RequiredExp <= MainCh.Attributes.Exp){//level up if reach experience requeriment
                                //Console.Clear();
                                print.LevelUp(MainCh);
                                MainCh = mec.UpdateValuesCh(MainCh,MainCh.Attributes.Level+1,cons.Values.ChLpMax,cons.Values.ChMpMax);//+ 1 level
                                cons.Values.RequiredExp = MainCh.Attributes.Exp*2;//actualice experiene requeriment 
                                cons.Values.ChLpMax = MainCh.Attributes.Health;//saved new Lp
                                cons.Values.ChMpMax = MainCh.Attributes.Mana;//saved new Mp
                            }
                            //level up Character-End------------------------------------------------------------------------------------------

                            //to the next enemy-------------------------------------------------------------------------------------    
                            EnemiesList = mec.DestroyEnemie(EnemiesList, EnemiesList[0]);//destroy current enemy
                            if (EnemiesList.Count!=0){
                                foreach (var Enem in EnemiesList){//level up the rest of enemies
                                    Enem.Attributes.Level += 1;
                                }
                                EnemiesList[0] = mec.UpdateValuesE(EnemiesList[0]);//update enemies values
                                cons.Values.EnemLpMax = EnemiesList[0].Attributes.Healt;
                            }
                            //to the next enemy-End---------------------------------------------------------------------------------
                        
                        //where an enemy is killed-fin----------------------------------------------------------------------------------------

                        //enemy turn---------------------------------------------------------------------------------------
                        }else if (option2!=5 && option2!=6){
                            Console.WriteLine("Enemy attack, you lose heal...");
                            Console.ReadLine();
                            MainCh = mec.LoseLpCharacter(EnemiesList[0], MainCh);//execute enemy attack
                        }
                        //enemy turn-fin-----------------------------------------------------------------------------------   
                    }
                    //saved bew files for the character/enemies and constants
                    charact.SaveMainCh(MainCh,"Character");
                    charact.SaveEnemy(EnemiesList,"Enemies"); 
                    charact.SeveConstant(cons,"Constants");
                    //Console.Clear();
                    //continuation of the game if he didn't escape-fin-------------------------------------------------------------------------------------    
                }
                //Esenary repetition-End-------------------------------------------------------------------------------------------------------
            
                //when you won the game-----------------------------------------    
                if (EnemiesList.Count==0){
                    Console.WriteLine("   You kill all enemies.");
                    print.YouWon(); 
                }
                //when you won the game-End------------------------------------- 

                //when you lose------------------------------------------------
                if (MainCh.Attributes.Health<=0){
                    MainCh = print.ChKilled(MainCh);
                    print.YouLose();
                }  
                //when you lose-End-------------------------------------------- 
            Console.ReadLine();
            }
                //final state--------------------------------------------------------------------------------------------------------------
                Console.WriteLine("   Final state of Character: ");
                print.ShowChTab(MainCh,cons.Values.ChLpMax,cons.Values.ChMpMax); 
                print.End();
                Console.ReadLine();  
                //final state-End----------------------------------------------------------------------------------------------------------
            //Desarrollo del juego-fin--------------------------------------------------------------------------------------------------------------------       
        }
        Console.WriteLine("   Game closed...");
        Console.WriteLine("\n");
        if (MainCh.Attributes.Health<=0 || EnemiesList.Count==0)
        {
            File.Delete("Archivos/Constants.json"); 
            File.Delete("Archivos/Enemies.json");
            File.Delete("Archivos/Character.json");
        }
    }
}


