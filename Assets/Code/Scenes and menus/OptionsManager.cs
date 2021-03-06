using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamecampPeli
{
    public class OptionsManager : MonoBehaviour
    {
        [SerializeField] private GameObject optionsMenu;
        [SerializeField] private GameObject optionsFirstButton, optionsClosedButton;
        [SerializeField] private GameObject mainMenuButtons;
        [SerializeField] private GameObject upgradeMenu;
        [SerializeField] private GameObject coinsDisplay;

        // Function to open the options menu
        public void OpenOptions()
        {
            if (optionsMenu.activeInHierarchy) return;

            mainMenuButtons.SetActive(false);
            upgradeMenu.SetActive(false);
            coinsDisplay.SetActive(false);
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
            mainMenuButtons.SetActive(true);
            upgradeMenu.SetActive(true);
            coinsDisplay.SetActive(true);

            // Remove the currently selected object for the EventSystem
            EventSystem.current.SetSelectedGameObject(null);
                
            // Set a new selected object for the EventSystem
            EventSystem.current.SetSelectedGameObject(optionsClosedButton);
        }
    }
}
