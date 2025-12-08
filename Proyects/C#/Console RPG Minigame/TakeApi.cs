namespace SpaceTakeApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using SpaceItems;
using SpaceCharacter;
using System.Text.Encodings.Web;

public class TakeApi{
    private List<string> helmetsList = new List<string>();
    private List<string> chestsList = new List<string>();
    private List<string> glovesList = new List<string>();
    private List<string> beltsList = new List<string>();
    private List<string> bootsList = new List<string>();
    private List<string> ringsList = new List<string>();
    private List<string> amuletList = new List<string>();
    private List<string> swordsList = new List<string>();
    private List<string> shieldsList = new List<string>();
    private List<string> daggerList = new List<string>();
    private List<string> stafsList = new List<string>();
    private List<string> crystalsList = new List<string>();

    public List<string> HelmetsList { get => helmetsList; set => helmetsList = value; }
    public List<string> ChestsList { get => chestsList; set => chestsList = value; }
    public List<string> GlovesList { get => glovesList; set => glovesList = value; }
    public List<string> BeltsList { get => beltsList; set => beltsList = value; }
    public List<string> BootsList { get => bootsList; set => bootsList = value; }
    public List<string> RingsList { get => ringsList; set => ringsList = value; }
    public List<string> AmuletList { get => amuletList; set => amuletList = value; }
    public List<string> SwordsList { get => swordsList; set => swordsList = value; }
    public List<string> ShieldsList { get => shieldsList; set => shieldsList = value; }
    public List<string> DaggerList { get => daggerList; set => daggerList = value; }
    public List<string> StafsList { get => stafsList; set => stafsList = value; }
    public List<string> CrystalsList { get => crystalsList; set => crystalsList = value; }


    //https://www.dnd5eapi.co/api/magic-items 
    public void TakeItem(){
    var url = $"https://www.dnd5eapi.co/api/magic-items";
    var request = (HttpWebRequest)WebRequest.Create(url);
    request.Method = "GET";
    request.ContentType =  "aplication/json";
    request.Accept =  "aplication/json";
    try{ 
        using (WebResponse response = request.GetResponse())
        {
            using (Stream str = response.GetResponseStream())
            {
                if (str == null) return;
                {
                    using (StreamReader strR = new StreamReader(str))
                    {
                        string responseBody = strR.ReadToEnd();
                        Items item = JsonSerializer.Deserialize<Items>(responseBody);
                        //Console.WriteLine("Numbers of items: {0}",item.count);
                        List<Result> itemsList = item.results;
                        foreach (var Item in itemsList)
                        {
                            if (Item.name.Contains("helm") || Item.name.Contains("Helm")){
                                HelmetsList.Add(Item.name);
                            } 
                            if (Item.name.Contains("armor") || Item.name.Contains("Armor")){
                                ChestsList.Add(Item.name);
                            } 
                            if (Item.name.Contains("gauntlets") || Item.name.Contains("Gauntlets")){
                                GlovesList.Add(Item.name);
                            } 
                            if (Item.name.Contains("belt") || Item.name.Contains("Belt")){
                                BeltsList.Add(Item.name);
                            } 
                            if (Item.name.Contains("boots") || Item.name.Contains("Boots")){
                                BootsList.Add(Item.name);
                            } 
                            if (Item.name.Contains("ring of") || Item.name.Contains("Ring of")){
                                RingsList.Add(Item.name);
                            } 
                            if (Item.name.Contains("amulet") || Item.name.Contains("Amulet")){
                                AmuletList.Add(Item.name);
                            } 
                            if (Item.name.Contains("sword") || Item.name.Contains("Sword")){
                                SwordsList.Add(Item.name);
                            } 
                            if (Item.name.Contains("shield") || Item.name.Contains("Shield")){
                                ShieldsList.Add(Item.name);
                            } 
                            if (Item.name.Contains("dagger") || Item.name.Contains("Dagger")){
                                DaggerList.Add(Item.name);
                            } 
                            if (Item.name.Contains("staf") || Item.name.Contains("Staf")){
                                StafsList.Add(Item.name);
                            } 
                            if (Item.name.Contains("crystal ball") || Item.name.Contains("Crystal Ball")){
                                CrystalsList.Add(Item.name);
                            } 
                        }
                        //edit on Lists
                            ChestsList.Remove("Armor, +1, +2, or +3");
                            ChestsList.Remove("Armor, +1");
                            ChestsList.Remove("Armor, +2");
                            ChestsList.Remove("Armor, +3");
                            ShieldsList.Remove("Brooch of Shielding");
                            ShieldsList.Remove("Ring of Mind Shielding");
                            CrystalsList.Remove("Crystal Ball");
                            GlovesList.Add("Gauntlets of Dragon Scales");
                            GlovesList.Add("Iron Gauntlets");
                            GlovesList.Add("Rags Gauntlets");
                            DaggerList.Add("Dagger of Blood");
                            DaggerList.Add("Sharp Dagger");
                            DaggerList.Add("Assassin's Daggers");
                        //edit on Lists-END
                    }
                }
            }
        }
    }
    catch (WebException)
    {
        Console.WriteLine("Problems with API access");
    }
    }  
}


