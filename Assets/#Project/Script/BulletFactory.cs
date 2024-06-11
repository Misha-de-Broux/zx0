using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletFactory : MonoBehaviour
{

    [SerializeField] BulletPool pool;
    [SerializeField] float cooldown = 0.1f, minHeinght = -3, maxHeight = 3;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BulletSpawn());
    }

    
    IEnumerator BulletSpawn() {
        while (true) { 
            Bullet bullet = pool.Get();
            bullet.Activate();
            bullet.transform.position = new Vector3(transform.position.x, transform.position.y + Random.Range(minHeinght, maxHeight), transform.position.z);
            yield return new WaitForSeconds(cooldown);
        }
    }
}
