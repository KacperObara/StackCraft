using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private StackController stackController;

    [SerializeField]
    private StateManager stateManager;

    [SerializeField]
    private AudioClip pickUpSound;
    [SerializeField]
    private AudioClip finishSound;
#pragma warning restore CS0649

    private AudioSource audioSource;

    private void OnValidate()
    {
        if (stackController == null)
            stackController = GetComponent<StackController>();

        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (stateManager.TopState.GetName() != "RunState")
            return;

        if (other.gameObject.layer == LayerMask.NameToLayer("Pickable"))
        {
            audioSource.PlayOneShot(pickUpSound);
            stackController.AddToStack(other.GetComponent<Pickable>());
        }
        if (other.gameObject.layer == LayerMask.NameToLayer("FinishLine"))
        {
            audioSource.PlayOneShot(finishSound);
            stateManager.PopState();
        }
    }
}
