using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class CardInventoryData
{
      public List<SerializableCard> cards;
     public Dictionary<string, int> cardsToAdd = new Dictionary<string, int>();
}



 [System.Serializable]
 public class SerializableCard
 {
     public System.Guid id;
     public string itemName;
     public int count;
     public Sprite icon;
 }



