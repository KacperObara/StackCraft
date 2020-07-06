using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRunState : GameState
{
    public Transform FinishWaypoint;
    public Transform Player;

#pragma warning disable CS0649
    [SerializeField]
    private GameObject UI;

    [SerializeField]
    private StackCounter stackCounter;

    [SerializeField] 
    private GameObject player;

    [SerializeField] 
    private GameObject cam;

    [SerializeField]
    private GameObject mapsParent;

    [SerializeField]
    private StackController stackController;
#pragma warning restore CS0649

    [SerializeField]
    private float moveSpeed = 0;

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
        player.SetActive(false);
        cam.SetActive(true);

        mapsParent.SetActive(false);
        stackController.ResetStack();
    }

    public override void OnUpdate()
    {
        if (standingOnPoint == true)
        {
            GetComponent<CameraStackInspection>().Play();
            stackCounter.CountItems();
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
}
