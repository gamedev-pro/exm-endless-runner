using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpInvincible : PowerUp
{
    protected override void EndPowerUp(in PlayerCollisionInfo collisionInfo)
    {
        collisionInfo.Player.IsInvincible = false;
    }

    protected override void StartPowerUp(in PlayerCollisionInfo collisionInfo)
    {
        collisionInfo.Player.IsInvincible = true;
    }
}
