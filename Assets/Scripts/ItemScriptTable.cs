using System;
using UnityEngine;

[CreateAssetMenu (fileName = "Item", menuName ="ScripTableObjetcts/ItemScripTableObject")]
public class ItemScriptTable : ScriptableObject
{
    public String itemName;
    public String ItemDescription;
    public Sprite itemPreview;
    public GameObject itemObj;

}
