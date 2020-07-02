using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField]
    private StackController stackController;

    [SerializeField]
    private StateManager stateManager;

    private void OnValidate()
    {
        if (stackController == null)
            stackController = GetComponent<StackController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (stateManager.TopState.GetName() != "RunState")
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Pickable"))
        {
            stackController.AddToStack(other.GetComponent<Pickable>());
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("FinishLine"))
        {
            stateManager.PopState();
        }
    }
}
