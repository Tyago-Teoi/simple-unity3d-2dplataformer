using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform player;
    public Transform respawnPoint;

    public EdgeCollider2D enemyWeapon;

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            player.transform.position = respawnPoint.transform.position;

        /*
        if (other.gameObject.CompareTag("Respawn1"))
        {
            player.transform.position = respawnPoint[1].transform.position;
        }
        */
                
    }
}
