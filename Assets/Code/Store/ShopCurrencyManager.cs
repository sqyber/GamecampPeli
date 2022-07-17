using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GamecampPeli
{
    public class ShopCurrencyManager : MonoBehaviour
    {
        // Set the currency display text here
        [SerializeField] private TextMeshProUGUI currencyDisplay;

        // Int where the saved currency amount is loaded
        private int savedCurrency;
        
        // Public read-only property of the currency value and a way to set it
        // on the text display
        public int SavedCurrency
        {
            get { return savedCurrency; }
            set
            {
                savedCurrency = value;
                currencyDisplay.text = "Coins: " + savedCurrency;
            }
        }

        // Load the saved currency on awake
        private void Awake()
        {
            savedCurrency = PlayerPrefs.GetInt("Coins", 0);
        }
        
        private void Start()
        {
            currencyDisplay.text = "Coins: " + savedCurrency;
        }

        // Function used on return to farm buttons to save the currency to playerprefs
        public void SaveCurrency()
        {
            PlayerPrefs.SetInt("Coins", savedCurrency);
        }
    }
}
