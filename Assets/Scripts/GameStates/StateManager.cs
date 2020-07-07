using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour
{
    [SerializeField]
    private List<GameState> statesStack = new List<GameState>();

    public List<GameState> statesStackTemplate;    

    public GameState TopState
    {
        get
        {
            if (statesStack.Count < 0)
            {
                Debug.LogError("There are no states left in the stack!");
            }

            return statesStack[statesStack.Count - 1];
        }
    }

    private void Awake()
    {
        foreach (GameState state in statesStack)
        {
            state.StateManager = this;
        }

        statesStackTemplate = new List<GameState>(statesStack);

        TopState.OnEnter();
    }

    public void PopState()
    {
        if (statesStack.Count <= 1)
        {
            Debug.LogError("Cannot pop the last item in the stack!");
        }

        TopState.OnExit();
        statesStack.Remove(TopState);

        TopState.OnEnter();
    }

    public void ResetStates()
    {
        TopState.OnExit();
        statesStack = new List<GameState>(statesStackTemplate);
        TopState.OnEnter();
    }

    private void Update()
    {
        TopState.OnUpdate();
    }
}
