using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [RequireComponent(typeof(item))]
public class Collectible : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D other)
{
player player = other.GetComponent<player>();
if (player) 
{
    item item = GetComponent<item>();

    if (item != null) {
        player.inventory.Add(item);
        Destroy(this.gameObject);
    }
}
    }
    }
