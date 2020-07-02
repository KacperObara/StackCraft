using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuState : GameState
{
    public override string GetName()
    {
        return this.GetType().Name;
    }

    public override void OnEnter()
    {
        StateManager.PopState();
    }

    public override void OnExit()
    {

    }

    public override void OnUpdate()
    {

    }
}
