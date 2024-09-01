using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdle : StateMachineBehaviour
{
    float timer;
    Transform player;
    float runRange = 15;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //find player
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Get the distance between player and skeleton
        float distance = Vector3.Distance(animator.transform.position, player.position);
        //if within range of chasing, run after them
        if (distance < runRange)
            animator.SetBool("isRunning", true);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
