using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace TwitterFollowersApp {
    public class ConfigFile {
        public string consumerKey { get; set; }
        public string consumerSecret { get; set; }
        public string lastCheck { get; set; }
        public string outputFile { get; set; }
    }

    class Config {
        public ConfigFile conf { get; set; }
        private const string fileName = "config/config.json";

        public Config()
        {
            this.loadConfig();
        }

        // Load the consumer key and consumer secret from a JSON file;
        private void loadConfig()
        {
            if (File.Exists(fileName)){
                using (StreamReader r = new StreamReader(fileName))
                {
                    string json = r.ReadToEnd();
                    this.conf = JsonConvert.DeserializeObject<ConfigFile>(json);
                }
            } else { throw new FileNotFoundException("Config file not found."); }
        }

        public void saveConfig()
        {
            using (FileStream fs = File.Open(fileName, FileMode.Truncate))
            using (StreamWriter sw = new StreamWriter(fs))
            using (JsonWriter jw = new JsonTextWriter(sw))
            {
                jw.Formatting = Formatting.Indented;

                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(jw, this.conf);
            }
        }
    }
}
