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

    private float _normalSpeed;

    private Rigidbody2D _rb;
    private PlayerController _playerController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == _player)
        {
            _rb = _player.GetComponent<Rigidbody2D>();
            _playerController = _player.GetComponent<PlayerController>();
            _normalSpeed = _playerController.XSpeed;

        }



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            if (_goUp)
            {
                if(_rb.velocity.y > 0)
                {
                    _playerController.YSpeed = _normalSpeed * 1.5f;
                }else if(_rb.velocity.y < 0)
                {
                    _playerController.YSpeed = _normalSpeed / 2f;
                }
                else if(_rb.velocity.y == 0)
                {
                    _playerController.YSpeed = _normalSpeed / 2f;
                    _playerController.MovementVector = new Vector2(_playerController.MovementVector.x, 1);
                }
                
                //_rb.AddForce(Vector2.up * _conveyorBeltSpeed);
            }
            else if (_goDown)
            {
                if (_rb.velocity.y < 0)
                {
                    _playerController.YSpeed = _normalSpeed * 1.5f;
                }
                else if (_rb.velocity.y > 0)
                {
                    _playerController.YSpeed = _normalSpeed / 2f;
                }
                else if (_rb.velocity.y == 0)
                {
                    _playerController.YSpeed = _normalSpeed / 2f;
                    _playerController.MovementVector = new Vector2(_playerController.MovementVector.x, -1);
                }
                
                //_rb.AddForce(-Vector2.up * _conveyorBeltSpeed);
            }
            else if (_goRight)
            {
                if (_rb.velocity.x > 0)
                {
                    _playerController.XSpeed = _normalSpeed * 1.5f;
                }
                else if (_rb.velocity.x < 0)
                {
                    _playerController.XSpeed = _normalSpeed / 2f;
                }
                else if (_rb.velocity.x == 0)
                {
                    _playerController.XSpeed = _normalSpeed / 2f;
                    _playerController.MovementVector = new Vector2(1, _playerController.MovementVector.y);
                }

                //_rb.AddForce(Vector2.right * _conveyorBeltSpeed);
            }
            else if (_goLeft)
            {
                if (_rb.velocity.x < 0)
                {
                    _playerController.XSpeed = _normalSpeed * 1.5f;
                }
                else if (_rb.velocity.x > 0)
                {
                    _playerController.XSpeed = _normalSpeed / 2f;
                }
                else if (_rb.velocity.x == 0)
                {
                    _playerController.XSpeed = _normalSpeed / 2f;
                    _playerController.MovementVector = new Vector2(-1, _playerController.MovementVector.y);
                }
                //_rb.AddForce(-Vector2.right * _conveyorBeltSpeed);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _playerController.XSpeed = _normalSpeed;
        _playerController.YSpeed = _normalSpeed;
        _rb.velocity = Vector2.zero;
    }
}
