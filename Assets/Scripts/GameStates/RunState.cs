using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : GameState
{
    [SerializeField] private AutoMovement autoMovement;
    [SerializeField] private MouseInput mouseInput;

    public override string GetName()
    {
        return this.GetType().Name;
    }

    public override void OnEnter()
    {
        autoMovement.enabled = true;
        mouseInput.enabled = true;
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
