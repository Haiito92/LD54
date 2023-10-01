using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holes : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == player)
        {
            PlayerDie playerDieFonction = player.GetComponent<PlayerDie>();
            playerDieFonction.Die();
        }
    }
}
