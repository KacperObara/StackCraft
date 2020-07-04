using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string Name;

	// If the Name field is empty, use the asset name
	private void OnValidate()
	{
		if (string.IsNullOrEmpty(Name))
		{
			string assetPath = AssetDatabase.GetAssetPath(this.GetInstanceID());
			Name = Path.GetFileNameWithoutExtension(assetPath);
		}
	}
}
