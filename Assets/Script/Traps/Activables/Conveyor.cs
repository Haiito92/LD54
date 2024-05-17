using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : Activable
{
    [SerializeField] private GameObject _conveyorActive;
    [SerializeField] private GameObject _conveyorUnactive;

    public override void Activate()
    {
        base.Activate();

        _conveyorActive.SetActive(false);
        _conveyorUnactive.SetActive(true);
    }
}
