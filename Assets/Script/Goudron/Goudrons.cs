using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goudrons : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] private GameObject player;
    [SerializeField] private float slow;
    private float _normalSpeed;

    void Start()
    {
        playerController = player.GetComponent<PlayerController>();
        _normalSpeed = playerController.Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerController.Speed = playerController.Speed / slow;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerController.Speed = _normalSpeed;
        }
    }
}
