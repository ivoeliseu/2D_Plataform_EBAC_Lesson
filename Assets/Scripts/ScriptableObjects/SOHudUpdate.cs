using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.UIElements;

public class SOHudUpdate : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI hudCoinsAmount;
    [SerializeField] public TextMeshProUGUI hudPlanetsAmount;

    public void UpdateCoins(int value) 
    {
        hudCoinsAmount.text = value.ToString();
    }

    public void UpdatePlanets(int value)
    {
        hudPlanetsAmount.text = value.ToString();
    }

}
