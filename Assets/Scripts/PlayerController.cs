using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 0.03f;
    [SerializeField] private float forwardSpeed = 0.05f;

    [SerializeField] private float targetPositionX;
    private void Update()
    {
        Vector3 targetPosition = transform.position;

        targetPosition.x = Mathf.Lerp(transform.position.x, targetPositionX, Time.deltaTime * horizontalSpeed);

        targetPosition += Vector3.forward * forwardSpeed * Time.deltaTime;

        transform.position = targetPosition;
    }
}
