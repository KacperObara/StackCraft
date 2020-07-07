using System.Collections;
using UnityEngine;

//TODO: This and MoveCameraToWaypoints should be in one class
public class MovePlayerToWaypoint : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private GameObject target;    

    private Vector3 waypoint;
#pragma warning restore CS0649

    [SerializeField]
    private float speed = 5f;

    private FinishRunState state;

    private Coroutine coroutine;

    public void Play(Vector3 waypoint, FinishRunState state)
    {
        if (coroutine == null)
        {
            this.state = state;
            this.waypoint = waypoint;
            coroutine = StartCoroutine(MoveToWaypoint());
        }
    }

    private IEnumerator MoveToWaypoint()
    {
        while (Vector3.Distance(target.transform.position, waypoint) > 0.5f)
        {
            target.transform.position = Vector3.MoveTowards(target.transform.position, waypoint, Time.deltaTime * speed);

            yield return new WaitForFixedUpdate();
        }
        state.NotifyPlayerAnimationDone();
        coroutine = null;
    }
}
