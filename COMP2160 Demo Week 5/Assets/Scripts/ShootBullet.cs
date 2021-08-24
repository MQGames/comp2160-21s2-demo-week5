using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Input.mousePosition;
            Ray ray = Camera.main.ScreenPointToRay(pos);

            Bullet b = Instantiate(bulletPrefab);
            b.transform.position = ray.origin;
            b.Direction = ray.direction;
        }
    }
}
