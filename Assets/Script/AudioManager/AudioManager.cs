using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioSource _musicSources;
    [SerializeField] private AudioSource _SFXSources;

    [Header ("AudioClip ---------------------------------") ]
    [SerializeField] private AudioClip _background;
    public AudioClip Background
    {
        get { return _background; }
        set { _background = value; }
    }

    [SerializeField] private AudioClip _musicMenu;
    public AudioClip MusicMenu
    {
        get { return _musicMenu; }
        set { _musicMenu = value; }
    }

    [SerializeField] private AudioClip _step;
    public AudioClip Step
    {
        get { return _step; }
        set { _step = value; }
    }

    [SerializeField] private AudioClip _droneIdle;
    public AudioClip DroneIdle
    {
        get { return _droneIdle; }
        set { _droneIdle = value; }
    }
    [SerializeField] private AudioClip _droneMove;
    public AudioClip DroneMove
    {
        get { return _droneMove; }
        set { _droneMove = value; }
    }
    [SerializeField] private AudioClip _monster;
    public AudioClip Monster
    {
        get { return _monster; }
        set { _monster = value; }
    }
    [SerializeField] private AudioClip _monsterMove;
    public AudioClip MonsterMove
    {
        get { return _monsterMove; }
        set { _monsterMove = value; }
    }

    void Start()
    {
        //_musicSources.clip = _background;
        //_musicSources.Play();
    }
    public void PlaySFX(AudioClip clip)
    { 
        _SFXSources.PlayOneShot(clip);
    }
    public void PlayMusic(AudioClip clip)
    {
        _musicSources.PlayOneShot(clip);
    }

}
