using UnityEngine;

public class MenuState : GameState
{
#pragma warning disable CS0649
    [SerializeField]
    private GameObject MenuPanel;
#pragma warning restore CS0649

    public override string GetName()
    {
        return this.GetType().Name;
    }

    public override void OnEnter()
    {
        MenuPanel.SetActive(true);
    }

    public override void OnExit()
    {
        MenuPanel.SetActive(false);
    }

    public override void OnUpdate()
    {

    }
}
