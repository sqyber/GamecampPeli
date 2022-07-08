using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace GamecampPeli
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu, optionsMenu, deathMenu;
        [SerializeField] private GameObject pauseFirstButton, optionsFirstButton, optionsClosedButton;

        private PauseAction action;

        private void Awake()
        {
            action = new PauseAction();
        }

        private void Start()
        {
            action.Pause.PauseGame.performed += _ => PauseUnpause();
        }

        private void OnEnable()
        {
            action.Enable();
        }

        private void OnDisable()
        {
            action.Disable();
        }

        // Function to pause and unpause the game with a check for the options menu
        // so that the player can't open the pause menu while the options menu is
        // open, also the game won't unpause if the options are open.
        public void PauseUnpause()
        {
            if (deathMenu.activeInHierarchy)
            {
                Time.timeScale = 1f;
                return;
            }
            
            if (optionsMenu.activeInHierarchy) return;
            
            if (!pauseMenu.activeInHierarchy)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0f;
                
                // Remove the currently selected object for the EventSystem
                EventSystem.current.SetSelectedGameObject(null);
                
                // Set a new selected object for the EventSystem
                EventSystem.current.SetSelectedGameObject(pauseFirstButton);
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }

        // Function to open the options menu
        public void OpenOptions()
        {
            if (optionsMenu.activeInHierarchy) return;
            
            pauseMenu.SetActive(false);
            optionsMenu.SetActive(true);
                
            // Remove the currently selected object for the EventSystem
            EventSystem.current.SetSelectedGameObject(null);
                
            // Set a new selected object for the EventSystem
            EventSystem.current.SetSelectedGameObject(optionsFirstButton);
        }

        // Function to close the options menu
        public void CloseOptions()
        {
            if (!optionsMenu.activeInHierarchy) return;
            
            optionsMenu.SetActive(false);
            pauseMenu.SetActive(true);
                
            // Remove the currently selected object for the EventSystem
            EventSystem.current.SetSelectedGameObject(null);
                
            // Set a new selected object for the EventSystem
            EventSystem.current.SetSelectedGameObject(optionsClosedButton);
        }
    }
}
