using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 15;
    [SerializeField] private float forwardSpeed = 10;

    [SerializeField] private float laneDistanceX = 4;

    Vector3 initialPosition;

    float targetPositionX;

    private float LeftLaneX => initialPosition.x - laneDistanceX;
    private float RightLaneX => initialPosition.x + laneDistanceX;

    void Awake()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        ProcessInput();

        Vector3 position = transform.position;

        position.x = ProcessLaneMovement();
        position.z = ProcessForwardMovement();

        transform.position = position;
    }

    private void ProcessInput()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            targetPositionX += laneDistanceX;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            targetPositionX -= laneDistanceX;
        }

        targetPositionX = Mathf.Clamp(targetPositionX, LeftLaneX, RightLaneX);
    }

    private float ProcessLaneMovement()
    {
        return Mathf.Lerp(transform.position.x, targetPositionX, Time.deltaTime * horizontalSpeed);
    }

    private float ProcessForwardMovement()
    {
        return transform.position.z + forwardSpeed * Time.deltaTime;
    }
}
