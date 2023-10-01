using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LoosingZone : MonoBehaviour
{
    [SerializeField, Tag]
    private string _playerTag;
    [SerializeField]
    private HudChange _hudChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            Debug.Log("caca");
            _hudChange.IsLoose = true;
        }
    }
}
