using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace GamecampPeli
{
    public class MusicStartManager : MonoBehaviour
    {
        private AudioManager audioManager;

        [SerializeField] private String[] songs;

        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        
        private void Start()
        {
            int songNumber = Random.Range(0, 4);

            string song = songs[songNumber];

            audioManager.PlaySong(song);
        }
    }
}
