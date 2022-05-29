using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{

    PlayerControls playerControls;
    public static GameManager instance;
    public GameObject pauseMenu;
    private bool inPause;
    public GameObject resumeButton;

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
            playerControls.PlayerMovement.Movement.performed += i => MoveInPauseMenu();

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
            inPause = true;
            return;
        }
        inPause = false;
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);

    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void FinishGame()
    {
        
    }

    public async void NextLevel()
    {
        int index = SceneManager.GetActiveScene().buildIndex + 1;
        if (index >= SceneManager.sceneCountInBuildSettings)
        {
            FinishGame();
            return;
        }

        FindObjectOfType<AudioManager>().Play("win");
        await Task.Delay(2000);
        SceneManager.LoadScene(index);
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level2");
    }

    public void Level2()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void MoveInPauseMenu()
    {
        if(inPause)
        {
            if (playerControls.PlayerMovement.Movement.ReadValue<Vector2>().magnitude > 0 && EventSystem.current.currentSelectedGameObject == null)
            {
                EventSystem.current.SetSelectedGameObject(resumeButton);
            }
        }
    }
}
