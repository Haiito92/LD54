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
    public bool IsWin
    {
        get { return _isWin; }
        set { _isWin = value; }
    }
    [SerializeField] private bool _isLoosed = false;
    [SerializeField] private GameObject _looseScene = null;
    public bool IsLoose
    {
        get { return _isLoosed; }
        set { _isLoosed = value; }
    }
    [SerializeField] private bool _isHudOn = false;
    [SerializeField] private GameObject _Hud = null;
    [SerializeField] private bool _isSetting = false;
    [SerializeField] private GameObject _settingScene = null;
    [SerializeField] private string _sceneName;

    // Start is called before the first frame update
    void Start()
    {
        this._pauseScene.SetActive(false);
        this._startScene.SetActive(true); 
        this._winScene.SetActive(false);
        this._looseScene.SetActive(false);
        this._Hud.SetActive(false);
        Time.timeScale = 0f;
        _isStart = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isStart == false && _isLoosed == false && _isWin == false)
        {

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

        if (_isStart == false && _isLoosed == false && _isWin == false && _isPaused == false)
        {
            this._Hud.SetActive(true);
            _isHudOn = true;
        } else
        {
            this._Hud.SetActive(false);
            _isHudOn = false;
        }

        if (_isLoosed == true)
        {
            Debug.Log("xcaca");
            this._looseScene.SetActive(true);
            Time.timeScale = 0f;
        }

        if (_isWin == true)
        {
            this._winScene.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void StartGame() 
    {
        this._startScene.SetActive(false);
        _isStart = false;
        Time.timeScale = 1f;
    }

    public void ResetCurrentScene()
    {
        // Debug.Log("reset");
        SceneManager.LoadScene(this._sceneName);
        this._winScene.SetActive(false);
        this._looseScene.SetActive(false);
        _isLoosed = false;
        _isWin = false;
    }

    public void GoSetting()
    {
        this._startScene.SetActive(false);
        this._pauseScene.SetActive(false);
        this._settingScene.SetActive(true);
        _isSetting = true;
    }

    public void returnOldMenu()
    {
        if (_isPaused == true) 
        {
            this._pauseScene.SetActive(true);
            this._settingScene.SetActive(false);
            _isSetting = true;
        } else if (_isStart == true)
        {
            this._startScene.SetActive(true);
            this._settingScene.SetActive(false);
            _isSetting = false;
        } else {
            this._settingScene.SetActive(false);
            _isSetting = false;
        }
    }

    public void ApplicationQuit()
    {
        Application.Quit();
    }
}
