using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public static bool _isOnPlatform;

    public void Die()
    {
        Destroy(gameObject);
    }
}
