namespace EspacioTomarApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using EspacioItems;
using EspacioPersonaje;
using System.Text.Encodings.Web;

public class TomarApi{
    private List<string> listaCascos = new List<string>();
    private List<string> listaArmaduras = new List<string>();
    private List<string> listaGuantes = new List<string>();
    private List<string> listaCinturones = new List<string>();
    private List<string> listaBotas = new List<string>();
    private List<string> listaAnillos = new List<string>();
    private List<string> listaAmuletos = new List<string>();
    private List<string> listaEspadas = new List<string>();
    private List<string> listaEscudos = new List<string>();
    private List<string> listaDagas = new List<string>();
    private List<string> listaBaculos = new List<string>();
    private List<string> listaCristales = new List<string>();

    public List<string> ListaCascos { get => listaCascos; set => listaCascos = value; }
    public List<string> ListaArmaduras { get => listaArmaduras; set => listaArmaduras = value; }
    public List<string> ListaGuantes { get => listaGuantes; set => listaGuantes = value; }
    public List<string> ListaCinturones { get => listaCinturones; set => listaCinturones = value; }
    public List<string> ListaBotas { get => listaBotas; set => listaBotas = value; }
    public List<string> ListaAnillos { get => listaAnillos; set => listaAnillos = value; }
    public List<string> ListaAmuletos { get => listaAmuletos; set => listaAmuletos = value; }
    public List<string> ListaEspadas { get => listaEspadas; set => listaEspadas = value; }
    public List<string> ListaEscudos { get => listaEscudos; set => listaEscudos = value; }
    public List<string> ListaDagas { get => listaDagas; set => listaDagas = value; }
    public List<string> ListaBaculos { get => listaBaculos; set => listaBaculos = value; }
    public List<string> ListaCristales { get => listaCristales; set => listaCristales = value; }


    //https://www.dnd5eapi.co/api/magic-items 
    public void ObtenerItem(){
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
                        //Console.WriteLine("Numeros de item: {0}",item.count);
                        List<Result> listaItems = item.results;
                        foreach (var Item in listaItems)//crea las listas para cada tipo de equipo
                        {
                            if (Item.name.Contains("helm") || Item.name.Contains("Helm")){
                                ListaCascos.Add(Item.name);
                            } 
                            if (Item.name.Contains("armor") || Item.name.Contains("Armor")){
                                ListaArmaduras.Add(Item.name);
                            } 
                            if (Item.name.Contains("gauntlets") || Item.name.Contains("Gauntlets")){
                                ListaGuantes.Add(Item.name);
                            } 
                            if (Item.name.Contains("belt") || Item.name.Contains("Belt")){
                                ListaCinturones.Add(Item.name);
                            } 
                            if (Item.name.Contains("boots") || Item.name.Contains("Boots")){
                                ListaBotas.Add(Item.name);
                            } 
                            if (Item.name.Contains("ring of") || Item.name.Contains("Ring of")){
                                ListaAnillos.Add(Item.name);
                            } 
                            if (Item.name.Contains("amulet") || Item.name.Contains("Amulet")){
                                ListaAmuletos.Add(Item.name);
                            } 
                            if (Item.name.Contains("sword") || Item.name.Contains("Sword")){
                                ListaEspadas.Add(Item.name);
                            } 
                            if (Item.name.Contains("shield") || Item.name.Contains("Shield")){
                                ListaEscudos.Add(Item.name);
                            } 
                            if (Item.name.Contains("dagger") || Item.name.Contains("Dagger")){
                                ListaDagas.Add(Item.name);
                            } 
                            if (Item.name.Contains("staf") || Item.name.Contains("Staf")){
                                ListaBaculos.Add(Item.name);
                            } 
                            if (Item.name.Contains("crystal ball") || Item.name.Contains("Crystal Ball")){
                                ListaCristales.Add(Item.name);
                            } 
                        }
                        //personaliza las listas
                            ListaArmaduras.Remove("Armor, +1, +2, or +3");
                            ListaArmaduras.Remove("Armor, +1");
                            ListaArmaduras.Remove("Armor, +2");
                            ListaArmaduras.Remove("Armor, +3");
                            ListaEscudos.Remove("Brooch of Shielding");
                            ListaEscudos.Remove("Ring of Mind Shielding");
                            ListaCristales.Remove("Crystal Ball");
                            ListaGuantes.Add("Gauntlets of Dragon Scales");
                            ListaGuantes.Add("Iron Gauntlets");
                            ListaGuantes.Add("Rags Gauntlets");
                            ListaDagas.Add("Dagger of Blood");
                            ListaDagas.Add("Sharp Dagger");
                            ListaDagas.Add("Assassin's Daggers");
                        //personaliza las listas-FIN
                    }
                }
            }
        }
    }
    catch (WebException)
    {
        Console.WriteLine("Problemas en el acceso a la API");
    }
    }
    
}


