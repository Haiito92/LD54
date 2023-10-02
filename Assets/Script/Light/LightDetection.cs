using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightDetection : MonoBehaviour
{
    private GameObject _collideTarget;
    private GameObject[] _lights;

    [SerializeField] private GameObject _monster;

    private float _distance;

    void Start()
    {
        _collideTarget = gameObject;
        _lights = GameObject.FindGameObjectsWithTag("Lights");
    }

    void Update()
    {
        _lights = GameObject.FindGameObjectsWithTag("Lights");
        foreach (GameObject light in _lights)
        {
            _distance = Vector2.Distance(_collideTarget.transform.position, light.GetComponent<Light2D>().transform.position);
            if (_distance < light.GetComponent<Light2D>().pointLightOuterRadius)
            {
                Debug.Log("Safe");

                break;
            }
        }
    }
}
