using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HudManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI hudCoinsAmount;

    public void UpdateCoins(int value) 
    {
        hudCoinsAmount.text = value.ToString();
    }
    
}
