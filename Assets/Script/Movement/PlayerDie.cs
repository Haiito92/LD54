using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public bool _isInLight = true;
    private float counter = 0;
    [SerializeField] private float maxTime;

    public float distance;
    [SerializeField] private float distanceMax;
    public GameObject _target;
    public GameObject _target2;
    public Vector3 spawnResult;

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


    void monsterSpawnLocation()
    {
        distance = Vector2.Distance(_target.transform.position, transform.position);
        spawnResult.x = 2 * transform.position.x - _target.transform.position.x;
        spawnResult.y = 2 * transform.position.y - _target.transform.position.y;
        spawnResult = new Vector3(spawnResult.x, spawnResult.y, -1);
        if (distance < distanceMax)
        {
            if (spawnResult.x < 0)
            {
                spawnResult.x += -distanceMax;
            }
            else
            {
                spawnResult.x += distanceMax;
            }
            if (spawnResult.y < 0)
            {
                spawnResult.y += -distanceMax;
            }
            else
            {
                spawnResult.y += distanceMax;
            }
        }
        _target2.transform.position = spawnResult;
    }
}
