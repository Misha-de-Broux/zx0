using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{

    Stack<Bullet> bulletPool = new Stack<Bullet>();
    [SerializeField] GameObject prefab;
    [SerializeField] int initialBatch = 50;

    internal void AddToPool(Bullet bullet) {
        bulletPool.Push(bullet);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int _ = 0; _ < initialBatch; _++) {
            Bullet bullet = Instantiate(prefab).GetComponent<Bullet>();
            bullet.name = $"{prefab.name} {_}"; 
            bullet.pool = this;
            bullet.Die();
        }
    }

    internal Bullet Get() {
        if (bulletPool.Count == 0) {
            Bullet bullet = Instantiate(prefab).GetComponent<Bullet>();
            bullet.pool = this;
            return bullet;
        }
        return bulletPool.Pop();
    }
}
