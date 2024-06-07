using System.Runtime.InteropServices;
using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using Unity.Mathematics;
using System;
using System.Data.Common;

public class enemy : MonoBehaviour
{
    public enemyData enemyData;
    public playerAttack pattack;
        public int damage;
        private void Update()
    {
        if(this.enemyData.enemyCurrentHealth <= 0) {
            Destroy(this.gameObject);
        }
    }
    
    void Start()
    {
             RollHealthDice();
            this.enemyData.enemyCurrentHealth = this.enemyData.enemyMaxHealth;
            Debug.Log(this.enemyData.enemyMaxHealth);
    }

    public void TakeDamage(int damageTaken) {
        enemyData.enemyHealth -= damageTaken;
        if(enemyData.enemyHealth <= 0) {
            Destroy(this.gameObject);

        }
    }
   public void RollDamageDie() {

        switch(this.enemyData._damageDice) {
            case enemyData.damageDice.d4: 
                damage = UnityEngine.Random.Range(1, 5);
            break;
            case enemyData.damageDice.d6:
                damage = UnityEngine.Random.Range(1,7);
            break;

            case enemyData.damageDice.d8:
                damage = UnityEngine.Random.Range(1,9);
            break;

            case enemyData.damageDice.d10:
                damage = UnityEngine.Random.Range(1, 11);
            break;

            case enemyData.damageDice.d12:
                damage = UnityEngine.Random.Range(1, 13);
            break;

            case enemyData.damageDice.d20:
                damage = UnityEngine.Random.Range(1, 21);
            break;

            default:
            damage = 1000000000; //haha die
            Debug.Log("Damagedie is invalid");
            break;
        }
   }
    public void RollHealthDice() {
        switch(this.enemyData._healthDice) {
            case enemyData.healthDice.d4:
            this.enemyData.enemyMaxHealth = UnityEngine.Random.Range(1, 5);
            break;
            case enemyData.healthDice.d6:
            this.enemyData.enemyMaxHealth = UnityEngine.Random.Range(1, 7);
            break;
            case enemyData.healthDice.d8:
            this.enemyData.enemyMaxHealth = UnityEngine.Random.Range(1, 9);
            break;
            case enemyData.healthDice.d10:
            this.enemyData.enemyMaxHealth  = UnityEngine.Random.Range(1,11);
            break;
            case enemyData.healthDice.d12:
            this.enemyData.enemyMaxHealth  = UnityEngine.Random.Range(1,13);
            break;
            case enemyData.healthDice.d20:
            this.enemyData.enemyMaxHealth  = UnityEngine.Random.Range(1,21);
            break;
            default:
            Debug.Log("enemy health dice is invalid");
            this.enemyData.enemyCurrentHealth = 0; // haha die
            break;
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Weapon") {
            TakeDamage(pattack.damage);
        }
    }
}
