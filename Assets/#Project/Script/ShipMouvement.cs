using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class ShipMouvement : MonoBehaviour
{
    Camera camera;
    [SerializeField] float speed = 5;
    [SerializeField] InputActionAsset inputAction;
    [SerializeField] LaserGun laserGun;
    InputAction move, shoot;
    void Start()
    {
        camera = Camera.main;
        InputActionMap map = inputAction.FindActionMap("PlayerControl");
        map.Enable();
        move = map.FindAction("Move");
        shoot = map.FindAction("Shoot");
        shoot.performed += Shoot;
    }

    private void Shoot(InputAction.CallbackContext context) {
        Vector3 mouse = Input.mousePosition;
        Ray castPoint = camera.ScreenPointToRay(mouse);
        RaycastHit hit;
        if (Physics.Raycast(castPoint, out hit, Mathf.Infinity)) {
            Vector3 point = hit.point;
            laserGun.Shoot(point);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rawMove = move.ReadValue<Vector2>();
        transform.Translate(new Vector3(rawMove.x, rawMove.y, 0)*speed*Time.deltaTime);
        Vector3 screenPosition = camera.WorldToScreenPoint(transform.position);
        if (screenPosition.x < 0) {
            screenPosition.x = 0;
        }
        if(screenPosition.y < 0) {
            screenPosition.y = 0;
        }
        if(screenPosition.x > camera.pixelWidth) {
            screenPosition.x = camera.pixelWidth;
        }
        if(screenPosition.y > camera.pixelHeight) {
            screenPosition.y = camera.pixelHeight;
        }
        transform.position = camera.ScreenToWorldPoint(screenPosition);
    }

    private void OnDisable() {
        shoot.performed -= Shoot;
    }

    internal void PowerUp() {
        laserGun.Bomb();
    }
}
