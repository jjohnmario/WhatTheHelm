using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatTheHelmRuntime
{
    public enum RpmSource { YoctopuceUsb, NMEA2000 }
    public class Configuration
    {
        public double WaterDepthOffset { get; set; }
        public double WaterTempOffset { get; set; }
        public RpmSource RpmSource { get; set; }
        public List<int> PgnFilter { get; set; } = new List<int>();
        public string Path { get; set; }
        public string FileName { get; set; }

        public void Save (string path, string fileName)
        {
            Path = path;
            FileName = fileName;
            string json = json = Newtonsoft.Json.JsonConvert.SerializeObject(this);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(Path);
            File.WriteAllText(path + "\\" + FileName, json);
        }

        public void Save()
        {
            Save(Path, FileName);
        }

        public Configuration Read(string path, string fileName)
        {
            Path = path;
            FileName = fileName;
            if (!Directory.Exists(Path))
                Save(Path, FileName);
            var dir = Path + "\\" + FileName;
            using (StreamReader reader = new StreamReader(dir))
            {
                string results = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<Configuration>(results);            
            }
        }

        public Configuration Read()
        {
            return Read(Path, FileName);
        }
    }
}
