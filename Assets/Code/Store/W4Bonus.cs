using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace GamecampPeli
{
    public class W4Bonus : MonoBehaviour
    {
        [SerializeField] private int maxDmgBonus = 10;
        [SerializeField] private int currentDmgBonus = 1;
        [SerializeField] private int baseCostOfUpgrade = 10;
        
        private TextMeshProUGUI textMesh;
        private ShopCurrencyManager currencyManager;

        private void Awake()
        {
            currentDmgBonus = PlayerPrefs.GetInt("W4Bonus", 1);
        }
        
        private void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
            currencyManager = FindObjectOfType<ShopCurrencyManager>();
        }

        private void Update()
        {
            textMesh.text = currentDmgBonus + " / " + maxDmgBonus;
            Limiter();
        }
        

        public void IncreaseValue()
        {
            if (currencyManager.SavedCurrency > baseCostOfUpgrade * currentDmgBonus)
            {
                currencyManager.SavedCurrency -= baseCostOfUpgrade * currentDmgBonus;
                currentDmgBonus++;
            }
            else
            {
                return;
            }
                
        }
        
        //decrease upgrade level
        public void DecreaseValue()
        {
            if (currentDmgBonus > 1)
            {
                currentDmgBonus--;
                currencyManager.SavedCurrency += baseCostOfUpgrade * currentDmgBonus;
            }
            else
            {
                return;
            }
                
        }

        private void Limiter()
        {
            if (currentDmgBonus > maxDmgBonus)
            {
                currentDmgBonus = maxDmgBonus;
            }
            else if (currentDmgBonus < 1)
            {
                currentDmgBonus = 1;
            }
        }
        public void W4PrefSave()
        {
            PlayerPrefs.SetInt("W4Bonus", currentDmgBonus);
        }
    }
}
