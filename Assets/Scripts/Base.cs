using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public float health = 2;
    private Transform baseTransform;

    void Start()
    {
        baseTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }

        baseTransform.localScale = new Vector3(health, 1, 1);
    }
}
