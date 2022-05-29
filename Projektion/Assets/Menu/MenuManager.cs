using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MenuManager : MonoBehaviour
{
    public GameObject Main;
    public GameObject playButton;

    public GameObject Levels;
    public GameObject Level1Button;



    private PlayerControls playerControls;

    private void OnEnable()
    {
        if (playerControls == null)
        {
            playerControls = new PlayerControls();
            playerControls.PlayerActions.Jumping.performed += i => Valid();
            playerControls.PlayerActions.Cancel.performed += i => Back();
            playerControls.Menu.Pause.performed += i => Back();

        }

        playerControls.Enable();
    }

    void Update()
    {

        if (playerControls.PlayerMovement.Movement.ReadValue<Vector2>().magnitude > 0 && EventSystem.current.currentSelectedGameObject == null)
        {
            if (Main.activeSelf)
                EventSystem.current.SetSelectedGameObject(playButton);
            if (Levels.activeSelf)
                EventSystem.current.SetSelectedGameObject(Level1Button);
        }
    }

    private void Valid()
    {
        EventSystem.current.currentSelectedGameObject.GetComponent<Button>().onClick.Invoke();
        EventSystem.current.SetSelectedGameObject(null);
    }

    void Back()
    {
        if (Main.activeSelf)
            return;
        Main.SetActive(true);
        Levels.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
    }

    private void OnDestroy()
    {
        playerControls.Disable();
    }

}
