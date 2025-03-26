using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;


public class LightOnOff : MonoBehaviour
{
    [SerializeField] float _maxSecondsBetweenFlicks;
    [SerializeField] float _minSecondsBetweenFlicks;
    [SerializeField] float _maxSecondsBetweenLight;

    private float _tempRad;


    private Light2D _light;
    void Start()
    {
        _light = GetComponent<Light2D>();
        StartCoroutine(LightFlicker());
    }

    IEnumerator LightFlicker()
    {
        yield return new WaitForSeconds(Random.Range(_minSecondsBetweenFlicks, _maxSecondsBetweenFlicks));
        int rValue = Random.Range(1, 5);
        for (int i = 0; i< rValue; i++)
        {
            _tempRad = _light.pointLightOuterRadius;
            _light.pointLightOuterRadius = 0.0f;
            yield return new WaitForSeconds(Random.Range(0.01f, _maxSecondsBetweenLight));
            _light.pointLightOuterRadius = _tempRad;
            yield return new WaitForSeconds(Random.Range(0.01f, _maxSecondsBetweenLight)/2);
        }
        StartCoroutine(LightFlicker());
    }
}
