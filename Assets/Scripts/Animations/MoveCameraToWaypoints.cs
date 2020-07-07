using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// TODO: This class should be POCO, and apply to not only camera.
// This and MovePlayerToWaypoint should be in one class
public class MoveCameraToWaypoints : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private Camera cam;

    [SerializeField]
    private Transform stackTop;
    [SerializeField]
    private Transform stackBottom;

    [SerializeField]
    private List<CameraWaypoint> cameraWaypoints = new List<CameraWaypoint>();   

    private List<CameraWaypoint> activeCameraWaypoints = new List<CameraWaypoint>();

    [SerializeField]
    private Vector3 offset;
#pragma warning restore CS0649

    private FinishRunState state;

    private Coroutine coroutine;

    public void Play(FinishRunState state)
    {
        if (coroutine == null)
        {
            activeCameraWaypoints = new List<CameraWaypoint>(cameraWaypoints);
            this.state = state;
            cam.GetComponent<CameraFollowTarget>().enabled = false;

            coroutine = StartCoroutine(MoveCamera());
        }
    }

    private IEnumerator MoveCamera()
    {
        Vector3 currentVelocity = Vector3.zero;

        while(activeCameraWaypoints.Count > 0)
        {
            CameraWaypoint cameraWaypoint = activeCameraWaypoints.ElementAt(activeCameraWaypoints.Count - 1);
            Vector3 desiredPosition = cameraWaypoint.Waypoint.position + offset;

            currentVelocity = Vector3.zero;
            while(Vector3.Distance(cam.transform.position, desiredPosition) > 0.5f)
            {
                cam.transform.position = Vector3.SmoothDamp(cam.transform.position, 
                                                            desiredPosition, 
                                                            ref currentVelocity, 
                                                            cameraWaypoint.CameraMoveSpeed);

                if (cameraWaypoint.UpdateRotation)
                    cam.transform.LookAt(cameraWaypoint.Waypoint.position);

                yield return new WaitForFixedUpdate();
            }

            activeCameraWaypoints.Remove(cameraWaypoint);
        }

        state.NotifyCameraAnimationDone();
        cam.GetComponent<CameraFollowTarget>().enabled = true;
        coroutine = null;
    }

    [Serializable]
    private struct CameraWaypoint
    {
#pragma warning disable CS0649
        public Transform Waypoint;
        public float CameraMoveSpeed;
        public bool UpdateRotation;
#pragma warning restore CS0649
    }
}
