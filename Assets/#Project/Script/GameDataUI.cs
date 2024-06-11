using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDataUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    // Start is called before the first frame update
    void Start() {
        Refresh();
    }

    private void Refresh() {
        scoreText.text = $"Score : {GameData.score:00000}";
    }

    public void AddScore() {
        GameData.AddScore(1);
        Refresh();
    }

    public void Save() {
        GameData.Save();
    }

    public void Load() {
        GameData.Load();
        Refresh();
    }
}
