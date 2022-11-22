using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WhatTheHelmCanLib.Devices.Nmea2000;

namespace WhatTheHelmRuntime
{
    public class Configuration
    {
        public List<PropulsionNmea2000Config> CommonSystemsN2KConfig { get; set; } = new List<PropulsionNmea2000Config>();
        public PropulsionNmea2000Configuration PortPropulsionN2KConfig { get; set; } = new PropulsionNmea2000Configuration();
        public PropulsionNmea2000Configuration StbdPropulsionN2KConfig { get; set; } = new PropulsionNmea2000Configuration();
        public double WaterDepthOffset { get; set; }
        public double WaterTempOffset { get; set; }
        public List<uint> TxPgnFilter { get; set; } = new List<uint>();
        public List<uint> RxPgnFilter { get; set; } = new List<uint>();
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
