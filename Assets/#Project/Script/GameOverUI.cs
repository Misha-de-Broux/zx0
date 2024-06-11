using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] LifeManager lifeManager;
    [SerializeField] TextMeshProUGUI textField;
    // Start is called before the first frame update
    void Start() {
        textField.alpha = 0;
        if (lifeManager == null) {
            lifeManager = FindAnyObjectByType<LifeManager>();
        }
        lifeManager.gameOver += ShowText;
    }

    private void ShowText() { 
        StartCoroutine(ShowTextRoutine());
    }

    private IEnumerator ShowTextRoutine() {
        for(float time  = 0f; time < lifeManager.TimeBeforeScore * 0.3f; time+= Time.deltaTime/Time.timeScale) {
            textField.alpha =  time / (lifeManager.TimeBeforeScore * 0.3f);
            yield return null;
        }
        textField.alpha = 1;
    }
    }
