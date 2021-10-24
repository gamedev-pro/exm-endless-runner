using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerCollisionInfo
{
    public PlayerController Player;
    public PlayerAnimationController PlayerAnimationController;
    public GameMode GameMode;
    public Collider MyCollider;
}

public interface IPlayerCollisionReaction
{
    void ReactToPlayerCollision(in PlayerCollisionInfo collisionInfo);
}
