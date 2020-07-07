using UnityEngine;

public class CameraFollowTarget : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset;
    [SerializeField]
    private Vector3 lookOffset;

    private Vector3 currentVelocity;
#pragma warning restore CS0649

    [SerializeField]
    private float smoothTime = 0.125f;

    private void OnValidate()
    {
        if (target == null)
        {
            target = transform;
        }
    }

    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offset + lookOffset;
        desiredPosition.x = offset.x;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref currentVelocity, smoothTime);

        Vector3 desiredLookPosition = target.position + lookOffset;
        desiredLookPosition.x = 0;
        transform.LookAt(desiredLookPosition);
    }
}
