using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GamecampPeli
{
    public class ProgressManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI progressDisplay;
        [SerializeField] private ProgressBarManager progressBar;

        private int progressValue;

        public int ProgressValue
        {
            get { return progressValue; }
            set
            {
                progressValue = value;
                if (progressValue >= progressBar.MaxProgress)
                {
                    progressDisplay.text = progressBar.MaxProgress + " / " + progressBar.MaxProgress;
                }
                else
                {
                    progressDisplay.text = progressValue + " / " + progressBar.MaxProgress;
                }
            }
        }

        private void Awake()
        {
            progressDisplay.text = progressValue + " / " + progressBar.MaxProgress;
        }

        private void Update()
        {
            progressBar.SetProgress(progressValue);
        }
    }
}
