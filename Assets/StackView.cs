using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackView : MonoBehaviour
{
    private List<Pickable> stackItems = new List<Pickable>();

    [SerializeField]
    private Transform stack;
    [SerializeField]
    private Transform stackHead;

    [SerializeField]
    private float pickingSpeed = 0.2f;

    public void AddToStack(Pickable pickable)
    {
        stackItems.Add(pickable);

        pickable.transform.SetParent(stack, true);
        pickable.GetComponent<BoxCollider>().enabled = false;

        StartCoroutine(MoveToStack(pickable, stackHead.transform.localPosition));

        stackHead.position += new Vector3(0, pickable.Height, 0);
    }

    private IEnumerator MoveToStack(Pickable pickable, Vector3 targetPos)
    {
        while (Vector3.Distance(pickable.transform.localPosition, targetPos) > 0.1f)
        {
            pickable.transform.localPosition = Vector3.MoveTowards(pickable.transform.localPosition, targetPos, pickingSpeed);
            yield return null;
        }
        pickable.transform.localPosition = targetPos;
    }
}
