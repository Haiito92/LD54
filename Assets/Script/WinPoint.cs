using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPoint : MonoBehaviour
{
    [SerializeField] private HudChange _hudChange; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hudChange.IsWin = true;
    }
}
