using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TestCollision.OnTriggerEnter");
    }
}
