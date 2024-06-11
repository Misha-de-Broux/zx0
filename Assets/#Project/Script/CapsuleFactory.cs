using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapsuleFactory : MonoBehaviour
{
    [SerializeField] Pool pool;
    [Range(1,100)][SerializeField] int batch = 10;
    [SerializeField] float cooldown = 1;
    [SerializeField] Transform destination;

    private void Start() {
        StartCoroutine(Create());
    }
    private IEnumerator Create() {
        while (true) {
            for (int _ = 0; _ < batch; _++) {
                CapsuleMouvement capsule = pool.GetCapsuleMouvement(transform.position, transform.rotation);
                capsule.Initialize();
                capsule.SetDestination(destination.position);
            }
            yield return new WaitForSeconds(cooldown);
        }
    }
}
