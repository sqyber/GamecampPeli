using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GamecampPeli
{
    public class MainmenuOptions : MonoBehaviour
    {
        [SerializeField] private GameObject buttons;
        [SerializeField] private GameObject options;

        public void openOptions()
        {
            buttons.SetActive(false);
            options.SetActive(true);
        }

        public void closeOptions()
        {
            options.SetActive(false);
            buttons.SetActive(true);
        }
    }
}
