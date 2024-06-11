using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] protected string nextScene;
    [SerializeField] InputActionAsset action;
    protected InputAction loadScene;
    protected virtual void Start()
    {
        InputActionMap map = action.FindActionMap("SceneControl");
        map.Enable();
        loadScene = map.FindAction("LoadScene");
        loadScene.performed += LoadScene;
    }


    protected virtual void LoadScene(InputAction.CallbackContext context) {
        loadScene.performed -= LoadScene;
        SceneManager.LoadScene(nextScene);
    }
}
