namespace SpaceCharacterFactory;
using System;
using SpaceCharacter;
using SpaceEnemies;
using SpaceConstants;
using SpaceMechanics;
using SpaceTakeApi;

public class CharacterFactory{
    public Character CreateCharacter(Character Ch, TakeApi takeApi){
        Random random = new Random();
        Ch.Equipment = new Character.equipment();
        string entry,date;
        bool result;
        int day, month, year, clase;
        DateTime Date;
        entry = Console.ReadLine();
        result = int.TryParse(entry,out clase);
        while (!result || (clase!=1 && clase!=2 && clase!=3)){
            Console.WriteLine("Not valid option.");
            Console.WriteLine("Enter other option: ");
            entry = Console.ReadLine();
            result = int.TryParse(entry,out clase);
        }
        //enter name
        Console.WriteLine("Enter name: ");
        entry = Console.ReadLine();
        while (!IsWord(entry)){
            Console.WriteLine("The name cannot contain numbers or special characters.");
            Console.WriteLine("Enter name: ");
            entry = Console.ReadLine();
        }
        while (entry=="" || entry==" "){
            Console.WriteLine("The name cannot be empty.");
            Console.WriteLine("Enter name: ");
            entry = Console.ReadLine();
        }
        while (entry.Length>10){
            Console.WriteLine("The name size only supports 10 characters.");
            Console.WriteLine("Enter name: ");
            entry = Console.ReadLine();
        }
        Ch.Description.Name=entry;
        //enter name -end
        //enter nickname
        Console.WriteLine("Enter nickname: ");
        entry = Console.ReadLine();
        while (!IsWord(entry)){
            Console.WriteLine("The nickname cannot contain numbers or special characters.");
            Console.WriteLine("Enter nickname: ");
            entry = Console.ReadLine();
        }
        while (entry=="" || entry==" "){
            Console.WriteLine("The nickname cannot be empty.");
            Console.WriteLine("Enter nickname: ");
            entry = Console.ReadLine();
        }
        while (entry.Length>10){
            Console.WriteLine("The nickname size only supports 10 characters.");
            Console.WriteLine("Enter nickname: ");
            entry = Console.ReadLine();
        }
        Ch.Description.Nickname=entry;
        //enter nickname -end
        
        Console.WriteLine("Enter your date of birth: ");
        //entrar day
        Console.WriteLine("Day: ");
        entry = Console.ReadLine();
        result = int.TryParse(entry, out day);
        while (!result || day<0 || day>31){
            Console.WriteLine("The day entered is not valid");
            Console.WriteLine("Day: ");
            entry = Console.ReadLine();
            result = int.TryParse(entry, out day);
        }
        //enter day -end
        //enter month
        Console.WriteLine("Month: ");
        entry = Console.ReadLine();
        result = int.TryParse(entry, out month);
        while (!result || month<0 || month>12){
            Console.WriteLine("The month entered is not valid");
            Console.WriteLine("Month: ");
            entry = Console.ReadLine();
            result = int.TryParse(entry, out month);
        }
        //enter month -end
        //enter year
        Console.WriteLine("Year: ");
        entry = Console.ReadLine();
        result = int.TryParse(entry, out year);
        while (!result || year<1920 || year>2023){
            Console.WriteLine("The year entered is not valid");
            Console.WriteLine("Year: ");
            entry = Console.ReadLine();
            result = int.TryParse(entry, out year);
        }
        //enter year -end
        //set up Date
        date = month + "/" + day + "/" + year;
        Date = DateTime.Parse(date);
        Ch.Description.Birthdate=Date;
        //set up Date -end
        //set up Equipment
        int rand=0;
        rand = random.Next(takeApi.HelmetsList.Count);
        Ch.Equipment.Helmet=takeApi.HelmetsList[rand];
        takeApi.HelmetsList.RemoveAt(rand);

        rand = random.Next(takeApi.ChestsList.Count);
        Ch.Equipment.Chest=takeApi.ChestsList[rand];
        takeApi.ChestsList.RemoveAt(rand);

        rand = random.Next(takeApi.GlovesList.Count);
        Ch.Equipment.Gloves=takeApi.GlovesList[rand];
        takeApi.GlovesList.RemoveAt(rand);

        rand = random.Next(takeApi.BeltsList.Count);
        Ch.Equipment.Belt=takeApi.BeltsList[rand];
        takeApi.BeltsList.RemoveAt(rand);

        rand = random.Next(takeApi.BootsList.Count);
        Ch.Equipment.Boots=takeApi.BootsList[rand];
        takeApi.BootsList.RemoveAt(rand);

        rand = random.Next(takeApi.RingsList.Count);
        Ch.Equipment.Ring=takeApi.RingsList[rand];
        takeApi.RingsList.RemoveAt(rand);

        rand = random.Next(takeApi.AmuletList.Count);
        Ch.Equipment.Amulet=takeApi.AmuletList[rand];
        takeApi.AmuletList.RemoveAt(rand);
        
        //arma Equipment-fin
        Ch.Description.Age=AgeCalc(Date);
        switch (clase){
            case 1: Ch.Attributes.Strength = 30;Ch.Attributes.Dexterity=20;Ch.Attributes.Intelligence=10;Ch.Attributes.Type="Warrior";
                    Ch.Attributes.Caption = @"        
                \  @
                 \/█|██|
                 _/ \_";
                 rand = random.Next(takeApi.ShieldsList.Count);
                 Ch.Equipment.LeftHand=takeApi.ShieldsList[rand];
                 takeApi.ShieldsList.RemoveAt(rand);

                 rand = random.Next(takeApi.SwordsList.Count);
                 Ch.Equipment.RigthHand=takeApi.SwordsList[rand];
                 takeApi.SwordsList.RemoveAt(rand);
                 break;
            case 2: Ch.Attributes.Strength = 10;Ch.Attributes.Dexterity=20;Ch.Attributes.Intelligence=30;Ch.Attributes.Type="Mage";
            Ch.Attributes.Caption = @"       
                     ▄
                 \Ô__|
                 /█\ |
                 ! !";
                 rand = random.Next(takeApi.StafsList.Count);
                 Ch.Equipment.LeftHand=takeApi.StafsList[rand];
                 takeApi.StafsList.RemoveAt(rand);

                 rand = random.Next(takeApi.CrystalsList.Count);
                 Ch.Equipment.RigthHand=takeApi.CrystalsList[rand];
                 takeApi.CrystalsList.RemoveAt(rand);
                 break;
            case 3: Ch.Attributes.Strength = 10;Ch.Attributes.Dexterity=30;Ch.Attributes.Intelligence=20;Ch.Attributes.Type="Assasin";
            Ch.Attributes.Caption = @"    
                   Ø/\,
                 \/█
                 _/ \_";
                 rand = random.Next(takeApi.DaggerList.Count);
                 Ch.Equipment.LeftHand=takeApi.DaggerList[rand];
                 takeApi.DaggerList.RemoveAt(rand);

                 rand = random.Next(takeApi.DaggerList.Count);
                 Ch.Equipment.RigthHand=takeApi.DaggerList[rand];
                 takeApi.DaggerList.RemoveAt(rand);
                 break;
        }
        return(Ch);
    }
    public string DropItem(Character Ch,TakeApi takeApi){        
        Random random = new Random();
        int NumbList = random.Next(0,6);
        int NumbName=0;
        int amount=0;
        string name=null;
        switch (NumbList)
        {
            case 0: amount = takeApi.HelmetsList.Count;
                    NumbName = random.Next(amount);
                    name = takeApi.HelmetsList[NumbName];
                    Ch.Equipment.Helmet = name ;
            break;
            case 1: amount = takeApi.ChestsList.Count;
                    NumbName = random.Next(amount);
                    name = takeApi.ChestsList[NumbName];
                    Ch.Equipment.Chest = name ;
            break;
            case 2: amount = takeApi.GlovesList.Count;
                    NumbName = random.Next(amount);
                    name = takeApi.GlovesList[NumbName];
                    Ch.Equipment.Gloves = name ;
            break;
            case 3: amount = takeApi.BeltsList.Count;
                    NumbName = random.Next(amount);
                    name = takeApi.BeltsList[NumbName];
                    Ch.Equipment.Belt = name ;
            break;
            case 4: amount = takeApi.BootsList.Count;
                    NumbName = random.Next(amount);
                    name = takeApi.BootsList[NumbName];
                    Ch.Equipment.Boots = name ;
            break;
            case 5: amount = takeApi.RingsList.Count;
                    NumbName = random.Next(amount);
                    name = takeApi.RingsList[NumbName];
                    Ch.Equipment.Ring = name ;
            break;
            case 6: amount = takeApi.AmuletList.Count;
                    NumbName = random.Next(amount);
                    name = takeApi.AmuletList[NumbName];
                    Ch.Equipment.Amulet = name ;
            break;
        }
        return(name);
    }
    public Enemies GenerateEnemie(Enemies Enem, int level){
        Constants Const = new Constants(); 
        Mechanics Mec = new Mechanics();
        Enem.Description.Type = Const.monster[Mec.GenerateRandom(1,3)];
        Enem.Description.Name = Enem.Description.Type + " " + Const.names[Mec.GenerateRandom(1,10)];
        Enem.Attributes.Level = level;
        switch (Enem.Description.Type){
            case "Dragon":
            Enem.Attributes.Caption = @"                                     /\____/\/\/\/\/\
                                    / °    o  ///  
                                    vvvvv¨¨\  \\\ D_D_D
                                    vvvvv../ /_/_/_/_
                                    \________/";
            Enem.Attributes.Healt = 1000 + Enem.Attributes.Level*100;
            Enem.Attributes.Attack = 100 + Enem.Attributes.Level*10;
            Enem.Attributes.Defense = 100 + Enem.Attributes.Level*5;
            break;
            case "Undead":
            Enem.Attributes.Caption  = @"                                   _/_/_/_/_
                                  |__      |
                                   _°|    _|
                                   \    _/_______
                                   nn¨¨\\__|__|_
                                    nn..//
                                    \___/";
            Enem.Attributes.Healt = 800 + Enem.Attributes.Level*100;
            Enem.Attributes.Attack = 80 + Enem.Attributes.Level*10;
            Enem.Attributes.Defense = 90 + Enem.Attributes.Level*5;
            break;
            case "Demon":
            Enem.Attributes.Caption  = @"                                    /\      /\
                                  _/ /      \ \
                                 / \ \______/ /\
                                 \ o    o  /_/ /
                                 / ..       __ \___ 
                                 \VVVVVVVV\/   / /
                                     |___|  __\_\_
                                    /VVVVV\ /    
                                    \______/";
            Enem.Attributes.Healt = 900 + Enem.Attributes.Level*100;
            Enem.Attributes.Attack = 90 + Enem.Attributes.Level*10;
            Enem.Attributes.Defense = 80 + Enem.Attributes.Level*5;
            break;
        }
        return(Enem);
    } 
    public static int AgeCalc(DateTime Date){
        int Age;
        DateTime today = DateTime.Today;
        Age = today.Year - Date.Year;
        if (Date > today.AddYears(-Age)){
            Age--;
        }
        return(Age);
    }
    public static bool IsWord(string word){
        foreach (char letter in word){ 
            /*if (!char.IsLetterOrDigit(letter)){
                return(false);  
            }else if (char.IsDigit(letter)){
                return(false);
            }*/
            if (!char.IsLetter(letter)){
                return(false);  
            }
        }
        return(true);
    }
}




