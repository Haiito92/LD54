using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] Transform _target;
    private Rigidbody2D _rb;
    private Vector2 direction;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        direction = _target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, direction);
        direction.Normalize();
    }
    private void FixedUpdate()
    {
        MoveMonster(direction);
    }
    private void MoveMonster(Vector2 direction)
    {
        _rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("==========ur dead===========");
            Destroy(gameObject);
        }
    }
}
