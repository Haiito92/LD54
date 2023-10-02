using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightDetection : MonoBehaviour
{
    private GameObject _collideTarget;
    private GameObject[] _lights;
    private GameObject[] _monsters;

    [SerializeField] private GameObject _monster;
    private float _distance;
    [SerializeField] private float distanceMax;

    [SerializeField] private bool _isPlayerSafe;


    void Start()
    {
        _collideTarget = gameObject;
        _lights = GameObject.FindGameObjectsWithTag("Lights");
    }

    void Update()
    {
        _lights = GameObject.FindGameObjectsWithTag("Lights");
        _monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject light in _lights)
        {
            _distance = Vector2.Distance(_collideTarget.transform.position, light.GetComponent<Light2D>().transform.position);
            if (_distance < light.GetComponent<Light2D>().pointLightOuterRadius)
            {
                _isPlayerSafe = true;
                foreach(GameObject monster in _monsters)
                {
                    Destroy(monster);
                }
                break;
            }
            else
            {
                _isPlayerSafe = false;
                if(_monsters.Length == 0)
                {
                    Debug.Log("_monsters.Length");
                    monsterSpawnLocation(_distance, light);
                }
            }
        }
    }

    void monsterSpawnLocation(float distance, GameObject _target)
    {
        var spawnResult = new Vector2();
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
        Instantiate(_monster, spawnResult, Quaternion.identity);
    }
}
