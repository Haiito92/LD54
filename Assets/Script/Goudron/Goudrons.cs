using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Goudrons : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _slow;
    private float _normalSpeed;
    [SerializeField, Tag] private string _playerTag;

    void Start()
    {
        _normalSpeed = _playerController.Speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            _playerController.Speed = _playerController.Speed / _slow;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            _playerController.Speed = _normalSpeed;
        }
    }
}
