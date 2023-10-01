using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudChange : MonoBehaviour
{
    [SerializeField] private bool _isPaused = false;
    [SerializeField] private GameObject _pauseScene = null;
    [SerializeField] private bool _isStart = false;
    [SerializeField] private GameObject _startScene = null;
    [SerializeField] private bool _isWin = false;
    [SerializeField] private GameObject _winScene = null;
    [SerializeField] private bool _isLoosed = false;
    [SerializeField] private GameObject _looseScene = null;
    [SerializeField] private string _sceneName;
    [SerializeField] private GameObject _Hud = null;
    [SerializeField] private bool _isHudOn = false;

    // Start is called before the first frame update
    void Start()
    {
        this._pauseScene.SetActive(false);
        this._startScene.SetActive(false);
        this._winScene.SetActive(false);
        this._looseScene.SetActive(false);
        _isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart == false && _isLoosed == false && _isWin == false) { 

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                if (this._isPaused)
                {
                    // Debug.Log("pas pause");
                    Time.timeScale = 1f;
                    this._pauseScene.SetActive(false);
                    this._isPaused = false;

                }
                else
                {
                    // Debug.Log("pause");
                    Time.timeScale = 0f;
                    this._pauseScene.SetActive(true);
                    this._isPaused = true;

                }
            }
    }
    }

    public void ResetCurrentScene()
    {
        Debug.Log("reset");
        SceneManager.LoadScene(this._sceneName);
        this._startScene.SetActive(false);
        this._winScene.SetActive(false);
        this._looseScene.SetActive(false);
        _isStart = false;
        _isLoosed = false;
        _isWin = false;
    }
}
