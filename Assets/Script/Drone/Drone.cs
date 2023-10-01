using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Drone : MonoBehaviour
{
    #region Properties
    public bool IsDroneOut => _isDroneOut;
    #endregion

    [SerializeField] private float _speed;
    [SerializeField] private float _rapidSpeed;
    [SerializeField] private bool _isDroneOut;
    [SerializeField] private bool _isDroneOutRapid;

    [SerializeField] private Light2D _droneLight;
    [SerializeField, Range(0,1)] private float _lightIntensity;

    [SerializeField] private Rigidbody2D _rb;

    #region IEnumeratorsHolders
    private IEnumerator _droneBasicLightCoroutine;
    private IEnumerator _droneFlashLightCoroutine;
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _droneLight = GetComponentInChildren<Light2D>();
        _droneBasicLightCoroutine = DroneBasicLight();
        _droneFlashLightCoroutine = DroneFlashLight();
    }

    private void GetDirection(Vector2 targetPos, Quaternion rotation, float speed)
    {
        transform.rotation = rotation;
        Vector2 direction = targetPos - _rb.position;
        direction.Normalize();
        _rb.AddForce(direction * speed);
    }

    public void Move(Vector2 targetPos, Quaternion rotation)
    {
        _isDroneOut = true;
        GetDirection(targetPos, rotation, _speed);
        //_droneLight.intensity = 
    }

    public void RapidMove(Vector2 targetPos, Quaternion rotation)
    {
        _isDroneOut = true;
        _isDroneOutRapid = true;
        GetDirection(targetPos, rotation, _rapidSpeed);
    }

    private IEnumerator DroneBasicLight()
    {
        Debug.Log("BasicLight");
        yield return null;
    }

    private IEnumerator DroneFlashLight()
    {
        Debug.Log("FlashLight");
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rb.velocity = Vector2.zero;
        _droneLight.pointLightInnerAngle = 360;
        _droneLight.pointLightOuterAngle = 360;

        if (_isDroneOutRapid && _isDroneOut)
        {
            StartCoroutine(_droneFlashLightCoroutine);
        }
        else if (!_isDroneOutRapid && _isDroneOut)
        {
            StartCoroutine(_droneBasicLightCoroutine);
        }
    }

}
