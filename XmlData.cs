using UnityEngine;
using System.IO;
using System.Xml;


namespace Assets._scripts.GU_04_04_2018
{
    public class XMLData : IData<Player>
    {
        private string _path;


        public void Save(Player player)
        {
            var xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement("Name");
            element.SetAttribute("value", Crypto.CryptoXOR(player.Name));
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("Hp");
            element.SetAttribute("value", Crypto.CryptoXOR(player.Hp.ToString()));
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("IsVisible");
            element.SetAttribute("value", Crypto.CryptoXOR(player.IsVisible.ToString()));
            rootNode.AppendChild(element);

            XmlNode userNode = xmlDoc.CreateElement("Info");
            var attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Crypto.CryptoXOR(Application.unityVersion);
            userNode.Attributes.Append(attribute);
            userNode.InnerText = Crypto.CryptoXOR("System Language: " + Application.systemLanguage);
            rootNode.AppendChild(userNode);

            xmlDoc.Save(_path);
        }

        public Player Load()
        {
            var result = new Player();
            if (!File.Exists(_path)) return result;
            using (XmlTextReader reader = new XmlTextReader(_path))
            {
                var key = "Name";
                while (reader.Read())
                {
                    if (reader.IsStartElement(key))
                    {
                        result.Name = Crypto.CryptoXOR(reader.GetAttribute("value"));
                    }
                    key = "Hp";
                    if (reader.IsStartElement(key))
                    {
                        result.Hp =
                        System.Convert.ToSingle(Crypto.CryptoXOR(reader.GetAttribute("value")));
                    }
                    key = "IsVisible";
                    if (reader.IsStartElement(key))
                    {
                        result.IsVisible = Crypto.CryptoXOR(reader.GetAttribute("value")).IsTryBool();
                    }
                }
            }
            return result;
        }


        public void SetOptions(string path)
        {
            _path = Path.Combine(path, "KirsanXmlData.GeekBrains");
        }
    }
}
