using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlateforms : MonoBehaviour
{
    public bool _isActivated;
    [SerializeField] private Transform _arrivingPoint;
    [SerializeField] private float _plateformSpeed;
    private Vector3 _basePosition;

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
}
