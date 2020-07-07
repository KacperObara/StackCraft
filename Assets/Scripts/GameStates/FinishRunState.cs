using UnityEngine;

public class FinishRunState : GameState
{
    public Transform Player;

#pragma warning disable CS0649
    [SerializeField]
    private GameObject UI;

    [SerializeField]
    private StackCounter stackCounter;

    [SerializeField] 
    private GameObject player;

    [SerializeField]
    private GameObject mapsParent;

    [SerializeField]
    private StackController stackController;

    [SerializeField]
    private MovePlayerToWaypoint playerAnimation;
    [SerializeField]
    private MoveCameraToWaypoints cameraAnimation;

    [SerializeField]
    private float moveSpeed = 0;
#pragma warning restore CS0649

    public override string GetName()
    {
        return this.GetType().Name;
    }

    public override void OnEnter()
    {
        UI.SetActive(true);

        Vector3 endWaypoint = player.transform.position;
        endWaypoint.x = 0;
        endWaypoint.z += 20;

        playerAnimation.Play(endWaypoint, this);
    }

    public override void OnExit()
    {
        UI.SetActive(false);
        player.SetActive(false);

        mapsParent.SetActive(false);
        stackController.ResetStack();

        stackCounter.Clear();
    }

    public override void OnUpdate()
    {

    }

    // TODO: Make better use of the observer pattern 
    public void NotifyPlayerAnimationDone()
    {
        cameraAnimation.Play(this);
    }
    public void NotifyCameraAnimationDone()
    {
        stackCounter.CountItems();
    }
}
