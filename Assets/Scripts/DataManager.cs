using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string PlayerName;
    public float BestScore;
    public string BestPlayer; 

    private void Awake()
    {
        
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        Instance = this;
        DontDestroyOnLoad(gameObject);

    }

    [System.Serializable]
    class SaveData
    {
       public float BestScore;
        public string BestPlayer;

    }

    public void SaveBestScore(float FinalScore)
    {
        SaveData data = new SaveData();
       
            data.BestScore = FinalScore;
            data.BestPlayer = PlayerName;
        
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.BestScore;
            BestPlayer = data.BestPlayer;
        }
    }
}
