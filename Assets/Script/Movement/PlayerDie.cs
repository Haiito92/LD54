using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    [SerializeField] private GameObject _actualCheckpoint;
    [SerializeField] private GameObject _previousCheckpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Checkpoint")
        {
            if(_actualCheckpoint != null)
            {
                _previousCheckpoint = _actualCheckpoint;
                _previousCheckpoint.SetActive(true);
            }
            _actualCheckpoint = collision.gameObject;
            collision.gameObject.SetActive(false);
        }
    }

    public void Die()
    {
        transform.position = _actualCheckpoint.transform.position;
    }
}
