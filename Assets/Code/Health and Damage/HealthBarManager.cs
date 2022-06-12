using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamecampPeli
{
    public class HealthBarManager : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        // Public function to set the max value of the HP bar slider
        public void SetMaxHealth(int health)
        {
            slider.maxValue = health;
            slider.value = health;
        }
        
        // Public function to update the HP bar slider with the players current health
        public void SetHealth(int health)
        {
            slider.value = health;
        }
    }
}
