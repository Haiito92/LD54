using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SensorDetection : MonoBehaviour
{
    private GameObject _collideTarget;
    private GameObject[] _sensors;

    private float _distance;

    void Start()
    {
        _collideTarget = gameObject;
        _sensors = GameObject.FindGameObjectsWithTag("Sensor");
    }

    void Update()
    {
        foreach(GameObject sensor in _sensors)
        {
            _distance = Vector2.Distance(_collideTarget.transform.position, sensor.transform.position);
            if (_distance < _collideTarget.GetComponent<Light2D>().pointLightOuterRadius)
            {
                Debug.Log("SENSOR");
                break;
            }
        }
    }
}
