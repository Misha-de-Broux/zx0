using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour {
    [SerializeField] private float speed = 5.0f;
    public BulletPool pool;

    // Update is called once per frame
    void Update() {
        transform.Translate(transform.right * speed * Time.deltaTime, Space.World);
    }

    public void Activate() {
        if (!gameObject.activeSelf) {
            gameObject.SetActive(true);
        }
    }

    private void OnBecameInvisible() {
        if (gameObject.activeSelf) {
            Die();
        }
    }

    internal void Die() {
        gameObject.SetActive(false);
        pool.AddToPool(this);
    }

    protected virtual void OnTriggerEnter(Collider other) {
        Die();
    }
}
