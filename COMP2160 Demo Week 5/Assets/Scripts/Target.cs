using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField]
    private float upTime = 0f;  // seconds after Start
    [SerializeField]
    private float upDuration = 2f;  // seconds
    [SerializeField]
    private float speed = 1f; // m/s


    private Transform cylinder;
    private Transform upPosition;    
    private Transform downPosition;    
    private float timer;
    private Scorekeeper scorekeeper;

    // Finite State Machine:
    //
    //          upTime      upDuration
    //  (Start) -----> (Up) ---------> (Down)
    //                    \              /
    //                 hit \            / hit
    //                      -> (Dead) <-

    private enum State { Start, Up, Down, Dead };
    private State state;

    void Start()
    {
        scorekeeper = FindObjectOfType<Scorekeeper>();

        cylinder = transform.Find("Cylinder");
        upPosition = transform.Find("Up");
        downPosition = transform;

        timer = upTime;
        state = State.Start;
    }

    // Update is called once per frame
    void Update()
    {        
        switch (state)
        {
            case State.Start:
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    state = State.Up;
                    timer = upDuration;
                }
                break;

            case State.Up:
                MoveTo(upPosition);
                timer -= Time.deltaTime;

                if (timer <= 0)
                {
                    state = State.Down;
                }
                break;

            case State.Down:
                MoveTo(downPosition);
                break;

            case State.Dead:
                // nothing to do
                break;

        }
    }

    private void MoveTo(Transform destination)
    {
        Vector3 v = destination.position - cylinder.position;
        float move = speed * Time.deltaTime;

        // scale v to whichever distance is shorter.
        if (move < v.magnitude)
        {
            v = v.normalized * move;
        }

        cylinder.Translate(v, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {   
        Debug.Log("OnTriggerEnter");
        // hide the target
        state = State.Dead;
        cylinder.gameObject.SetActive(false);

        scorekeeper.AddPointsForHit();
    }
}
