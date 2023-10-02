using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private AudioManager _audioManag;
    private void Start()
    {
        _audioManag = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        _audioManag.PlayMusic(_audioManag.Background);
    }
}
