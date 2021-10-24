using UnityEngine;

public class ObstacleMoving : Obstacle
{
    //TODO: This variable is duplicated between PlayerController and ObstacleMoving.
    //Move to GameMode, or EndlessTrackGenerator
    [SerializeField] private float laneDistanceX = 4;

    //TODO: Increase when speed increases
    [SerializeField] private float initialSpeed = 10;
    private float positionT = 0;
    public float LaneDistanceX => laneDistanceX;

    public float MoveSpeed => initialSpeed;

    public float SideToSideMoveTime => 1.0f / MoveSpeed;

    private void Update()
    {
        positionT += Time.deltaTime * MoveSpeed;
        float laneDistance = (Mathf.PingPong(positionT, 1) - 0.5f) * laneDistanceX * 2;

        Vector3 pos = transform.position;
        pos.x = laneDistance;
        transform.position = pos;
    }

    public override void Die(Collider collider)
    {
        base.Die(collider);
        enabled = false;
    }
}
