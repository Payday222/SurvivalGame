using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class InventoryManager : MonoBehaviour
{
public player player;

    private InventoryData inventoryData = new InventoryData();
    private string savePath => Path.Combine(Application.persistentDataPath, "inventory.json");

    // ... Other methods and variables ...
void OnApplicationQuit()
{
    SaveInventory();
}

void Start()
{
    LoadInventory();
    // DontDestroyOnLoad(this);
}
      private void LoadInventory()
    {
        if (File.Exists(savePath))
        {
            // Debug.Log("file path exists");
            string json = File.ReadAllText(savePath);
            inventoryData = JsonUtility.FromJson<InventoryData>(json);
            // foreach (var item in inventoryData.items) // itemdata item, not oinventory item
            for(int i = 0; i < inventoryData.items.Count; i++) {
            
                Debug.Log("index: " + i);

                var item = inventoryData.items.ElementAt(i); // cant use index on a list
                Inventory.Slot slotToUpdate = new Inventory.Slot();
                slotToUpdate.count = item.count;
                slotToUpdate.itemname = item.itemName;
                slotToUpdate.icon = item.icon;
                Debug.Log("itemanme" + slotToUpdate.itemname);
                Debug.Log("count" + slotToUpdate.count);

                if (slotToUpdate != null)
                {
                    slotToUpdate.itemname = item.itemName;
                    slotToUpdate.count = item.count;
                    // Debug.Log("adding slot to update");

                        if(player.inventory.slots[i].itemname == "") {
                            player.inventory.slots[i].itemname = slotToUpdate.itemname;
                            player.inventory.slots[i].count = slotToUpdate.count;
                            player.inventory.slots[i].icon = slotToUpdate.icon;
                        } else if(player.inventory.slots[i].itemname == slotToUpdate.itemname) {
                            player.inventory.slots[i].count = slotToUpdate.count;
                        }
                    //please work:
                    //thank you..... 
                }
                else
                {
                    Debug.LogWarning($"Slot for item '{item.itemName}' not found.");
                }
            
        
 
    }
        } else
        {
            Debug.LogWarning("Inventory file not found. Creating a new one.");
        }
    }
    private void SaveInventory()
    {
        // Convert Inventory slots to a list of items with names and counts
        List<Item> itemsToSave = new List<Item>();
        foreach (var slot in player.inventory.slots)
        {
            if (!string.IsNullOrEmpty(slot.itemname))
            {
                Item item = new Item
                {
                    itemName = slot.itemname,
                    count = slot.count,
                    icon = slot.icon
                    
                };
                itemsToSave.Add(item);
            }
        }

        inventoryData.items = itemsToSave;

        // Save the inventory data
        File.WriteAllText(savePath, JsonUtility.ToJson(inventoryData));
    }
}
