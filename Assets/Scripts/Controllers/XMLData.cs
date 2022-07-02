using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

namespace ZarinkinProject
{


    public class XMLData : ISaveData<PlayerData>
    {
        string _savePath = Path.Combine(Application.dataPath, "XMLData.xml");
        public PlayerData Load()
        {
            PlayerData result = new PlayerData();

            if (!File.Exists(_savePath))
            {
                Debug.Log("File not exist");
                return result;
            }


            using(XmlTextReader reader = new XmlTextReader(_savePath))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement("PlayerName"))
                    {
                        result.PlayerName = reader.GetAttribute("value");
                    }
                    else if (reader.IsStartElement("PlayerHealth"))
                    {
                        result.PlayerHealth =Convert.ToInt32(reader.GetAttribute("value"));
                    }
                    else if (reader.IsStartElement("IsDead"))
                    {
                        result.PlayerDead = Convert.ToBoolean(reader.GetAttribute("value"));
                    }
                }
            }

            return result;
        }

        public void SaveData(PlayerData _player)
        {
            XmlDocument xmlDoc = new XmlDocument();
            XmlNode rootNode = xmlDoc.CreateElement("Player");
            xmlDoc.AppendChild(rootNode);

            XmlElement element = xmlDoc.CreateElement("PlayerName");
            element.SetAttribute("value", _player.PlayerName.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement("PlayerHealth");
            element.SetAttribute("value", _player.PlayerHealth.ToString());
            rootNode.AppendChild(element);


            element = xmlDoc.CreateElement("IsDead");
            element.SetAttribute("value", _player.PlayerDead.ToString());
            rootNode.AppendChild(element);

            xmlDoc.Save(_savePath);

        }
    }
}
