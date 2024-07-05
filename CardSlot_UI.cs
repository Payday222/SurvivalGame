using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardSlot_UI : MonoBehaviour
{
public UnityEngine.UI.Image cardIcon;
public void SetCard(CardsInventory.Slot slot) {
    if(slot != null) {
        cardIcon.sprite = slot.icon;
        cardIcon.color = new Color(1,1,1,1);
        // Debug.Log(cardIcon.sprite); 

    }
}
public void SetEmpty() {
    cardIcon.sprite = null;
    cardIcon.color = new Color(1,1,1,1);
}
}
