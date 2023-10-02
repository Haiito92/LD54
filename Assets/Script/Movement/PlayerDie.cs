using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public bool _isInLight = true;
    private float counter = 0;
    [SerializeField] private float maxTime;

    private void Update()
    {
        while (_isInLight == false)
        {
            counter += Time.deltaTime;
            if(counter > maxTime)
            {
                Die();
            }
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }



}
