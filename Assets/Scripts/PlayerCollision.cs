using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameTags
{
    public const string Obstacle = "Obstacle";
}

public class PlayerCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GameTags.Obstacle))
        {
            Debug.Log($"Coliding com um obstaculo {other.name}");
        }

        Obstacle obstacle = other.GetComponent<Obstacle>();
        if (obstacle != null)
        {
            Debug.Log("Esse objeto tem o componente Obstacle!");
        }
    }
}
