using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        other.GetComponent<CapsuleMouvement>()?.Die();
    }
}
