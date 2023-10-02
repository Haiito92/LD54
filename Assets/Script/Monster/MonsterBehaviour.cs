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

    private AudioManager _audioManag;

    public bool _audioSwitch = true;

    private void Start()
    {
        _audioManag = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _rb = this.GetComponent<Rigidbody2D>();
        _target = GameObject.Find("Player").GetComponent<Transform>();
        _playerDie = GameObject.Find("Player").GetComponent<PlayerDie>();
        _audioSwitch = true;
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

    public void SoundPlay()
    {
        _audioManag.PlaySFX(_audioManag.MonsterMove);
    }

    public void SoundPlayMain()
    {
        if (_audioSwitch)
        {
            _audioManag.PlaySFX(_audioManag.Monster);
            Debug.Log("Why");
            _audioSwitch = false;
            StartCoroutine(AudioSwitchBehaviour());

        }
    }

    IEnumerator AudioSwitchBehaviour()
    {
        yield return new WaitForSeconds(2.0f);
        Debug.Log("No");
        _audioSwitch = true;
    }
}
