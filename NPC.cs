using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
     private enum State
    {
        Idle,

    }

    private State _currentState;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        _currentState = State.Idle;
    }
}
