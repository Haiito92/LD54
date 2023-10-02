using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public bool _isActivated;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _sr;
    


    // Update is called once per frame
    void Update()
    {
        if (_isActivated)
        {
            _sr.enabled = true;
            _rb.simulated = true;
        }
        else
        {
            _sr.enabled = false;
            _rb.simulated = false;
        }
    }
}
