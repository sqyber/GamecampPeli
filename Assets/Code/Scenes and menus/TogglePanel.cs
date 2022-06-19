using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class TogglePanel : MonoBehaviour
    {
        [SerializeField] private GameObject panel;

        // Function to set initialized panel active
        public void OpenPanel()
        {
            panel.SetActive(true);
        }

        // Function to set initialized panel inactive
        public void ClosePanel()
        {
            panel.SetActive(false);
        }
    }
}
