using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRunState : GameState
{
    public Transform FinishWaypoint;
    public Transform Player;

    [SerializeField]
    private GameObject UI;

    [SerializeField]
    private float moveSpeed;

    private bool standingOnPoint = false;


    public override string GetName()
    {
        return this.GetType().Name;
    }

    public override void OnEnter()
    {
        UI.SetActive(true);
        StartCoroutine(MoveToWaypoint());
    }

    public override void OnExit()
    {
        UI.SetActive(false);
    }

    public override void OnUpdate()
    {
        if (standingOnPoint == true)
        {
            GetComponent<CameraStackInspection>().Play();
            standingOnPoint = false;
        }
    }

    private IEnumerator MoveToWaypoint()
    {
        while (Vector3.Distance(Player.position, FinishWaypoint.position) > 2f)
        {
            Player.position = Vector3.MoveTowards(Player.position, FinishWaypoint.position, moveSpeed);
            yield return null;
        }
        Player.position = FinishWaypoint.position;
        standingOnPoint = true;
    }

    private void StartCounting()
    {

    }
}
