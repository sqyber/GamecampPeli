using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

namespace GamecampPeli
{
    [System.Serializable]
    public class Sound
    {
        // Name for the sound / audio clip
        public string name;
        
        // The audio clip
        public AudioClip clip;

        // Volume for the sound
        [Range(0f, 1f)]public float volume;

        public bool loop;

        [HideInInspector]public AudioSource source;
    }
}
