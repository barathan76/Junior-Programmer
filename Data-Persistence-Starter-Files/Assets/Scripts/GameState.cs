using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameState : MonoBehaviour
{
    public static String Scorer;

    [System.Serializable]
    public class SaveData
    {
        public int score;
        public String Scorer;
    }
    public static int topScore;
    public static String topScorer;

    public static void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.score = topScore;
        data.Scorer = topScorer;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public static void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            topScore = data.score;
            topScorer = data.Scorer;
        }
    }


}
