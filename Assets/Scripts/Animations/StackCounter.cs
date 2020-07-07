using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class StackCounter : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private StackController stackController;

    [SerializeField]
    private GameObject counterPrefab;

    [SerializeField]
    private GameObject ComboPanel;    
    [SerializeField]
    private GameObject ProceedButton;
#pragma warning restore CS0649

    private List<Item> items;

    private ResourceCombo currentCombo;
    private ResourceCombo maxCombo;

    private List<Resource> resources = new List<Resource>();

    public void CountItems()
    {
        ComboPanel.SetActive(false);
        ProceedButton.SetActive(false);

        items = stackController.GetItems();

        StartCoroutine(Count());
    }

    public void Clear()
    {
        ComboPanel.SetActive(false);
        ProceedButton.SetActive(false);

        for (int i = 0; i < resources.Count; i++)
        {
            Destroy(resources[i].GetGameObject);
        }
        resources.Clear();

        currentCombo = new ResourceCombo();
        maxCombo = new ResourceCombo();
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
            CheckNewMaxCombo(resource);

            yield return new WaitForSeconds(0.07f);
        }

        if (resources.Count > 0)
        {
            ComboPanel.SetActive(true);
            ComboPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = maxCombo.resource.GetName;
            ComboPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = maxCombo.comboCount.ToString();
        }

        ProceedButton.SetActive(true);
    }

    private void CheckNewMaxCombo(Resource resource)
    {
        if (currentCombo.resource == resource)
        {
            currentCombo.comboCount++;
        }
        else
        {
            currentCombo = new ResourceCombo()
            {
                resource = resource,
                comboCount = 1
            };
        }

        if (currentCombo.comboCount > maxCombo.comboCount)
        {
            maxCombo = currentCombo;
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

        public GameObject GetGameObject => nameText.transform.parent.gameObject;

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

    private struct ResourceCombo
    {
        public Resource resource;
        public int comboCount;
    }
}
