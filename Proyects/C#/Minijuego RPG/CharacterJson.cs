using System;
namespace SpaceCharacterJson;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.IO;
using SpaceCharacter;
using SpaceEnemies;
using System.Collections.Generic;
using SpaceConstants;

public class CharacterJson
{
    public bool FileExists(string FileName){
        string route = "Archivos/"+FileName+".json";
        if(File.Exists(route)){
            string Content = File.ReadAllText(route);
            if (!string.IsNullOrEmpty(Content)){
                return(true);    
            }else{
                return(false);
            }
        }else{
            return(false);
        }
    }
    public void SaveMainCh(Character Ch, string FileName){
        string ruta = "Archivos/" + FileName + ".json";
        FileStream file = new FileStream(ruta,FileMode.Create);
        StreamWriter sw = new StreamWriter(file);
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true,//it is serialized with indentation and structured, and not in a straight line.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping//it recognizes special characters correctly
        };
        var serialized = JsonSerializer.Serialize(Ch,options);
        using(sw){
            sw.WriteLine("{0}",serialized);
            sw.Close();
        }
    }  
    public Character ReadMainCh(string route){
        string Readed;
        FileStream file = new FileStream(route,FileMode.Open);
        StreamReader sr = new StreamReader(file);
        using (sr){
            Readed = sr.ReadToEnd();
            sr.Close();
        }
        var Ch = JsonSerializer.Deserialize<Character>(Readed);
        return(Ch);
    }
    public void SaveEnemy(List<Enemies> ListEnem, string FileName){
        string route = "Archivos/"+ FileName +".json";
        FileStream file = new FileStream(route,FileMode.Create);
        StreamWriter sw = new StreamWriter(file);
        /*if (ExisteArch(ruta)){//optional to "FileStream"
            sw = File.AppendText(ruta);
        }else{
            sw = File.CreateText(ruta);
        }*/
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        var serialized = JsonSerializer.Serialize(ListEnem,options);
        using(sw){
            sw.WriteLine("{0}",serialized);
            sw.Close();
        }
    }
    public List<Enemies> ReadEnemy(string routr){   
        string Readed;
        FileStream file = new FileStream(routr,FileMode.Open);
        StreamReader sr = new StreamReader(file);
        using(sr){
            Readed = sr.ReadToEnd();
            sr.Close();
        }
        var ListEnem = JsonSerializer.Deserialize<List<Enemies>>(Readed); 
        return(ListEnem);     
    }
    public void SeveConstant(Constants cons, string FileName){
        string route = "Archivos/" + FileName + ".json";
        FileStream file = new FileStream(route,FileMode.Create); 
        StreamWriter sw = new StreamWriter(file);
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
        };
        var serielized = JsonSerializer.Serialize(cons,options);
        using(sw){
            sw.WriteLine("{0}",serielized);
            sw.Close();  
        }
    }
    public Constants ReadConstant(string route){
        string Readed;
        FileStream file = new FileStream(route,FileMode.Open);
        StreamReader sr = new StreamReader(file);
        using (sr){
            Readed = sr.ReadToEnd();
            sr.Close();
        }
        var cons = JsonSerializer.Deserialize<Constants>(Readed);
        return(cons);
    }
}