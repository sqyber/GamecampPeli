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
                progressDisplay.text = progressValue.ToString();
            }
        }

        private void Update()
        {
            progressBar.SetProgress(progressValue);
        }
    }
}
