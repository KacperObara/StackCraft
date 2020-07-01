using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float speed = 5f;

    void Update()
    {
        //transform.position += transform.forward * speed * Time.deltaTime;
        //rb.velocity += transform.forward * speed * Time.deltaTime;
        rb.MovePosition(transform.position + (transform.forward * speed * Time.deltaTime));
    }
}
