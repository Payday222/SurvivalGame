using System.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

public class enemy : MonoBehaviour
{
    public enemyData enemyData;
    public playerAttack pattack;
    
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
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Weapon") {
            TakeDamage(pattack.damage);
        }
    }
    public void FollowPlayer() {
        
    }
}
