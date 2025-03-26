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
        _normalSpeed = _playerController.XSpeed;
        if (_slow <= 0)
        {
            Debug.LogWarning("Slow value must be positive");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            _playerController.XSpeed = _playerController.XSpeed / _slow;
            _playerController.YSpeed = _playerController.YSpeed / _slow;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            _playerController.XSpeed = _normalSpeed;
            _playerController.YSpeed = _normalSpeed;
        }
    }
}
