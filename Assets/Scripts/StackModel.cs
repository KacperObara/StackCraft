using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackModel
{
    private List<Item> _items = new List<Item>();
    public List<Item> Items
    {
        get { return _items; }
    }

    private bool IsEmpty => Items.Count == 0;

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void Pop()
    {
        if (!IsEmpty)
        {
            Items.RemoveAt(Items.Count - 1);
        }
    }
}
