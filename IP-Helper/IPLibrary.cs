using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

//Added comment

namespace IP_Helper
{
    [Serializable]
    public class IpSetting
    {
        private string name;
        private string ipAddress;
        private string subNet;
        private string gWay;

        public IpSetting(string name, string ipAddress, string subNet, string gWay)
        {
            this.name = name;
            this.ipAddress = ipAddress;
            this.subNet = subNet;
            this.gWay = gWay;
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        public string IPAddress
        {
            get { return this.ipAddress; }
            set { this.ipAddress = value; }
        }

        public string SubNet
        {
            get { return this.subNet; }
            set { this.subNet = value; }
        }

        public string GateWay
        {
            get { return this.gWay; }
            set { this.gWay = value; }
        }
    }

    public class IPInformation
    {
        private static IPInformation ipInformation;

        public Dictionary<string, IpSetting> ipDictionary;
        private BinaryFormatter formatter;

        private const string CONFIG = "config.dat";

        public static IPInformation Instance()
        {
            if (ipInformation == null)
            {
                ipInformation = new IPInformation();
            }
            return ipInformation;
        }

        private IPInformation()
        {
            ipDictionary = new Dictionary<string, IpSetting>();
            formatter = new BinaryFormatter();
        }

        public bool AddIP(string name, string ipAddress, string subNet, string gWay)
        {
            if (ipDictionary.ContainsKey(name))
            {
                return false;
            }
            else
            {
                ipDictionary.Add(name, new IpSetting(name, ipAddress, subNet, gWay));
                return true;
            }
        }

        public bool RemoveIP(string name)
        {
            if (!ipDictionary.ContainsKey(name))
            {
                return false;
            }
            else
            {
                ipDictionary.Remove(name);
                return true;
            }
        }

        public void Save()
        {
            try
            {
                FileStream writerFileStream = new FileStream(CONFIG, FileMode.Create, FileAccess.Write);
                formatter.Serialize(writerFileStream, ipDictionary);

                writerFileStream.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exception occurred: ", e.Message);
            }
        }

        public void Load()
        {
            if (File.Exists(CONFIG))
            {
                try
                {
                    FileStream readerFileStream = new FileStream(CONFIG, FileMode.Open, FileAccess.Read);

                    ipDictionary = (Dictionary<String, IpSetting>)formatter.Deserialize(readerFileStream);
                    readerFileStream.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception occurred: ", e.Message);
                }
            }
        }
    }
}
