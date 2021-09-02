using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float horizontalSpeed = 0.03f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            //Vector3(-1,0,0)*0.03 = Vector3(-0.03, 0, 0);
            transform.position += Vector3.left * horizontalSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * horizontalSpeed;
        }
    }
}
