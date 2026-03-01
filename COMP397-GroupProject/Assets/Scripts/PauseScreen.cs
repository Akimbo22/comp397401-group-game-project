using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


// LOOK HERE BEFORE ADDING!!!
// Attach this script to the player
// Use the prefab "PauseScreen" in the prefabs folder
// Place the prefab into an existing Canvas
// Make sure the scene also has an EventSystem

public class PauseScreen : MonoBehaviour
{
    private InputAction openMenu;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private bool isMenuOpen = false;

    void Start()
    {
        openMenu = InputSystem.actions.FindAction("UI/Menu");
        openMenu.started += ToggleMenu;
        menuPanel.SetActive(false);
    }

    private void OnDisable()
    {
        openMenu.started -= ToggleMenu;
    }

    private void ToggleMenu(InputAction.CallbackContext context)
    {
        isMenuOpen = !isMenuOpen;
        if (isMenuOpen)
        {
            menuPanel.SetActive(true);
            Time.timeScale = 0f; // Pause time so enemies can't attack while paused
            InputSystem.actions.FindActionMap("Player").Disable();
        }
        else
        {
            menuPanel.SetActive(false);
            Time.timeScale = 1f;
            InputSystem.actions.FindActionMap("Player").Enable();
        }
    }
}
