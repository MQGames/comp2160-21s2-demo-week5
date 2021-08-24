using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 5;  // m/s
    [SerializeField]
    private float lifetime = 5; // s


    private Vector3 direction;

    public Vector3 Direction 
    {
        get 
        {
            return direction;
        }

        set
        {
            direction = value.normalized;
        }
    }

    void Update()
    {
        lifetime -= Time.deltaTime;
        if (lifetime < 0) 
        {
            Destroy(gameObject);
        }
        else 
        {
            transform.Translate(direction * speed * Time.deltaTime, Space.World);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}

