using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBehaviour : MonoBehaviour
{
    [SerializeField] Transform _target;
    private Rigidbody2D _rb;
    private Vector2 direction;
    [SerializeField] float moveSpeed;

    [SerializeField] private PlayerDie _playerDie;

    private void Start()
    {
        _rb = this.GetComponent<Rigidbody2D>();
        _target = GameObject.Find("Player").GetComponent<Transform>();
        _playerDie = GameObject.Find("Player").GetComponent<PlayerDie>(); 
    }
    void Update()
    {
        direction = _target.position - transform.position;
        transform.rotation = Quaternion.FromToRotation(Vector3.right,direction);
        direction.Normalize();
    }
    private void FixedUpdate()
    {
        MoveMonster(direction);
    }
    private void MoveMonster(Vector3 direction)
    {
        transform.position += (direction * moveSpeed * Time.deltaTime);
        Vector3 temp = transform.position;
        temp.z = -1.0f;
        _rb.MovePosition(temp);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("==========ur dead===========");
            _playerDie.Die();
            Destroy(gameObject);
        }
    }
}
