using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    [SerializeField] private Transform start;
    [SerializeField] private Transform end;

    private ObstacleSpawner[] obstacleSpawners;

    public Transform Start => start;
    public Transform End => end;

    public ObstacleSpawner[] ObstacleSpawners => obstacleSpawners == null ?
        obstacleSpawners = GetComponentsInChildren<ObstacleSpawner>() : obstacleSpawners;

    //Igual ao ObstacleSpawners, mas menos resumido
    public ObstacleSpawner[] ObstacleSpawners2
    {
        get
        {
            if (obstacleSpawners == null)
            {
                obstacleSpawners = GetComponentsInChildren<ObstacleSpawner>();
            }
            return obstacleSpawners;
        }
    }
}





