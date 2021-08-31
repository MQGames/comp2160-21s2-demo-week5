using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField]
    private Bullet bulletPrefab;
    [SerializeField]
    private float cooldown = 0.5f; 
    private float timer = 0;

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 pos = Input.mousePosition;
                Ray ray = Camera.main.ScreenPointToRay(pos);

                Bullet b = Instantiate(bulletPrefab);
                b.transform.position = ray.origin;
                b.Direction = ray.direction;
                timer = cooldown;

                Scorekeeper.Instance.BulletFired();
            }            
        }

    }
}
