using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;


namespace ZarinkinProject
{
    public class JsonLocalisationLoader : MonoBehaviour
    {
        private TextAsset _localisationFile;
        List<LocalisationData> data;
        public void Load()
        {
            _localisationFile = Resources.Load<TextAsset>("Localisation");
        }

        public Dictionary<string, string> GetDictionaryValues(string attributeId)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            string fileText;

            if (_localisationFile != null)
                fileText = _localisationFile.text;
            else
                throw new Exception("нет файла в ресурсах");

            data = JsonHelper.FromJson<LocalisationData>(fileText).ToList();

            foreach (LocalisationData dataItem in data)
                dict.Add(dataItem._id, dataItem.CheckLenq(attributeId));
            
            return dict;
        }

        public void Add(string key, string en, string fr, string ru)
        {
            LocalisationData localisationData = new LocalisationData();
            localisationData._id = key;
            localisationData.EN = en;
            localisationData.FR = fr;
            localisationData.RU = ru;
            AddToFile(localisationData);
        }


        void AddToFile(LocalisationData val)
        {
            if (data == null)
                data = JsonHelper.FromJson<LocalisationData>(_localisationFile.text).ToList();
            string path = Path.Combine(Application.dataPath + "/Resources/", "Localisation.json");
            if (!data.Contains(val))
            {
                data.Add(val);//!!!!!!!!
                File.WriteAllText(path, JsonHelper.ToJson<LocalisationData>(data.ToArray(), true));
            }
            else
            {
                Debug.Log("Такой объект уже существует");
            }
        }

        public void Remove(string key)
        {
            string path = Path.Combine(Application.dataPath + "/Resources/", "Localisation.json");
            var removeComp = data.Where(x => x._id == key);
            foreach (var comp in removeComp)
            {
                data.Remove(comp);
            }
            File.WriteAllText(path, JsonHelper.ToJson<LocalisationData>(data.ToArray(), true));
        }

        public void Edit(string key, string en, string fr, string ru)
        {
            Remove(key);
            Add(key, en, fr, ru);  
        }
    }
}
