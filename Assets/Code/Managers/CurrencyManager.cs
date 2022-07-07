using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GamecampPeli
{
    public class CurrencyManager : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI currencyDisplay;
        private int currencyValue;

        public int CurrencyValue
        {
            get { return currencyValue; }
            set
            {
                currencyValue = value;
                currencyDisplay.text = currencyValue.ToString();
            }
        }
    }
}
