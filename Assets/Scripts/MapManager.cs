using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
#pragma warning disable CS0649
    [SerializeField]
    private List<GameObject> maps;
#pragma warning restore CS0649

    private GameObject existingMap;

    public void EnableMap(int i)
    {
        if (i >= maps.Count)
        {
            Debug.LogError("Map with this ID doesn't exist!");
            return;
        }

        if (transform.childCount > 1)
        {
            Debug.LogError("There is more than one map!");
            return;
        }

        if (existingMap != null)
            Destroy(existingMap);

        existingMap = Instantiate(maps[i], transform);
    }

}
