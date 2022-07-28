using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace GamecampPeli
{
    public class HealthBonus : MonoBehaviour
    {
        [SerializeField] private int maxHpBonus = 10;
        [SerializeField] private int currentHpBonus = 1;
        [SerializeField] private int baseCostOfUpgrade = 10;
        [SerializeField] private int bonusMultiplier = 10;

        private TextMeshProUGUI textMesh;
        private ShopCurrencyManager currencyManager;

        private void Awake()
        {
            currentHpBonus = PlayerPrefs.GetInt("HealthBonus", 1);
        }
        
        private void Start ()
        {
            textMesh = gameObject.GetComponent<TextMeshProUGUI>();
            currencyManager = FindObjectOfType<ShopCurrencyManager>();
        }
        private void Update()
        {
            textMesh.text = currentHpBonus + " / " + maxHpBonus;

            Limiter();
        }
        
        //increase the upgrade level
        public void IncreaseValue()
        {
            if (currencyManager.SavedCurrency > baseCostOfUpgrade * currentHpBonus)
            {
                currencyManager.SavedCurrency -= baseCostOfUpgrade * currentHpBonus;
                currentHpBonus++;
            }
            else
            {
                return;
            }
        }
        
        //decrease upgrade level
        public void DecreaseValue()
        {
            if (currentHpBonus > 1)
            {
                currentHpBonus--;
                currencyManager.SavedCurrency += baseCostOfUpgrade * currentHpBonus;
            }
            else
            {
                return;
            }
        }
        
        //limit the upgrade levels to given values
        private void Limiter()
        {
            if (currentHpBonus > maxHpBonus)
            {
                currentHpBonus = maxHpBonus;
            }
            else if (currentHpBonus < 1)
            {
                currentHpBonus = 1;
            }
        }
        public void HealthPrefSave()
        {
            PlayerPrefs.SetInt("HealthBonus", currentHpBonus);
            PlayerPrefs.SetInt("HealthBonusMultiplied", currentHpBonus * bonusMultiplier);
        }
    }
}
