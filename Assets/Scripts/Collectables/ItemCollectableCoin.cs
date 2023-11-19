using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableCoin : ItemCollectableBase
{
    public int coinValue = 1;
    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddCoins(coinValue);
    }
}
