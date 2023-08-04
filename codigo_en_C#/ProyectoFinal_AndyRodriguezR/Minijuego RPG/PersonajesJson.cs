using System;
namespace EspacioPersonajesJson;
using System.Text.Json;
using System.Text.Encodings.Web;
using System.IO;
using EspacioPersonaje;
using EspacioEnemigos;
using System.Collections.Generic;
using EspacioConstantes;

public class PersonajesJson
{
    public bool ExisteArch(string NombArch){
        string ruta = "Archivos/"+NombArch+".json";
        if(File.Exists(ruta)){
            string Contenido = File.ReadAllText(ruta);
            if (!string.IsNullOrEmpty(Contenido)){
                return(true);    
            }else{
                return(false);
            }
        }else{
            return(false);
        }
    }
    public void GuardarPjPrincipal(Personaje Pj, string NombArch){
        string ruta = "Archivos/" + NombArch + ".json";
        FileStream archivo = new FileStream(ruta,FileMode.Create);
        StreamWriter sw = new StreamWriter(archivo);
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true,// para que se serialize con sangria y estructurado y no en linea recta
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping//para que reconozca bien los caracteres especiales
        };
        var serializado = JsonSerializer.Serialize(Pj,options);
        using(sw){
            sw.WriteLine("{0}",serializado);
            sw.Close();
        }
    }  
    public Personaje LeerPjPrincipal(string ruta){
        string Leido;
        FileStream archivo = new FileStream(ruta,FileMode.Open);
        StreamReader sr = new StreamReader(archivo);
        using (sr){
            Leido = sr.ReadToEnd();
            sr.Close();
        }
        var pj = JsonSerializer.Deserialize<Personaje>(Leido);
        return(pj);
    }
    public void GuardarEnemigo(List<Enemigos> ListEnem, string NombArch){
        string ruta = "Archivos/"+ NombArch +".json";//armo la ruta con el nombre
        FileStream archivo = new FileStream(ruta,FileMode.Create);
        StreamWriter sw = new StreamWriter(archivo);
        /*if (ExisteArch(ruta)){//opcional a "FileStream"
            sw = File.AppendText(ruta);
        }else{
            sw = File.CreateText(ruta);
        }*/
        JsonSerializerOptions options = new JsonSerializerOptions{//agrego opciones de escritura para el .json
            WriteIndented = true,//para que lo escriba deslozado hacia abajo y no en una sola linea
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping//para que reconozca caracteres especiales(de los captions)
        };
        var serializado = JsonSerializer.Serialize(ListEnem,options);//lo serializo en formato json
        using(sw){
            sw.WriteLine("{0}",serializado);
            sw.Close();
        }
    }
    public List<Enemigos> LeerEnemigo(string ruta){   
        string Leido;
        FileStream archivo = new FileStream(ruta,FileMode.Open);
        StreamReader sr = new StreamReader(archivo);
        using(sr){
            Leido = sr.ReadToEnd();
            sr.Close();
        }
        var ListEnem = JsonSerializer.Deserialize<List<Enemigos>>(Leido); 
        return(ListEnem);     
    }
    public void GuardarConstantes(Constantes cons, string NombArch){
        string ruta = "Archivos/" + NombArch + ".json";
        FileStream archivo = new FileStream(ruta,FileMode.Create); 
        StreamWriter sw = new StreamWriter(archivo);
        JsonSerializerOptions options = new JsonSerializerOptions{
            WriteIndented = true,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping 
        };
        var serializado = JsonSerializer.Serialize(cons,options);
        using(sw){
            sw.WriteLine("{0}",serializado);
            sw.Close();  
        }
    }
    public Constantes LeerConstantes(string ruta){
        string Leido;
        FileStream archivo = new FileStream(ruta,FileMode.Open);
        StreamReader sr = new StreamReader(archivo);
        using (sr){
            Leido = sr.ReadToEnd();
            sr.Close();
        }
        var cons = JsonSerializer.Deserialize<Constantes>(Leido);
        return(cons);
    }
}