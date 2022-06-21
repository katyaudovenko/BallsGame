using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace View.UIViews
{
    public class ProductView : MonoBehaviour
    {
        [SerializeField] private Button buyButton; 
        [SerializeField] private TextMeshProUGUI nameText; 
        [SerializeField] private TextMeshProUGUI priceText;
        
        public void SetupView(string productName, string price, Action onButtonClick)
        {
            nameText.text = productName;
            priceText.text = price;
            buyButton.onClick.RemoveAllListeners();
            buyButton.onClick.AddListener(() => onButtonClick?.Invoke());
        }
    }
}