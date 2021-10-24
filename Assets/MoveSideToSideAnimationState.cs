using UnityEngine;

public class MoveSideToSideAnimationState : StateMachineBehaviour
{
    private ObstacleMoving obstacle;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AnimatorClipInfo[] clips = animator.GetCurrentAnimatorClipInfo(layerIndex);
        if (clips.Length > 0)
        {
            AnimatorClipInfo runClipInfo = clips[0];

            //TODO: De novo estamo assumindo onde o componente está no objeto. Resolver urgente
            obstacle = animator.transform.parent.parent.parent.GetComponent<ObstacleMoving>();

            //A animacao completa a distancia side to side duas vezes
            float timeToCompleteAnimationCycle = obstacle.SideToSideMoveTime * 2;
            float speedMultiplier = runClipInfo.clip.length / timeToCompleteAnimationCycle;
            animator.SetFloat(ObstacleAnimationConstants.SideToSideMultiplier, speedMultiplier);
        }
    }
}
