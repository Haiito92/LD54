using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Properties

    public float XSpeed { get => _xSpeed; set => _xSpeed = value; }
    public float YSpeed { get => _ySpeed; set => _ySpeed = value; }
    #endregion


    [SerializeField] private float _xSpeed;
    [SerializeField] private float _ySpeed;
    private Vector2 _movementVector;
    public Vector2 MovementVector
    {
        get { return _movementVector; }
        set 
        { 
            _movementVector = value;
        }
    }



    private Rigidbody2D _rb;

    [SerializeField] private Transform _legs;
    [SerializeField] private Animator _legsAnimator;
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
            MovementVector = ctx.ReadValue<Vector2>();
        }else if (ctx.canceled)
        {
            MovementVector = Vector2.zero;
            _rb.velocity = Vector2.zero;
        }
    }

    private void FixedUpdate ()
    {
        Vector2 movementForce = new Vector2( MovementVector.x * _xSpeed * Time.fixedDeltaTime, MovementVector.y * _ySpeed * Time.fixedDeltaTime);
        if(MovementVector != Vector2.zero)
        {
            //_rb.AddForce(movementForce);
            _rb.velocity = movementForce;
        }
        _legsAnimator.SetFloat("Speed", movementForce.magnitude);
    }

}
