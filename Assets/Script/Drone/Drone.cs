using NaughtyAttributes;
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

    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private Light2D _droneLight;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _droneLight = GetComponentInChildren<Light2D>();
    }

    public void Move(Vector2 targetPos, Quaternion rotation)
    {
        _isDroneOut = true;
        transform.rotation = rotation;
        Vector2 direction = targetPos - _rb.position;
        direction.Normalize();
        _rb.AddForce(direction * _speed);
    }

    public void RapidMove(Vector2 targetPos, Quaternion rotation)
    {
        _isDroneOut = true;
        transform.rotation = rotation;
        Vector2 direction = targetPos - _rb.position;
        direction.Normalize();
        _rb.AddForce(direction * _rapidSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _rb.velocity = Vector2.zero;
        _droneLight.pointLightInnerAngle = 360;
        _droneLight.pointLightOuterAngle = 360;
    }
}
