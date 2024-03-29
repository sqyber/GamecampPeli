using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GamecampPeli
{
    public class BossDeathManager : MonoBehaviour
    {
        // The win menu
        [SerializeField] private GameObject winMenu;
        
        // The win menu button
        [SerializeField] private GameObject winMenuButton;
        
        // Music start manager
        [SerializeField] private GameObject musicStartManager;

        private AudioManager audioManager;

        private void Start()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        
        // On the destroy of object, open win menu and set timescale to 0
        private void OnDestroy()
        {
            Time.timeScale = 0f;

            audioManager.StopPlayingSong(musicStartManager.GetComponent<MusicStartManager>().Song);
            audioManager.PlaySfx("WinJingle");

            winMenu.SetActive(true);
            
            // Remove the currently selected object from the EventSystem
            EventSystem.current.SetSelectedGameObject(null);
            
            // Set a new selected object for the EventSystem
            EventSystem.current.SetSelectedGameObject(winMenuButton);
        }
    }
}
