using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectablePlanet : ItemCollectableBase
{
    public int planetValue;

    protected override void OnCollect()
    {
        base.OnCollect();
        ItemManager.Instance.AddPlanets(planetValue);
    }
}
