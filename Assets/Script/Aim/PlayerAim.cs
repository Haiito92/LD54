using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerAim : MonoBehaviour
{
    #region Properties
    public bool IsDroneOut
    {
        get { return _isDroneOut; }
        set 
        { 
            _isDroneOut = value; 
            if( !_isDroneOut)
            {
                _selfLight.enabled = true;
                _selfLight.intensity = _selfLightIntensity;
            }
        }
    }
    #endregion

    private Vector2 _playerLookDir; 
    private float _mouseAngle;

    private Light2D _selfLight;
    [SerializeField, Range(0, 20)] private float _selfLightIntensity;
    [SerializeField, Range(0, 30)] private float _selfLightOuterRadius;

    [SerializeField] private GameObject _dronePrefab;
    [SerializeField] private Drone _drone;
    [SerializeField] private bool _isDroneOut;

    private void Awake()
    {
        _selfLight= GetComponentInChildren<Light2D>();
    }

    public void GetMousePosition(InputAction.CallbackContext ctx)
    {
        Vector3 mousePos = ctx.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);

        _playerLookDir = Worldpos - transform.position;

        _mouseAngle = Vector2.SignedAngle(Vector2.right, _playerLookDir);

        transform.eulerAngles = new Vector3(0, 0, _mouseAngle);
    }

    private Vector2 InitLaunch()
    {
        _isDroneOut = true;
        _selfLight.intensity = 0;
        _selfLight.enabled = false;

        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);

        _drone = Instantiate(_dronePrefab, transform.position, transform.rotation).GetComponent<Drone>();
        _drone.GetPlayerAim(this);

        return mouseWorldPos;
    }

    public void LaunchDroneBasic(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(_isDroneOut == false)
            {
                Vector2 mouseWorldPos = InitLaunch();
                _drone.Move(mouseWorldPos, transform.rotation);
            }    
        }
    }

    public void LaunchDroneRapid(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(_isDroneOut == false)
            {
                Vector2 mouseWorldPos = InitLaunch();
                _drone.RapidMove(mouseWorldPos, transform.rotation);
            }
        }
    }
}
