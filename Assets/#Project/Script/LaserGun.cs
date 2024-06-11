using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LaserGun : MonoBehaviour {
    [SerializeField] BulletPool pool;

    internal void Bomb() {
        StartCoroutine(BombCoroutine());
    }

    private IEnumerator BombCoroutine() {
        Vector3 bombPosition = transform.position;
        for (int i = 0; i < 60; i++) {
            Bullet bullet = pool.Get();
            bullet.Activate();
            bullet.transform.position = bombPosition;
            bullet.transform.rotation = Quaternion.identity;
            bullet.transform.Rotate(Vector3.forward, i * 6);
            yield return new WaitForSeconds(0.05f);
        }
    }

    internal void Shoot(Vector3 mousePosition) {
        Bullet bullet = pool.Get();
        Debug.DrawLine(transform.position, mousePosition, Color.blue, 1);
        bullet.transform.position = transform.position;
        bullet.Activate();
        Vector3 direction = (mousePosition - transform.position).normalized;
        bullet.transform.right = direction;
    }
}