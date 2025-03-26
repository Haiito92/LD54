using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Activable
{
    public override void Activate()
    {
        base.Activate();
        Destroy(gameObject);
    }
}
