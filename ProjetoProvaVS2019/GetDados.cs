using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Json;
using ProvaAdmissionalCSharpApisul.model;
using Newtonsoft.Json;
using System.IO;

namespace ProvaAdmissionalCSharpApisul
{
    public  static class GetDados
    {

       public  static List<Dados> Load( string path = "")
        {
            List<Dados> ret = new List<Dados>();
            var Path =  path.Length > 0 ? path : AppDomain.CurrentDomain.BaseDirectory + "input.json";
            if ( File.Exists (Path))
            {
               

                using (StreamReader r = new StreamReader(Path))
                {
                    string json = r.ReadToEnd();
                    ret = JsonConvert.DeserializeObject<List<Dados>>(json);
                }

            }
            else
            {
                Console.WriteLine("Arquivo de ~dados não localizado!");
            }

           

            return ret;
        }

    }
}
