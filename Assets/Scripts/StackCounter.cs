using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//TODO: Very bad naming, class does too much, records should be in it's own class. CheckRecord method is awful, Resource class can be done better
public class StackCounter : MonoBehaviour
{
    [SerializeField]
    private StackController stackController;

    [SerializeField]
    private GameObject counterPrefab;

    [SerializeField]
    private GameObject ComboPanel;

    private List<Item> items;

    private KeyValuePair<Resource, int> record;
    private KeyValuePair<Resource, int> recordCount;

    private List<Resource> resources = new List<Resource>();

    public void CountItems()
    {
        items = stackController.GetItems();

        StartCoroutine(Count());
    }

    // Animates resource counting at the end of the level
    private IEnumerator Count()
    {
        foreach (var item in items)
        {
            Resource resource;
            resource = FindResource(item.Name);
            if (resource == null)
            {
                GameObject resourceCounter = Instantiate(counterPrefab, transform);

                resource = new Resource(resourceCounter, item.Name);

                resources.Add(resource);
            }
            resource.IncrementCounter();
            CheckRecord(resource);

            yield return new WaitForSeconds(0.07f);
        }

        if (resources.Count > 0)
        {
            ComboPanel.SetActive(true);
            ComboPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = recordCount.Key.GetName;
            ComboPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = recordCount.Value.ToString();
        }
    }

    // TODO: change it for the love of God.
    private void CheckRecord(Resource resource)
    {
        if (record.Key == resource)
        {
            record = new KeyValuePair<Resource, int>(record.Key, record.Value + 1);

            if (record.Value > recordCount.Value)
            {
                recordCount = new KeyValuePair<Resource, int>(record.Key, record.Value);
            }
        }
        else
        {
            record = new KeyValuePair<Resource, int>(resource, 1);
        }
    }

    private Resource FindResource(string name)
    {
        foreach (Resource resource in resources)
        {
            if (resource.GetName == name)
            {
                return resource;
            }
        }

        return null;
    }

    private class Resource
    {
        private TextMeshProUGUI nameText;
        private TextMeshProUGUI countText;

        private int count;
        public string GetName => nameText.text;

        public Resource(GameObject counter, string text)
        {
            nameText = counter.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            countText = counter.transform.GetChild(1).GetComponent<TextMeshProUGUI>();

            nameText.text = text;
        }

        public void IncrementCounter()
        {
            count++;

            countText.text = count.ToString();
        }
    }
}
