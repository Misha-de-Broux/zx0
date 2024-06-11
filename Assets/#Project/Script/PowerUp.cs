using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down* speed * Time.deltaTime, Space.World);
    }

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
