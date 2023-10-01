using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goudrons : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    private float _speed;
    [SerializeField] GameObject player;


    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GetComponent<PlayerController>();
        }
    }
}
