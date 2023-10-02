using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MathTEst : MonoBehaviour
{
    public float distance;
    [SerializeField] private float distanceMax;
    public GameObject _target;
    public GameObject _target2;
    public Vector3 spawnResult;
    public bool test;

    void Update()
    {
        if (test)
        {
            calculSpawn();
            test = false;
        }
    }

    void calculSpawn()
    {
        distance = Vector2.Distance(_target.transform.position, transform.position);
        spawnResult.x = 2*transform.position.x - _target.transform.position.x;
        spawnResult.y = 2* transform.position.y - _target.transform.position.y;
        spawnResult = new Vector3(spawnResult.x, spawnResult.y, -1);
        if (distance < distanceMax)
        {
            if(spawnResult.x < 0)
            {
                spawnResult.x += -distanceMax;
            } else
            {
                spawnResult.x += distanceMax;
            }
            if (spawnResult.y < 0)
            {
                spawnResult.y += -distanceMax;
            } else
            {
                spawnResult.y += distanceMax;
            }
        }
        _target2.transform.position = spawnResult;

    }

}
