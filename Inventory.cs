using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot {
        public Collectible collectible;
        public string itemname;
        public int count;
        public int maxAllowed;
                public Sprite icon;

        public Slot() {
            itemname = "";
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
        public void AddItem(item item) {
        this.itemname = item.itemdata.itemName;
        this.icon = item.itemdata.icon;
        count++;
        }
        public void RemoveItem() {
            if(count > 0) {
                count--;
            }
            if(count == 0) {
                icon = null;
                itemname = "";
            }
        }
    }
    public List<Slot> slots = new List<Slot>();

    public Inventory(int numSlots) {
        for(int i = numSlots; i > 0; i--) {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }
    public void Add(item item) {
        foreach(Slot slot in slots) {
            if(slot.itemname == item.itemdata.itemName && slot.CanAddItem()) {
                slot.AddItem(item);
                return;
            }
        }
        foreach(Slot slot in slots) {
            if(slot.itemname == "") {
                slot.AddItem(item);
                return;
            }
        }
    }
    public void Remove(int index) {
    slots[index].RemoveItem();
    }

}
