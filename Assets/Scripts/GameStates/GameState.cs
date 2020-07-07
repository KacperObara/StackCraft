using UnityEngine;

// This can't be an interface, because the inspector doesn't serialize interfaces
public abstract class GameState : MonoBehaviour
{
    public StateManager StateManager { get; set; }
    public abstract string GetName();

    public abstract void OnEnter();
    public abstract void OnExit();
    public abstract void OnUpdate();
}
