using UnityEngine;
using System.Xml.Serialization;
using System.IO;

namespace ZarinkinProject
{

    public class JSONData : ISaveData<BonusData>, ISaveData<PlayerData>
    {
        string savePath = Path.Combine(Application.dataPath, "JSONData.json");
        public PlayerData Load()
        {
            PlayerData result = new PlayerData();
            if (!File.Exists(savePath))
            {
                Debug.Log("File not exist");
                return result;
            }
            string tmpJson = File.ReadAllText(savePath);
            result = JsonUtility.FromJson<PlayerData>(tmpJson);
            return result;
             
        }

        public void SaveData(PlayerData _player)
        {
            string fileJSON = JsonUtility.ToJson(_player);
            File.WriteAllText(savePath, fileJSON);
        }

        public void SaveData(BonusData bonus)
        {
            string fileJSON = JsonUtility.ToJson(bonus);
           // File.WriteAllText(savePath, fileJSON);
            File.AppendAllText(savePath, fileJSON);

            
        }

        BonusData ISaveData<BonusData>.Load()
        {
            BonusData result = new BonusData();
            if (!File.Exists(savePath))
            {
                Debug.Log("File not exist");
                return result;
            }
            string tmpJson = File.ReadAllText(savePath);
            result = JsonUtility.FromJson<BonusData>(tmpJson);
            return result;

        }

        public void ClearFile()
        {
            File.WriteAllText(savePath,"");
        }

    }
}
