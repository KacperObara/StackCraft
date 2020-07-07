using UnityEngine;

public class AutoMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + (transform.forward * speed * Time.deltaTime));
    }
}
