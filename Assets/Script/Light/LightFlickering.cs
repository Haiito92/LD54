using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LightFlickering : MonoBehaviour
{
    private float _minRadiusValue;
    private float _maxRadiusValue;
    [SerializeField] float _secondsBetweenFlicks;

    [SerializeField] IEnumerator _lightFlicker;

    private void Awake()
    {
        _lightFlicker = LightFlicker();
    }

    private Light2D _light;
    void Start()
    {

        _light = GetComponent<Light2D>();
        _maxRadiusValue = _light.pointLightOuterRadius;
        _minRadiusValue = _maxRadiusValue - (_maxRadiusValue / 10);
        StartCoroutine(_lightFlicker);
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(Random.Range(0.01f,_secondsBetweenFlicks));
        _light.pointLightOuterRadius = Random.Range(_minRadiusValue, _maxRadiusValue);
        CycleLightFlicker();
    }

    public void StopLightFlicker()
    {
        StopCoroutine(_lightFlicker);
    }
    public void CycleLightFlicker()
    {
        StopCoroutine(_lightFlicker);
        _lightFlicker = LightFlicker();
        StartCoroutine(_lightFlicker);
    }

    public void DisableFlicker()
    {
        StopCoroutine(_lightFlicker);
    }
    public void EnableFlicker()
    {
        _lightFlicker = LightFlicker();
        StartCoroutine(_lightFlicker);
    }
}
