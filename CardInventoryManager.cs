using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class CardInventoryManager : MonoBehaviour
{
public player player;

    private CardInventoryData cardInventoryData = new CardInventoryData();

    private string savePath => Path.Combine(Application.persistentDataPath, "cardInventory.json");
    

    void OnApplicationQuit()
    {
        SaveInventory();
    }

    void Start()
    {
        LoadInventory();
    }
    private void LoadInventory() {
        if(File.Exists(savePath)) {
            string json = File.ReadAllText(savePath);
            cardInventoryData = JsonUtility.FromJson<CardInventoryData>(json);

            for(int i = 0; i <= cardInventoryData.cards.Count; i++) {
                var card = cardInventoryData.cards.ElementAt(i);
                CardsInventory.Slot slotToUpdate = new CardsInventory.Slot();

                slotToUpdate.count = card.count;
                slotToUpdate.cardName = card.itemName;
                slotToUpdate.icon = card.icon;

                if(slotToUpdate != null) {
                    slotToUpdate.cardName = card.itemName;
                    slotToUpdate.count = card.count;

                    if(player.cardinv.slots[i].cardName == "") {
                        player.cardinv.slots[i].cardName = slotToUpdate.cardName;
                        player.cardinv.slots[i].count = slotToUpdate.count;
                        player.cardinv.slots[i].icon = slotToUpdate.icon;
                    } 
                } else
                {
                    Debug.LogWarning($"Slot for item '{card.itemName}' not found.");
                }


            }
        }
    }
    private void SaveInventory() {
        List<SerializableCard> itemsToSave = new List<SerializableCard>();

        foreach (var slot in player.cardinv.slots) {
            if(!string.IsNullOrEmpty(slot.cardName)) {
                
                SerializableCard card = new SerializableCard {
                  itemName = slot.cardName,
                  count = slot.count,
                  icon = slot.icon  
                };
                itemsToSave.Add(card);
            }
        }
        cardInventoryData.cards = itemsToSave;

        File.WriteAllText(savePath, JsonUtility.ToJson(cardInventoryData));
    }
}