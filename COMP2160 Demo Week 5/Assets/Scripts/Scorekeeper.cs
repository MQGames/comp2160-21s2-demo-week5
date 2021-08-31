using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorekeeper : MonoBehaviour
{
    [SerializeField]
    private int pointsPerHit = 10;

    private int score = 0;

    public void AddPointsForHit()
    {
        score += pointsPerHit;
    }

}
