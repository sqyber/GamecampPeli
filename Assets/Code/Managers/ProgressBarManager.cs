using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GamecampPeli
{
    public class ProgressBarManager : MonoBehaviour
    {
        [SerializeField] private Slider slider;
        [SerializeField] private int maxProgress = 1000;

        private void Awake()
        {
            slider.maxValue = maxProgress;
            slider.value = 0;
        }

        public void SetProgress(int progress)
        {
            slider.value = progress;
        }
    }
}
