using System.Collections.Generic;
using UnityEngine;
using System.IO;

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
    DontDestroyOnLoad(this);
}
      private void LoadInventory()
    {
        if (File.Exists(savePath))
        {
            Debug.Log("file path exists");
            string json = File.ReadAllText(savePath);
            inventoryData = JsonUtility.FromJson<InventoryData>(json);
            foreach (var item in inventoryData.items)
            {
                // Find the corresponding slot by item name
                Inventory.Slot slotToUpdate = player.inventory.slots.Find(slot => slot.itemname == item.itemName);

                if (slotToUpdate != null)
                {
                    // Update the slot's count
                    slotToUpdate.itemname = item.itemName;
                    slotToUpdate.count = item.count;
                }
                else
                {
                    Debug.LogWarning($"Slot for item '{item.itemName}' not found.");
                }
            }
        }
        else
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
                    count = slot.count
                };
                itemsToSave.Add(item);
            }
        }

        // Update the inventory data with the items to save
        inventoryData.items = itemsToSave;

        // Save the inventory data
        File.WriteAllText(savePath, JsonUtility.ToJson(inventoryData));
    }
}
