using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player && !PlayerDie._isOnPlatform)
        {
            PlayerDie playerDieFonction = player.GetComponent<PlayerDie>();
            playerDieFonction.Die();
        }
    }
}
