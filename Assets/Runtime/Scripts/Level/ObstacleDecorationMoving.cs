using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDecorationMoving : ObstacleDecoration
{
    [SerializeField] private Animator animator;
    public override void PlayCollisionFeedback()
    {
        base.PlayCollisionFeedback();
        animator.SetTrigger(ObstacleAnimationConstants.Dead);
    }
}
