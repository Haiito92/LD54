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

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Light2D _droneLight;

    #region IEnumeratorsHolders
    private IEnumerator _droneBasicLight;
    private IEnumerator _droneFlashLight;
    #endregion

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _droneLight = GetComponentInChildren<Light2D>();
        _droneBasicLight = DroneBasicLight();
        _droneFlashLight = DroneFlashLight();
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
            StartCoroutine(_droneFlashLight);
        }
        else if (!_isDroneOutRapid && _isDroneOut)
        {
            StartCoroutine(_droneBasicLight);
        }
    }

}
