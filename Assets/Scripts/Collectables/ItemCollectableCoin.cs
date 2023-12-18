using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public int coinValue = 1;
    protected override void Collect()
    {
        base.Collect();
        ItemManager.Instance.AddCoins(coinValue);
        //Debug.Log("Coletou moeda");
    }
}
