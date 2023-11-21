using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt coins;
    public SOInt planets;
    public string compareTag = "Coins";
    public SOHudUpdate hudManager;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        planets.value = 0;
    }

    public void AddCoins(int value)
    {
        coins.value += value;
        hudManager.UpdateCoins(coins.value);
    }

    public void AddPlanets(int value)
    {
        planets.value += value;
        hudManager.UpdatePlanets(planets.value);
    }

}
