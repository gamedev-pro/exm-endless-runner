using UnityEngine;

public class PowerUpScoreMultiplier : PowerUp
{
    [SerializeField] private int scoreMultiplier = 2;

    protected override void ActivatePowerUpBehaviour(PlayerController player)
    {
        player.GetComponentInChildren<PowerUpBehaviour_ScoreMultiplier>().Activate(scoreMultiplier, PowerUpTime);
    }
}