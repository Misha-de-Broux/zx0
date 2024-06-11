using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pool : MonoBehaviour {
    Queue<CapsuleMouvement> pool = new();
    [SerializeField] GameObject prefab;
    [SerializeField] int initialBatch = 50;
    private void Awake() {
        for(int _ = 0; _ < initialBatch; _++) {
            CapsuleMouvement mouvement = Instantiate(prefab).GetComponent<CapsuleMouvement>();
            mouvement.pool = this;
            mouvement.Die();
        }
    }

    public CapsuleMouvement GetCapsuleMouvement(Vector3 position, Quaternion rotation) {
        CapsuleMouvement mouvement;
        if (pool.Count == 0) {
            mouvement = Instantiate(prefab, position, rotation).GetComponent<CapsuleMouvement>();
            mouvement.pool = this;
            return mouvement;
        }
        mouvement = pool.Dequeue();
        mouvement.transform.position = position;
        mouvement.transform.rotation = rotation;
        return mouvement;
    }

    public CapsuleMouvement GetCapsuleMouvement() => GetCapsuleMouvement(Vector3.zero, Quaternion.identity);
    public CapsuleMouvement GetCapsuleMouvement(Vector3 position) => GetCapsuleMouvement(position, Quaternion.identity);

    public void AddToPool(CapsuleMouvement mouvement) {
        pool.Enqueue(mouvement);
    }
}
