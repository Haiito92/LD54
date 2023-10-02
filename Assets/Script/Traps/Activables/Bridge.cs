using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : Activable
{
    //public bool _isActivated;
    [SerializeField] private GameObject _bridge;
    [SerializeField] private GameObject _bridgeVoid;

    public override void Activate()
    {
        base.Activate();

        _bridgeVoid.SetActive(false);
        _bridge.SetActive(true);
    }
}
