using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LightFlickering : MonoBehaviour
{
    [SerializeField] float _minRadiusValue;
    [SerializeField] float _maxRadiusValue;
    [SerializeField] float _secondsBetweenFlicks;


    private Light2D _light;
    void Start()
    {
        _light = GetComponent<Light2D>();
        StartCoroutine(LightFlicker());
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(Random.Range(0.01f,_secondsBetweenFlicks));
        _light.pointLightOuterRadius = Random.Range(_minRadiusValue, _maxRadiusValue);
        StartCoroutine(LightFlicker());
    }
}
