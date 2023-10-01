using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightDetection : MonoBehaviour
{
    private GameObject _player;
    private Light2D _light;

    private float _distance;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _light = GetComponent<Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _distance = Vector2.Distance(_player.transform.position, _light.transform.position);
        if (_distance < _light.pointLightOuterRadius)
        {
            Debug.Log("Safe");
        } else
        {
            Debug.Log("Unsafe");
        }
    }
}
