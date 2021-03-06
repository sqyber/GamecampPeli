using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GamecampPeli
{
    public class CurrencyManager : MonoBehaviour
    {
        // Set the currency display text here
        [SerializeField] private TextMeshProUGUI currencyDisplay;
        
        // Int value for the currency
        private int currencyValue;

        // Public read-only property of the currency value and a way to set it
        // on the text display
        public int CurrencyValue
        {
            get { return currencyValue; }
            set
            {
                currencyValue = value;
                currencyDisplay.text = "Coins: " + currencyValue;
            }
        }

        private void Start()
        {
            currencyDisplay.text = "Coins: " + currencyValue;
        }

        // Function used on return to farm buttons to save the currency to playerprefs
        public void SaveCurrency()
        {
            PlayerPrefs.SetInt("Coins", currencyValue);
        }
    }
}
