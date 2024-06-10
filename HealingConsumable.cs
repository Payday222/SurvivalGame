using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingConsumable : MonoBehaviour
{
    public HealingConsumableData healingConsumableData;
    public void ConsumeHealingConsumable() {
        player player = GetComponent<player>();
        healingConsumableData.RollHealingDice();
         player.currentHealth += healingConsumableData.healthToAdd;

         if(healingConsumableData.addMaxHealh == true) {
            healingConsumableData.RollHealingDice();
            player.maxHealth += healingConsumableData.healthToAdd; //Risky maneuver, but sure, should work
         }
    }
}
