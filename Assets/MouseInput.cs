using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float xPos = Mathf.Clamp(rb.position.x + Input.GetAxis("Mouse X"), -4.4f, 4.5f);

        rb.MovePosition(new Vector3(xPos, 
                                    rb.position.y, 
                                    rb.position.z));
    }
}
