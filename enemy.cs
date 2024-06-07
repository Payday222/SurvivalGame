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
    public damageDie _damagedie;
    public enum damageDie {
        d4,
        d6,
        d8,
        d10,
        d12,
        d20,
    }
    
    void Start()
    {
        enemyData.enemyHealth = 150;
    }

    public void TakeDamage(int damageTaken) {
        enemyData.enemyHealth -= damageTaken;
        if(enemyData.enemyHealth <= 0) {
            Destroy(this.gameObject);

        }
    }
        public void RollDamageDie() {
        switch(_damagedie) {
            case damageDie.d4: 
                damage = UnityEngine.Random.Range(1, 5);
            break;
            case damageDie.d6:
                damage = UnityEngine.Random.Range(1,7);
            break;

            case damageDie.d8:
                damage = UnityEngine.Random.Range(1,9);
            break;

            case damageDie.d10:
                damage = UnityEngine.Random.Range(1, 11);
            break;

            case damageDie.d12:
                damage = UnityEngine.Random.Range(1, 13);
            break;

            case damageDie.d20:
                damage = UnityEngine.Random.Range(1, 21);
            break;

            default:
            damage = 1000000000; //haha die
            Debug.Log("Damagedie is invalid");
            break;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Weapon") {
            TakeDamage(pattack.damage);
        }
    }
    public void FollowPlayer() {
        
    }
}
