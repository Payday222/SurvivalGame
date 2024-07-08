using System.Collections.Generic;
using System.IO;
using UnityEngine;

[System.Serializable]
public class Item
{
    public System.Guid id;
    public string itemName;
    public int count;
}

[System.Serializable]
public class InventoryData
{
    public List<Item> items;
}

