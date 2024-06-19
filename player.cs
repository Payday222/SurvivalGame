using System.Security.AccessControl;
using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.VisualScripting;

public class player : MonoBehaviour
{
    //TODO:
    //1.Make wallclip fix better lol
    
    private Vector2 direction;

public Inventory inventory;
public GameObject SwordSwing;
public int maxHealth;
public int currentHealth;
public enum Dice {
        d4,
        d6,
        d8,
        d10,
        d12,
        d20,
}
public Dice dice;
void Start()
{
    maxHealth = 100;
    currentHealth = maxHealth;
}
void Update()
{
    Movement();
    Vector2 distance = new Vector2 (this.transform.position.x + 5, this.transform.position.y + 10);
}

void OnTriggerEnter2D(Collider2D other)
{
    if(other.gameObject.tag == "Enemy") {
      other.gameObject.GetComponent<enemy>().RollDamageDie();
      currentHealth -= other.gameObject.GetComponent<enemy>().damage;
      Debug.Log("" + currentHealth);
      Debug.Log("damage: " + other.gameObject.GetComponent<enemy>().damage);
    }
}
public void Movement() {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) {
        direction = Vector2.up;
    } else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
        direction = Vector2.left;
} else if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)) {
    direction = Vector2.down;
} else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
    direction = Vector2.right;
} 
if(Input.GetKeyUp(KeyCode.W) || (Input.GetKeyUp(KeyCode.UpArrow)) 
|| Input.GetKeyUp(KeyCode.A) || (Input.GetKeyUp(KeyCode.LeftArrow))
|| Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)
|| Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)) {
    direction = Vector2.zero;
}
}
void FixedUpdate()
{
    #region movement
    transform.position = new Vector2(
        transform.position.x + direction.x,
        transform.position.y + direction.y
    );
    #endregion movement
}
private void Awake()
{
    inventory = new Inventory(24);
}

public void DropItem(item item) {
    Vector2 spawnlocation = transform.position;

    Vector2 spawnOffset = UnityEngine.Random.insideUnitCircle * 1.25f;

    item droppedItem = Instantiate(item, spawnlocation + spawnOffset, Quaternion.identity);
    droppedItem.rb.AddForce(spawnOffset * 2f, ForceMode2D.Impulse);
 }
public bool CheckForSword() {
    Debug.Log(this.inventory.slots.Count);
    for(int i = this.inventory.slots.Count - 1; i >= 0; i--) {
        Debug.Log("i" + i);
        if(this.inventory.slots[i].itemname == "Sword") {
        Debug.Log("Player has a sword in their inventory, execute attack");
            return true;
        }
        
            Debug.Log("Player does not have a sword in their inventory");
    }
    return false;
} 

}

