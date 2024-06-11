using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeManager : SceneChanger
{
    [SerializeField] int numberLife = 3;
    [SerializeField] float timeBeforeScore = 5;
    public Action loseLife, gameOver;
    public float TimeBeforeScore { get { return timeBeforeScore; } }

    protected override void Start() {
        base.Start();
        Time.timeScale = 1;
        loadScene.Disable();
    }
    public int Lives {  get { return numberLife; } }

    public void LoseLife() {
        numberLife--;
        loseLife?.Invoke();
        if(numberLife <= 0) {
            StartCoroutine(GameOver());
        }
    }

    private IEnumerator GameOver() {
        gameOver?.Invoke();
        ScoreData.UpdateHighScore();
        Time.timeScale = 0.5f;
        yield return new WaitForSeconds(timeBeforeScore*0.3f);
        loadScene.Enable();
        yield return new WaitForSecondsRealtime(timeBeforeScore*0.7f);
        SceneManager.LoadScene(nextScene);
    }
}
