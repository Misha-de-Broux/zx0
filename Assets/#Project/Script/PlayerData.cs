using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PlayerData {

    [Serializable]
    private class SaveData {
        public float px,py,pz,dx,dy,dz;
    }

    public const string DATA_PATH = "playerData.dat";
    public static string SAVE_PATH {
        get { return $"{Application.persistentDataPath}/{DATA_PATH}"; }
    }

    public static Vector3 position;
    public static Vector3 destination;

    public static void Save() {
        SaveData data = new();
        data.px = position.x; data.py = position.y; data.pz = position.z;
        data.dx = destination.x; data.dy = destination.y; data.dz = destination.z;
        BinaryFormatter bf = new();
        FileStream file = File.Create(SAVE_PATH); 
        bf.Serialize(file, data);
        file.Close();
    }

    public static void Load() {
        BinaryFormatter bf = new();
        if (File.Exists(SAVE_PATH)) {
            FileStream file = File.OpenRead(SAVE_PATH);
            SaveData data = (SaveData)bf.Deserialize(file);
            file.Close();
            position = new Vector3(data.px,data.py,data.pz);
            destination = new Vector3(data.dx,data.dy,data.dz);
        }
    }
}
