using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : GameState
{
#pragma warning disable CS0649
    [SerializeField] 
    private AutoMovement autoMovement;
    [SerializeField] 
    private MouseInput mouseInput;
    [SerializeField] 
    private GameObject player;
    [SerializeField] 
    private GameObject cam;
    [SerializeField]
    private GameObject mapsParent;
#pragma warning restore CS0649

    public override string GetName()
    {
        return this.GetType().Name;
    }

    public override void OnEnter()
    {
        autoMovement.enabled = true;
        mouseInput.enabled = true;
        //player.GetComponent<Rigidbody>().useGravity = true;
        player.SetActive(true);
        player.transform.position = new Vector3(0, 1, 0);
        cam.SetActive(false);

        mapsParent.SetActive(true);
    }

    public override void OnExit()
    {
        autoMovement.enabled = false;
        mouseInput.enabled = false;
    }

    public override void OnUpdate()
    {

    }
}
