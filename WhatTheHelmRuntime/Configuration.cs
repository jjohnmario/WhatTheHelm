using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using WhatTheHelmCanLib.Devices.Nmea2000;

namespace WhatTheHelmRuntime
{
    public struct ProductDataBinding
    {
        public ProductInformation ProductInformation { get; set; }
        public uint PGN { get; set; }
        public byte Instance { get; set; }
        public byte SourceAddress { get; set; }
    }
    public class Configuration
    {
        public ProductDataBinding PortRpm { get; set; } = new ProductDataBinding();
        public ProductDataBinding PortWaterTemperature { get; set; } = new ProductDataBinding();
        public ProductDataBinding PortOilPressure { get; set; } = new ProductDataBinding();
        public ProductDataBinding PortEngineAlarms { get; set; } = new ProductDataBinding();
        public ProductDataBinding PortEngineHours { get; set; } = new ProductDataBinding();
        public ProductDataBinding PortTransPressure { get; set; } = new ProductDataBinding();
        public ProductDataBinding PortTransAlarms { get; set; } = new ProductDataBinding();
        public ProductDataBinding PortVoltage { get; set; } = new ProductDataBinding();

        public ProductDataBinding StbdRpm { get; set; } = new ProductDataBinding();
        public ProductDataBinding StbdWaterTemperature { get; set; } = new ProductDataBinding();
        public ProductDataBinding StbdOilPressure { get; set; } = new ProductDataBinding();
        public ProductDataBinding StbdEngineAlarms { get; set; } = new ProductDataBinding();
        public ProductDataBinding StbdEngineHours { get; set; } = new ProductDataBinding();
        public ProductDataBinding StbdTransPressure { get; set; } = new ProductDataBinding();
        public ProductDataBinding StbdTransAlarms { get; set; } = new ProductDataBinding();
        public ProductDataBinding StbdVoltage { get; set; } = new ProductDataBinding();

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
