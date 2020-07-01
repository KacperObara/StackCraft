using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    public Rigidbody rb;

    private void Update()
    {
        //transform.position = new Vector3(transform.position.x + Input.GetAxis("Mouse X"),
        //                                 transform.position.y,
        //                                 transform.position.z);
        rb.MovePosition(new Vector3(transform.position.x + Input.GetAxis("Mouse X"),
                                    transform.position.y,
                                    transform.position.z));

        //if (Input.GetAxis("Mouse X") < 0)
        //{

        //}
        //else if (Input.GetAxis("Mouse X") > 0)
        //{

        //}
    }
}
