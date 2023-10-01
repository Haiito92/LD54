using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    private Vector2 _playerLookDir; 
    private float _mouseAngle;


    [SerializeField] private Drone _drone;

    public void GetMousePosition(InputAction.CallbackContext ctx)
    {
        Vector3 mousePos = ctx.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);

        _playerLookDir = Worldpos - transform.position;

        _mouseAngle = Vector2.SignedAngle(Vector2.right, _playerLookDir);

        transform.eulerAngles = new Vector3(0, 0, _mouseAngle);
    }

    public void LaunchDrone(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(_drone.IsDroneOut == false)
            {
                Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
                _drone.Move(mouseWorldPos, transform.rotation);
            }    
        }
    }

    public void LaunchDroneRapid(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if(_drone.IsDroneOut == false)
            {
                Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
                _drone.RapidMove(mouseWorldPos, transform.rotation);
            }
        }
    }
}
