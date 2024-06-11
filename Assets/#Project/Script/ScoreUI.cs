using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour {

    [SerializeField] TextMeshProUGUI currentScoreField, highScoreField;
    int highestScore;
    // Start is called before the first frame update
    void Start() {
        ScoreData.Load();
        highestScore = ScoreData.topScores[0];
        highScoreField.text = $"High Score : {highestScore:00000}";
        ScoreData.UpdateScore(0);
        Refresh();
    }

    private void Refresh() {
        currentScoreField.text = $"Score : {ScoreData.currentScore:00000}";
        if (ScoreData.currentScore > highestScore) {
            highScoreField.text = $"High Score : {ScoreData.currentScore:00000}";
        }
    }

    public void AddScore() {
        ScoreData.AddScore(1);
        Refresh();
    }
}
