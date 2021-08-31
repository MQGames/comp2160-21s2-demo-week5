using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    private static Scorekeeper instance;

    public static Scorekeeper Instance
    {
        get { return instance; }
    }

    [SerializeField]
    private int pointsPerHit = 10;
    [SerializeField]
    private int costPerBullet = 1;

    private int score = 0;

    public int Score 
    {
        get { return score; }
    }


    public void Start()
    {
        instance = this;
    }

    public void AddPointsForHit()
    {
        score += pointsPerHit;
    }

    public void BulletFired()
    {
        score -= costPerBullet;
    }
}
