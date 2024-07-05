using System.Security.Authentication;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class CardsInventory
{
    [System.Serializable]
    public class Slot {
        public Collectible collectible;
        public string cardName;
        public int count;
        public int maxAllowed;
        public Sprite icon;

        public Slot() {
            cardName = "";
            count = 0;
            maxAllowed = 314;
        }
        public bool CanAddItem() {
            if(count < maxAllowed)
             {
            return true;
        } else 
        {
            return false;  
        }
    }
        public void AddItem(Card card) {
        this.cardName = card.cardData.cardname;
        this.icon = card.cardData.icon;
        count++;
        }
        public void RemoveItem() {
            if(count > 0) {
                count--;
            }
            if(count == 0) {
                icon = null;
                cardName = "";
            }
        }
    }
    public List<Slot> slots = new List<Slot>();

    public CardsInventory(int numSlots) {
        for(int i = numSlots; i > 0; i--) {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    public void Add(Card card) {
        foreach(Slot slot in slots) {
            if(slot.cardName == card.cardData.cardname && slot.CanAddItem()) {
                slot.AddItem(card);
                return;
            }
        }
        foreach(Slot slot in slots) {
            if(slot.cardName == "") {
                slot.AddItem(card);
                return;
            }
        }
    }
    public void Remove(int index) {
    slots[index].RemoveItem();
    }

}
