using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LifeUI : MonoBehaviour
{
    [SerializeField] LifeManager lifeManager;
    [SerializeField] GameObject prefab;
    Stack<GameObject> lifeList = new Stack<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        Vector3 lifePosition = transform.position;
        for(int i = 0; i < lifeManager.Lives; i++) {
            GameObject life = Instantiate(prefab, lifePosition, transform.rotation);
            life.transform.parent = transform;
            life.layer = gameObject.layer;
            lifeList.Push(life);
            lifePosition.x += 1.5f;
        }
        lifeManager.loseLife += DestroyLife;
    }

    private void DestroyLife() {
        Destroy(lifeList.Pop());
    }

    
}
