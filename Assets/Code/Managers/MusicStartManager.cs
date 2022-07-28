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

        [SerializeField] private string[] songs;
        private string song;

        public string Song
        {
            get { return song; }
        }

        private void Awake()
        {
            audioManager = FindObjectOfType<AudioManager>();
        }
        
        private void Start()
        {
            int songNumber = Random.Range(0, 4);

            song = songs[songNumber];

            audioManager.PlaySong(song);
        }

        public void StopPlayingSong()
        {
            audioManager.StopPlayingSong(song);
        }
    }
}
