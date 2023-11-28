using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectablePlanet : ItemCollectableBase
{
    public int planetValue;

    protected override void Collect()
    {
        base.Collect();
        ItemManager.Instance.AddPlanets(planetValue);
    }
}
