using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    ScoreUI scoreManager;
    const int MAX_RNG = 25;
    static int rng = MAX_RNG;
    [SerializeField] GameObject powerUp;
    private void Start() {
        scoreManager = FindAnyObjectByType<ScoreUI>();
    }
    protected override void OnTriggerEnter(Collider other) {
        base.OnTriggerEnter(other);
        scoreManager.AddScore();
        if(Random.Range(0, rng) == 0) {
            rng = MAX_RNG;
            GameObject go =Instantiate(powerUp, transform.position, transform.rotation);
        } else {
            rng--;
        }
    }
}
