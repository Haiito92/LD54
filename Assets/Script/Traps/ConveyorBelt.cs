using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] float conveyorBeltSpeed;
    [SerializeField] bool goUp;
    [SerializeField] bool goDown;
    [SerializeField] bool goRight;
    [SerializeField] bool goLeft;
    Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == player)
        {
            //player.GetComponent<PlayerController>().enabled = false;
            rb = player.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            if (goUp)
            {
                rb.AddForce(Vector2.up * conveyorBeltSpeed);
            }
            else if (goDown)
            {
                rb.AddForce(-Vector2.up * conveyorBeltSpeed);
            }  
            else if (goRight)
            {
                rb.AddForce(Vector2.right * conveyorBeltSpeed);
            }
            else if (goLeft)
            {
                rb.AddForce(-Vector2.right * conveyorBeltSpeed);
            }
        }
    }

    /*private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerController>().enabled = true;
        }
    }*/
}
