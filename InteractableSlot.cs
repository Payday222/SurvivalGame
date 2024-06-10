using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class InteractableSlot : MonoBehaviour
{
    public HealingConsumable healingConsumable;
    void Update()
    {
        if(Input.GetMouseButtonDown(1)) {
            ShowContextMenu();
        }
    }
 public void ShowContextMenu() { 
GenericMenu menu = new GenericMenu();

 menu.AddItem(new GUIContent("Eat"), false, healingConsumable.ConsumeHealingConsumable(), this.transform.position);
 }
 }
