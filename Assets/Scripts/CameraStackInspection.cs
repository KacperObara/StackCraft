using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script moves the camera from default position to the bottom of the stack,
/// then to the top of the stack and returns to original position.
/// Animation is visible after crossing the finish line.
/// </summary>
public class CameraStackInspection : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private Transform stackTop;
    [SerializeField]
    private Transform stackBottom;
#pragma warning restore CS0649

    [SerializeField]
    private float speed = 0.1f;
    [SerializeField]
    private float rotationSpeed = 50f;

    private Stack<Transform> cameraWaypoints = new Stack<Transform>();

    [SerializeField]
    private Vector3 cameraOffset = new Vector3(2, 0 - 1);

    public void Play()
    {
        cameraWaypoints.Push(stackTop);
        cameraWaypoints.Push(stackBottom);

        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        while (cameraWaypoints.Count > 0)
        {
            Vector3 endPos = cameraWaypoints.Peek().localPosition + cameraOffset;

            Vector3 target = cameraWaypoints.Peek().position - cam.transform.position;
            target.y = 0;

            while (Vector3.Distance(cam.transform.localPosition, endPos) > 0.5f)
            {
                cam.transform.localPosition = Vector3.MoveTowards(cam.transform.localPosition, endPos, speed);

                cam.transform.rotation = Quaternion.RotateTowards(cam.transform.rotation, Quaternion.LookRotation(target), Time.deltaTime * rotationSpeed);

                yield return null;
            }

            cam.transform.rotation = Quaternion.LookRotation(target);
            cam.transform.localPosition = endPos;
            cameraWaypoints.Pop();
        }
    }
}
