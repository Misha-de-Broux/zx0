using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSingleton : MonoBehaviour
{

    private static CubeSingleton instance;
    private void Awake() {
        if (instance == null) {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
