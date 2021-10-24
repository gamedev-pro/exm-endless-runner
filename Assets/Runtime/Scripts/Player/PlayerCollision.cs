using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(PlayerAnimationController))]
public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameMode gameMode;
    private PlayerController playerController;
    private PlayerAnimationController animationController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
        animationController = GetComponent<PlayerAnimationController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IPlayerCollisionReaction collisionReaction = other.GetComponent<IPlayerCollisionReaction>();
        if (collisionReaction != null)
        {
            collisionReaction.ReactToPlayerCollision(new PlayerCollisionInfo()
            {
                Player = playerController,
                PlayerAnimationController = animationController,
                GameMode = gameMode,
                MyCollider = other
            });
        }
    }
}
