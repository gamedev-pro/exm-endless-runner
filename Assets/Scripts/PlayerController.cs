using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 15;
    [SerializeField] private float forwardSpeed = 10;

    [SerializeField] private float laneDistanceX = 4;

    [Header("Jump")]
    [SerializeField] private float jumpDistanceZ = 5;
    [SerializeField] private float jumpHeightY = 2;

    Vector3 initialPosition;

    float targetPositionX;

    public bool IsJumping { get; private set; }

    public float JumpDuration => jumpDistanceZ / forwardSpeed;
    float jumpStartZ;

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
        position.y = ProcessJump();
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
        if (Input.GetKeyDown(KeyCode.W) && !IsJumping)
        {
            IsJumping = true;
            jumpStartZ = transform.position.z;
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

    private float ProcessJump()
    {
        float deltaY = 0;
        if (IsJumping)
        {
            float jumpCurrentProgress = transform.position.z - jumpStartZ;
            float jumpPercent = jumpCurrentProgress / jumpDistanceZ;
            if (jumpPercent >= 1)
            {
                IsJumping = false;
            }
            else
            {
                deltaY = Mathf.Sin(Mathf.PI * jumpPercent) * jumpHeightY;
            }
        }
        return initialPosition.y + deltaY;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log($"Entrando na Colisao -> {other.collider.name}");
    }

    private void OnCollisionExit(Collision other)
    {
        Debug.Log($"SAINDO da Colisao -> {other.collider.name}");
    }

    private void OnCollisionStay(Collision other)
    {
        Debug.Log($"FICANDO na Colisao -> {other.collider.name}");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Entrando no TRIGGER -> {other.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log($"SAINDO do TRIGGER -> {other.name}");
    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log($"FICANDO no TRIGGER -> {other.name}");
    }
}
