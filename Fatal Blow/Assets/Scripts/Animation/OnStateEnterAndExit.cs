using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStateEnterAndExit : StateMachineBehaviour
{
    [Header("State")]
    [SerializeField] private string parameter;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(parameter, true);

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(parameter, false);
    }
}