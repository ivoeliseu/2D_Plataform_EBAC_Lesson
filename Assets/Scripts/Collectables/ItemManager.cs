using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    public int coins;
    public string compareTag = "Coins";
    public HudManager hudManager;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
    }

    public void AddCoins()
    {
        coins++;
        hudManager.UpdateCoins(coins);
    }

}
