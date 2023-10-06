using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private AudioManager _audioManag;

    private static GameManager _instance;
    public static GameManager Instance => _instance;

    private void Awake()
    {
        if(_instance !=null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _audioManag = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _audioManag.PlayMusic(_audioManag.Background);
    }
}
