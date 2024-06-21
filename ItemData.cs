using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Item Deta", menuName ="Item Data", order =50)]
public class itemdata : ScriptableObject
{
public string itemName = "Item Name";
public Sprite icon;

public string InteractionType;
//! INTERACTION TYPES:
//* Eat
//* Hurt
}
