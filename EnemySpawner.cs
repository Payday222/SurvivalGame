using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public player player;
public void MovePosition() {

        float x = Random.Range(player.transform.position.x - 6, player.transform.position.x + 6);
        float y = Random.Range(player.transform.position.y - 3, player.transform.position.y + 3);

        this.transform.position = new Vector2(x, y);
}
void Start()
{
    this.transform.position = new Vector2(0,0);
}
void Update()
{
    MovePosition();
}
}
