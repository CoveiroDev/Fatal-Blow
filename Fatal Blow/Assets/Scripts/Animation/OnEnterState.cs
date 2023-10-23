using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterState : StateMachineBehaviour
{
    [Header("State")]
    [SerializeField] private string parameter;
    [SerializeField] private bool state;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(parameter, state);

    }
}