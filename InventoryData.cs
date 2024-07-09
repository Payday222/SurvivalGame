using System.Collections.Generic;

 [System.Serializable]

public class InventoryData
{
      public List<Item> items;
     public Dictionary<string, int> itemsToAdd = new Dictionary<string, int>();
}



 [System.Serializable]
 public class Item
 {
     public System.Guid id;
     public string itemName;
     public int count;
 }



