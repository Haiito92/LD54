using NaughtyAttributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningZone : MonoBehaviour
{
    [SerializeField, Tag]
    private string _playerTag;
    [SerializeField]
    private HudChange _hudChange;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _playerTag)
        {
            _hudChange.IsWin = true;
        }
    }
}
