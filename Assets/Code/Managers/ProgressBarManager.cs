using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamecampPeli
{
    public class ProgressBarManager : MonoBehaviour
    {
        // Set the maximum progress and the display slider for the progress here
        [SerializeField] public Slider slider;
        [SerializeField] private int maxProgress = 1000;

        public int MaxProgress
        {
            get { return maxProgress; }
        }

        // Initialize the slider with the maximum value set above and set the current
        // slider value to 0
        private void Awake()
        {
            slider.maxValue = maxProgress;
            slider.value = 0;
        }

        // Function to update the sliders progress value
        public void SetProgress(int progress)
        {
            slider.value = progress;
        }
    }
}
