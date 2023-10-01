using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LightFlickering : MonoBehaviour
{
    [SerializeField] float _minRadiusValue;
    [SerializeField] float _maxRadiusValue;
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
        StartCoroutine(_lightFlicker);
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(Random.Range(0.01f,_secondsBetweenFlicks));
        _light.pointLightOuterRadius = Random.Range(_minRadiusValue, _maxRadiusValue);
        StartCoroutine(_lightFlicker);
    }

    public void StopLightFlicker()
    {
        StopCoroutine(_lightFlicker);
    }
}
