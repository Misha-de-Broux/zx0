using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class ScoreData
{
    public const string DATA_PATH = "scoreData.dat";
    public static int currentScore = 0;
    public static List<int> topScores = new List<int>();

    public static string SAVE_PATH {
        get { return $"{Application.persistentDataPath}/{DATA_PATH}"; }
    }

    public static void AddScore(int value) {
        UpdateScore(currentScore + value);
    }

    public static void UpdateScore(int value) {
        currentScore = value;
    }

    public static void UpdateHighScore() {
        topScores.Add(currentScore);
        topScores.Sort((x, y) => { return y - x; });
        if(topScores.Count > 10) {
            topScores.RemoveAt(10);
        }
        Save();
    }

    [Serializable]
    private class SaveData {
        public int currentScore;
        public int[] topScore;
    }
    public static void Save() {
        BinaryFormatter bf = new();
        FileStream file = File.Create(SAVE_PATH);

        SaveData data = new();
        data.currentScore = currentScore;
        data.topScore = topScores.ToArray();
        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load() {
        BinaryFormatter bf = new();
        if (File.Exists(SAVE_PATH)) {
            FileStream file = File.OpenRead(SAVE_PATH);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            topScores = new List<int>(data.topScore); 
            topScores.Sort((x, y) => { return y - x; });
            if (topScores.Count == 0) {
                topScores.Add(0);
            }
            currentScore = data.currentScore;
        }
    }
}
