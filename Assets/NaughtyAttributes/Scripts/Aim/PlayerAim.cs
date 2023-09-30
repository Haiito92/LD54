using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    Vector2 _playerLookDir; 
    float _mouseAngle;

    public void GetMousePosition(InputAction.CallbackContext ctx)
    {
        Vector3 mousePos = ctx.ReadValue<Vector2>();
        mousePos.z = Camera.main.nearClipPlane;
        Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
        Debug.Log("WorldposCTX = " + Worldpos);

        _playerLookDir = Worldpos - transform.position;

        _mouseAngle = Vector2.SignedAngle(Vector2.right, _playerLookDir);

        transform.eulerAngles = new Vector3(0, 0, _mouseAngle);
    }
}
