using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float _speed;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }
    private Vector2 _movement;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    //private void OnMovement (InputValue value)
    //{
    //    movement = value.Get<Vector2> ();
    //}

    public void Movement(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            _movement = ctx.ReadValue<Vector2>();
        }else if (ctx.canceled)
        {
            _movement = Vector2.zero;
        }
    }

    private void FixedUpdate ()
    {
        _rb.AddForce (_movement * _speed);
    }


}
