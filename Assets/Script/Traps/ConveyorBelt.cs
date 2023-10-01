using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _conveyorBeltSpeed;
    [SerializeField] private bool _goUp;
    [SerializeField] private bool _goDown;
    [SerializeField] private bool _goRight;
    [SerializeField] private bool _goLeft;
    private Rigidbody2D _rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _player)
        {
            //player.GetComponent<PlayerController>().enabled = false;
            _rb = _player.GetComponent<Rigidbody2D>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            if (_goUp)
            {
                _rb.AddForce(Vector2.up * _conveyorBeltSpeed);
            }
            else if (_goDown)
            {
                _rb.AddForce(-Vector2.up *_conveyorBeltSpeed);
            }  
            else if (_goRight)
            {
                _rb.AddForce(Vector2.right * _conveyorBeltSpeed);
            }
            else if (_goLeft)
            {
                _rb.AddForce(-Vector2.right * _conveyorBeltSpeed);
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
