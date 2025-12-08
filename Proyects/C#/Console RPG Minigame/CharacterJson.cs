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
        string routeProject = Path.Combine(Directory.GetCurrentDirectory(), "Files", FileName + ".json");
        string routeExe = Path.Combine(AppContext.BaseDirectory, "Files", FileName + ".json");
        string[] possiblePaths = { routeProject, routeExe };

        foreach (string path in possiblePaths)
        {
            if (File.Exists(path))
            {
                string content = File.ReadAllText(path);
                if (!string.IsNullOrWhiteSpace(content))
                    return true;
            }
        }
        return false;
    }
    public void SaveMainCh(Character Ch, string FileName){
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true,//it is serialized with indentation and structured, and not in a straight line.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping//it recognizes special characters correctly
        };
        var serialized = JsonSerializer.Serialize(Ch,options);

        //for .EXE executed
        string routeEXE = Path.Combine(AppContext.BaseDirectory, "Files", FileName + ".json");
        FileStream fileEXE = new FileStream(routeEXE,FileMode.Create);
        StreamWriter swEXE = new StreamWriter(fileEXE);
        using(swEXE){
            swEXE.WriteLine("{0}",serialized);
            swEXE.Close();
        }

        //for Visual Studio console
        string route = "Files/" + FileName + ".json";
        FileStream file = new FileStream(route,FileMode.Create);
        StreamWriter sw = new StreamWriter(file);
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
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true,//it is serialized with indentation and structured, and not in a straight line.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping//it recognizes special characters correctly
        };
        var serialized = JsonSerializer.Serialize(ListEnem,options);

        //for .EXE executed
        string routeEXE = Path.Combine(AppContext.BaseDirectory, "Files", FileName + ".json");
        FileStream fileEXE = new FileStream(routeEXE,FileMode.Create);
        StreamWriter swEXE = new StreamWriter(fileEXE);
        using(swEXE){
            swEXE.WriteLine("{0}",serialized);
            swEXE.Close();
        }

        //for Visual Studio console
        string route = "Files/" + FileName + ".json";
        FileStream file = new FileStream(route,FileMode.Create);
        StreamWriter sw = new StreamWriter(file);
        using(sw){
            sw.WriteLine("{0}",serialized);
            sw.Close();
        }
    }
    public List<Enemies> ReadEnemy(string route){   
        string Readed;
        FileStream file = new FileStream(route,FileMode.Open);
        StreamReader sr = new StreamReader(file);
        using(sr){
            Readed = sr.ReadToEnd();
            sr.Close();
        }
        var ListEnem = JsonSerializer.Deserialize<List<Enemies>>(Readed); 
        return(ListEnem);     
    }
    public void SaveConstant(Constants cons, string FileName){
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true,//it is serialized with indentation and structured, and not in a straight line.
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping//it recognizes special characters correctly
        };
        var serialized = JsonSerializer.Serialize(cons,options);

        //for .EXE executed
        string routeEXE = Path.Combine(AppContext.BaseDirectory, "Files", FileName + ".json");
        FileStream fileEXE = new FileStream(routeEXE,FileMode.Create);
        StreamWriter swEXE = new StreamWriter(fileEXE);
        using(swEXE){
            swEXE.WriteLine("{0}",serialized);
            swEXE.Close();
        }

        //for Visual Studio console
        string route = "Files/" + FileName + ".json";
        FileStream file = new FileStream(route,FileMode.Create);
        StreamWriter sw = new StreamWriter(file);
        using(sw){
            sw.WriteLine("{0}",serialized);
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