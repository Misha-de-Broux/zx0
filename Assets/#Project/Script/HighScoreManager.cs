using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighScoreManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> highScores = new List<TextMeshProUGUI>(10);
    void Start()
    {
        ScoreData.Load();
        UpdateScore();
    }

    // Update is called once per frame
    void UpdateScore()
    {
        bool isCurrentScoreTopScore = false;
        for (int i = 0; i < ScoreData.topScores.Count; i++) {
            highScores[i].text = $"{i + 1} : {ScoreData.topScores[i]}";
            if(!isCurrentScoreTopScore && ScoreData.currentScore == ScoreData.topScores[i]) {
                isCurrentScoreTopScore = true;
                highScores[i].color = Color.green;
            }
        }
    }
}
