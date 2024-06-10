using System.ComponentModel.Design;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Healing Consumable", menuName ="Create New Healing Consumable")]
public class HealingConsumableData : ScriptableObject
{
    public enum Dice {
        d4, d6, d8, d10, d12, d20
    }
    public Dice dice;
public int healthToAdd;
public bool addMaxHealh;

public void RollHealingDice() {
    switch(dice) {
        case Dice.d4:
    healthToAdd = Random.Range(1, 5);
        break;
        case Dice.d6: 
        healthToAdd = Random.Range(1,7);
        break;
        case Dice.d10:
        healthToAdd = Random.Range(1,11);
        break;
        case Dice.d12:
        healthToAdd = Random.Range(1,13);
        break;
        case Dice.d20:
        healthToAdd = Random.Range(1,21);
        break;
        default:
        Debug.Log("dice in HealingConsumableData is not valid");
        break;
    }
}
}
