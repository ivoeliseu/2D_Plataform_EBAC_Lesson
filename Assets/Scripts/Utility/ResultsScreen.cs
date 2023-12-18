using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultsScreen : MonoBehaviour
{
    public string resultsCoin;
    public string resultsPlanet;
    public SOHudUpdate values;
    public TextMeshProUGUI coins;
    public TextMeshProUGUI planets;

    private void Update()
    {
        resultsCoin = values.hudCoinsAmount.text;
        resultsPlanet = values.hudPlanetsAmount.text;

        coins.text = resultsCoin;
        planets.text = resultsPlanet;
    }
}
