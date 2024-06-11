using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(NavMeshAgent))]
public class CapsuleMouvement : MonoBehaviour
{

    NavMeshAgent agent;
    public bool initialized = false;
    public Pool pool;
    void Start()
    {
        Initialize();
    }

    public void SetDestination(Vector3 destination) {
        agent.destination = destination;
    }

    public void Initialize() {
        if (initialized) return;
        agent = GetComponent<NavMeshAgent>();
        gameObject.SetActive(true);
        initialized = true;
    }

    public void Die() {
        gameObject.SetActive(false);
        initialized = false;
        pool.AddToPool(this);
    }
}
