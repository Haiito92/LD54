using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MovingPlateforms : Activable
{
    //public bool _isActivated;
    [SerializeField] private Transform _arrivingPoint;
    [SerializeField] private float _plateformSpeed;
    private Vector3 _basePosition;

    [SerializeField] private GameObject _player;

    private void Start()
    {
        _basePosition = transform.position;
    }

    private void Update()
    {
        if (_isActivated)
        {
            transform.position = Vector2.MoveTowards(transform.position, _arrivingPoint.position, _plateformSpeed * Time.deltaTime);
        }
        else if (!_isActivated)
        {
            transform.position = Vector2.MoveTowards(transform.position, _basePosition, _plateformSpeed * Time.deltaTime);
        }
    }

    public override void Activate()
    {
        base.Activate();

        _isActivated = true;
    }

    public override void Deactivate()
    {
        base.Deactivate();

        _isActivated = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            PlayerDie._isOnPlatform = true;
            _player.transform.SetParent(gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == _player)
        {
            PlayerDie._isOnPlatform = false;
            _player.transform.SetParent(null);
        }
    }
}
