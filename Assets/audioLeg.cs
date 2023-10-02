using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audioLeg : MonoBehaviour
{

    private AudioManager _audioManag;
    void Start()
    {
        _audioManag = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void SoundPlay()
    {
        _audioManag.PlaySFX(_audioManag.Step);
    }

}
