using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace GamecampPeli
{
    public class PauseManager : MonoBehaviour
    {
        [SerializeField] private GameObject pauseMenu;
        private bool paused;

        private PauseAction action;

        private void Awake()
        {
            action = new PauseAction();
        }

        private void Start()
        {
            action.Pause.PauseGame.performed += _ => CheckIfPaused();
        }

        private void OnEnable()
        {
            action.Enable();
        }

        private void OnDisable()
        {
            action.Disable();
        }

        private void CheckIfPaused()
        {
            if (paused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        private void PauseGame()
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            paused = true;
        }

        private void ResumeGame()
        {
            paused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
        }
    }
}
