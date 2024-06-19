using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
[SerializeField] private Animator anim;
[SerializeField] private float meelespeed;

[SerializeField] public int damage = 50;

float timeUntillMelee;

private void Update()
{
                    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mousePos.y-transform.position.y, mousePos.x-transform.position.x) * Mathf.Rad2Deg - 90f;
        transform.localRotation = Quaternion.Euler(0, 0,angle);
    if(timeUntillMelee <= 0) {
        if(Input.GetKeyDown(KeyCode.Space)) {
              player.CheckForSword();
                 if(player.CheckForSword() == true) {
            anim.SetTrigger("Attack");
            timeUntillMelee = meelespeed;

        } 
        } else {
            timeUntillMelee -= Time.deltaTime;
        }
}
}
}
