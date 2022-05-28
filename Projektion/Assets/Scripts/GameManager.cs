using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    PlayerControls playerControls;
    public static GameManager instance;
    public GameObject pauseMenu;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.Menu.Pause.performed += i => PauseResume();

        }

        playerControls.Enable();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseResume()
    {
        if (SceneManager.GetActiveScene().name.Equals("Menu"))
            return;

        if (Time.timeScale > 0)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            return;
        }

        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
