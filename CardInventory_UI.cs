using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardInventory_UI : MonoBehaviour
{
    public GameObject panel;
    public player player;
    public List<CardSlot_UI> slots = new List<CardSlot_UI>();
    public CardSlot_UI selectedSlot;
    public int slotIndex = 0;
    public EnemySpawner enemySpawner;
    public bool isActive;
void Update()
{
    if(Input.GetKeyDown(KeyCode.C)) {
        ToggleInventory();
    }
if(isActive == true) {
    SelectSlot();
     UseCard();
}
}
public void ToggleInventory() {

    if(!panel.activeSelf) {
panel.SetActive(true);
isActive = true;
Refresh();
    }else {
        panel.SetActive(false); 
    isActive = false;
    }
}
void Refresh() {
    Debug.Log("refresh called");
if(slots.Count == player.cardinv.slots.Count) {
    for(int i = 0; i < slots.Count; i++) {
        if(player.cardinv.slots[i].cardName != "") {
             slots[i].SetCard(player.cardinv.slots[i]);
        } else {
            this.slots[i].SetEmpty();
            Debug.Log("Slot: " + i + "is set empty");
        }
    } 
}
}
public void SelectSlot() {
    if(Input.GetKeyDown(KeyCode.RightArrow)) {
        slotIndex++;
        selectedSlot = slots[slotIndex];
        HighlightSlot();

    }
    if(Input.GetKeyDown(KeyCode.LeftArrow)) {
        slotIndex--;
        selectedSlot = slots[slotIndex];
        HighlightSlot();
    }
}

private void HighlightSlot() {

         IEnumerator ChangeSlotColorToWhite() {
            yield return new WaitForSeconds(0.4f);

            selectedSlot.cardIcon.color = Color.white;
         }

        selectedSlot.cardIcon.color = Color.red;

        StartCoroutine (ChangeSlotColorToWhite());
         StartCoroutine (DeleteSelections());

}
private IEnumerator DeleteSelections() {
    for(int i = slots.Count - 1; i >= 0; i--) {
        if(slots[i].cardIcon.color == Color.red && i != slotIndex) {
            slots[i].cardIcon.color = Color.white;
        }
    }
    yield return new WaitForSeconds(0.5f);
        

    }
                public GameObject skeleton;

 public void UseCard() {
     if(Input.GetKeyDown(KeyCode.E)) {
         enemySpawner = GetComponent<EnemySpawner>();
          selectedSlot.SetEmpty();
            //  enemySpawner.MovePosition(); // nullreference //! fix this one day maybe lol
         switch(player.cardinv.slots[slotIndex].cardName) {
             case "Skeleton":
                  Instantiate(skeleton, enemySpawner.transform); //nullreference... theres no escape
             break;
         }
     }
 }
}
