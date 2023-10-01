using NaughtyAttributes;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Drone : MonoBehaviour
{
    #region Properties
    public bool IsDroneOut => _isDroneBasic;
    #endregion

    [SerializeField] private float _speed;
    [SerializeField] private float _rapidSpeed;
    private bool _isDroneBasic;
    private bool _isDroneRapid;

    [SerializeField] private Light2D _droneLight;
    [SerializeField, Tag] private string _droneLightTag;
    [SerializeField] private LightFlickering _lightFlickering;  
    [SerializeField, Range(0, 20)] private float _basicLightIntensity;
    [SerializeField, Range(0, 30)] private float _basicLightOuterRadius;
    [SerializeField, Range(0, 20)] private float _flashLightIntensity;
    [SerializeField, Range(0, 30)] private float _flashLightOuterRadius;
    [SerializeField] private float _basicLightDuration;
    [SerializeField] private float _flashLightDuration;

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private PlayerAim _playerAim;

    #region IEnumeratorsHolders
    private IEnumerator _droneBasicLightCoroutine;
    private IEnumerator _droneFlashLightCoroutine;
    #endregion

    private void Awake()
    {
        _droneBasicLightCoroutine = DroneBasicLight();
        _droneFlashLightCoroutine = DroneFlashLight();
    }

    public void GetPlayerAim(PlayerAim playerAim)
    {
        _playerAim = playerAim;
    }

    private void SendDrone(Vector2 targetPos, Quaternion rotation, float speed)
    {
        transform.rotation = rotation;
        Vector2 direction = targetPos - _rb.position;
        direction.Normalize();
        _rb.AddForce(direction * speed);
        _droneLight.intensity = _basicLightIntensity;
    }

    public void Move(Vector2 targetPos, Quaternion rotation)
    {
        _isDroneBasic = true;
        SendDrone(targetPos, rotation, _speed); 
    }

    public void RapidMove(Vector2 targetPos, Quaternion rotation)
    {
        _isDroneRapid = true;
        SendDrone(targetPos, rotation, _rapidSpeed);
    }

    private IEnumerator DroneBasicLight()
    {
        Debug.Log("BasicLight");
        yield return new WaitForSeconds(_basicLightDuration);
        DestroyDrone(_droneBasicLightCoroutine);

    }

    private IEnumerator DroneFlashLight()
    {
        Debug.Log("FlashLight");

        FlashLight();
        yield return new WaitForSeconds(_flashLightDuration);
        DestroyDrone(_droneFlashLightCoroutine);
    }

    private void DestroyDrone(IEnumerator coroutine)
    {
        StopCoroutine(coroutine);
        _playerAim.IsDroneOut = false;
        Destroy(gameObject);
    }

    private void FlashLight()
    {
        
        _droneLight.pointLightOuterRadius = _flashLightOuterRadius;
        _droneLight.intensity = _flashLightIntensity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rb.velocity = Vector2.zero;
        _droneLight.tag = _droneLightTag;
        _droneLight.pointLightInnerAngle = 360;
        _droneLight.pointLightOuterAngle = 360;

        if (_isDroneRapid && !_isDroneBasic)
        {
            StartCoroutine(_droneFlashLightCoroutine);
        }
        else if (_isDroneBasic && !_isDroneRapid)
        {
            StartCoroutine(_droneBasicLightCoroutine);
        }
    }

}
