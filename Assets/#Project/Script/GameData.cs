using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class GameData {
    public const string DATA_PATH = "gameData.dat";
    public static int score = 0;

    public static string SAVE_PATH {
        get { return $"{Application.persistentDataPath}/{DATA_PATH}"; }
    }

    public static void AddScore(int value) {
        UpdateScore(score + value);
    }

    public static void UpdateScore (int value) {
        score = value;
    }

    [Serializable]
    private class SaveData {
        public int score;
    }
    public static void Save() {
        BinaryFormatter bf = new();
        FileStream file = File.Create(SAVE_PATH);

        SaveData data = new();
        data.score = score;
        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load() {
        BinaryFormatter bf = new();
        if (File.Exists(SAVE_PATH)) {
            FileStream file = File.OpenRead(SAVE_PATH);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            score = data.score;
        }
    }

    
}
