using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardInventory_UI : MonoBehaviour
{
    public GameObject panel;
    public player player;
    public List<CardSlot_UI> slots = new List<CardSlot_UI>();
void Update()
{
    if(Input.GetKeyDown(KeyCode.C)) {
        ToggleInventory();
    }
}
public void ToggleInventory() {
    if(!panel.activeSelf) {
panel.SetActive(true);
Refresh();
    }else {
        panel.SetActive(false); 
    }
}
void Refresh() {
    Debug.Log("refresh called");
if(slots.Count == player.cardinv.slots.Count) {
    for(int i = 0; i < slots.Count; i++) {
        if(player.cardinv.slots[i].cardName != "") {
             slots[i].SetCard(player.cardinv.slots[i]);
        } else {
            slots[i].SetEmpty();
            Debug.Log("Slot: " + i + "is set empty");
        }
    } 
}
}
}
