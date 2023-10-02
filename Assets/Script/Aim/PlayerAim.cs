using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
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
                StopCoroutine(_lightGoingOff);
                _selfLight.gameObject.tag = _selfLightTag;
                _selfLight.intensity = _selfLightIntensity;
                _anim.SetBool("IsDroneOut", _isDroneOut);
            }
            else
            {
                _anim.SetBool("IsDroneOut", _isDroneOut);
            }
        }
    }

    public bool CanCallbackDrone
    {
        get { return _canCallbackDrone; }
        set { _canCallbackDrone = value; }
    }
    #endregion

    #region IEnumeratorHolders
    private IEnumerator _lightGoingOff;
    #endregion

    private Vector2 _playerLookDir; 
    private float _mouseAngle;

    private Light2D _selfLight;
    [SerializeField, Tag] private string _selfLightTag;
    [SerializeField, Range(0, 20)] private float _selfLightIntensity;
    [SerializeField, Range(0, 30)] private float _selfLightOuterRadius;
    [SerializeField] private float _intensityLoss;
    [SerializeField] private float _lossRate;

    [SerializeField] private GameObject _dronePrefab;
    [SerializeField] private Drone _drone;
    [SerializeField] private bool _isDroneOut;
    private bool _canCallbackDrone;

    [SerializeField] private int _maxNumberOfFlash;
    [SerializeField] private int _numberOfFlash;

    [SerializeField] private Animator _anim;

    private void Awake()
    {
        _numberOfFlash = _maxNumberOfFlash;
        _selfLight= GetComponentInChildren<Light2D>();
        _anim = GetComponent<Animator>();
    }

    #region EditorMethods
    //private bool ValidateSelfLightIntensity(float selfLightIntensity)
    //{
    //    _selfLight.intensity= _selfLightIntensity;
    //    return true;
    //}
    #endregion

    public void GetMousePosition(InputAction.CallbackContext ctx)
    {
        Vector3 mousePos = ctx.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);

        _playerLookDir = Worldpos - transform.position;

        _mouseAngle = Vector2.SignedAngle(Vector2.up, _playerLookDir);

        transform.eulerAngles = new Vector3(0, 0, _mouseAngle);
    }

    private Vector2 InitLaunch()
    {
        IsDroneOut = true;

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
                StartLightGoingOff();
                _drone.Move(mouseWorldPos, transform.rotation);
            }    
        }
    }

    public void LaunchDroneRapid(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(_isDroneOut == false && _numberOfFlash > 0)
            {
                Vector2 mouseWorldPos = InitLaunch();
                StartLightGoingOff();
                _drone.RapidMove(mouseWorldPos, transform.rotation);
                _numberOfFlash -= 1;
            }
        }
    }

    public void CallBackDrone(InputAction.CallbackContext ctx)
    {
        if(ctx.started && _canCallbackDrone)
        {
            _drone.DestroyDrone();
            _canCallbackDrone = false;
        }
    }

    private void StartLightGoingOff()
    {
        _lightGoingOff = LightGoingOff();
        StartCoroutine(_lightGoingOff);
    }

    private IEnumerator LightGoingOff()
    {
        while (_selfLight.intensity >= _intensityLoss)
        {
            yield return new WaitForSeconds(1 / _lossRate);
            _selfLight.intensity = Mathf.Clamp(_selfLight.intensity -= _intensityLoss, 0, float.MaxValue);
        }
        _selfLight.intensity = 0;
        _selfLight.gameObject.tag = "Untagged";
        StopLightGoingOff();
    }

    private void StopLightGoingOff()
    {
        StopCoroutine(_lightGoingOff);
    }
}
