using UnityEngine;

public class Drone : MonoBehaviour
{
    [SerializeField] private float _speed;

    [SerializeField] private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void MoveDrone(Vector2 targetPos)
    {
        Vector2 direction = targetPos - _rb.position;
        direction.Normalize();
        _rb.AddForce(direction * _speed);
    }
}
