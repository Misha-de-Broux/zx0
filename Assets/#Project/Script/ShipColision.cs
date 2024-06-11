using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ShipMouvement))]
public class ShipColision : MonoBehaviour {
    [SerializeField] LifeManager lifeManager;
    ShipMouvement ship;

    private void Start() {
        ship = GetComponent<ShipMouvement>();
        lifeManager.gameOver += Destroy;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Bullet")) {
            lifeManager.LoseLife();
            StartCoroutine(InvincibilityFrames());
        } else if (other.CompareTag("PowerUp")) {
            Destroy(other.gameObject);
            ship.PowerUp();
        }
    }

    private IEnumerator InvincibilityFrames() {
        Collider collider = GetComponent<Collider>();
        collider.enabled = false;
        Renderer[] renderers = GetComponentsInChildren<Renderer>();
        for (float time = 0; time < 1; time += Time.deltaTime) {
            if ((time * 10) % 2 < 1) {
                foreach (Renderer r in renderers) {
                    r.enabled = false;
                }
            } else {
                foreach (Renderer r in renderers) {
                    r.enabled = true;
                }
            }
            yield return null;
        }
        foreach (Renderer r in renderers) {
            r.enabled = true;
        }
        collider.enabled = true;
    }

    private void OnDestroy() {
        lifeManager.gameOver -= Destroy;
    }

    private void Destroy() {
        Destroy(gameObject);
    }
}
