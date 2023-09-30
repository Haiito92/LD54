using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{

    [SerializeField] float _speed;
    private Vector2 movement;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnMovement (InputValue value)
    {
        movement = value.Get<Vector2> ();
    }

    private void FixedUpdate ()
    {
        rb.AddForce (movement * _speed);
    }


}
