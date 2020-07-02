using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackController : MonoBehaviour
{
    [SerializeField]
    private StackView stackView;

    private StackModel stackModel;

    private void Awake()
    {
        stackModel = new StackModel();
    }

    public void OnTriggerEnter(Collider other)
    {
       if (other.GetComponent<Pickable>())
       {
            stackModel.AddItem(other.GetComponent<Pickable>().Item);
            stackView.AddToStack(other.GetComponent<Pickable>());
       }
    }
}
