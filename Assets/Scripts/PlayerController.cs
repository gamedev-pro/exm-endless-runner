using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 0.03f;
    [SerializeField] private float forwardSpeed = 0.05f;
    private void Update()
    {
        Vector3 targetPosition = transform.position;
        if (Input.GetKey(KeyCode.A))
        {
            //Vector3(-1,0,0)*0.03 = Vector3(-0.03, 0, 0);
            targetPosition += Vector3.left * horizontalSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            targetPosition += Vector3.right * horizontalSpeed * Time.deltaTime;
        }

        targetPosition += Vector3.forward * forwardSpeed * Time.deltaTime;

        transform.position = targetPosition;
    }
}
