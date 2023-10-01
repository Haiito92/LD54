using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float _speed;
    private Vector2 movement;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    //private void OnMovement (InputValue value)
    //{
    //    movement = value.Get<Vector2> ();
    //}

    public void Movement(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            movement = ctx.ReadValue<Vector2>();
        }else if (ctx.canceled)
        {
            movement = Vector2.zero;
        }
    }

    private void FixedUpdate ()
    {
        rb.AddForce (movement * _speed);
    }


}
