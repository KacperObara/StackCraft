using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRunState : GameState
{
    public Transform FinishWaypoint;
    public Transform Player;

    [SerializeField]
    private float moveSpeed;

    private bool standingOnPoint = false;

    public override string GetName()
    {
        return this.GetType().Name;
    }

    public override void OnEnter()
    {
        //StateManager.PopState();
        StartCoroutine(MoveToWaypoint());
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {
        if (standingOnPoint == true)
        {
            Debug.Log("KONIEC");
            StateManager.PopState();
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
}
