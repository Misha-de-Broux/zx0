using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public void ChangeTimeScale(float scale) {
        Time.timeScale = scale;
    }
}
