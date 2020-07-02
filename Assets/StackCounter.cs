using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackCounter : MonoBehaviour
{
    [SerializeField]
    private StackController stackController;

    [SerializeField]
    private GameObject counterPrefab;

    private List<Item> items;

    public Dictionary<string, GameObject> counters;

    private void CountItems()
    {
        items = stackController.GetItems();

        foreach (var item in items)
        {
            //if (names.Contains(item.Name) == false)
            //{
            //    names.Add(item.Name)
            //}
            //else
            //{

            //}
        }
    }
}
