using UnityEngine;

public class PowerUpScoreMultiplier : PowerUp
{
    [SerializeField] private int scoreMultiplier = 2;

    protected override void EndPowerUp(in PlayerCollisionInfo collisionInfo)
    {
        collisionInfo.GameMode.TemporaryScoreMultipler = 1;
    }

    protected override void StartPowerUp(in PlayerCollisionInfo collisionInfo)
    {
        collisionInfo.GameMode.TemporaryScoreMultipler = scoreMultiplier;
    }
}
