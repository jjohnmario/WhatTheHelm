using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WhatTheHelmCanLib.Devices.Nmea2000;
using WhatTheHelmCanLib.Devices.NMEA2000;

namespace WhatTheHelmRuntime
{
    public class Configuration
    {
        public List<N2KDataBinding> CommonSystemsN2KConfig { get; set; } = new List<N2KDataBinding>();
        public PropulsionNmea2000Configuration PortPropulsionN2KConfig { get; set; } = new PropulsionNmea2000Configuration();
        public PropulsionNmea2000Configuration StbdPropulsionN2KConfig { get; set; } = new PropulsionNmea2000Configuration();
        public double WaterDepthOffset { get; set; }
        public double WaterTempOffset { get; set; }
        public List<uint> TxPgnFilter { get; set; } = new List<uint>();
        public List<uint> RxPgnFilter { get; set; } = new List<uint>();
        public string Path { get; set; }
        public string FileName { get; set; }

        public void Save (string path, string fileName, Configuration configToSave)
        {
            Path = path;
            FileName = fileName;
            var fileLocation = Path + "\\" + FileName;
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(configToSave);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(Path);
            File.WriteAllText(fileLocation, json);
        }

        public Configuration Read(string path, string fileName)
        {
            Path = path;
            FileName = fileName;
            var fileLocation = Path + "\\" + FileName;
            if (File.Exists(fileLocation))
            {
                using (StreamReader reader = new StreamReader(fileLocation))
                {
                    string results = reader.ReadToEnd();
                    return JsonConvert.DeserializeObject<Configuration>(results);
                }
            }
            else
                Save(path, fileName, this);
            return this;
        }

        public Configuration Read()
        {
            return Read(Path, FileName);
        }
    }
}
