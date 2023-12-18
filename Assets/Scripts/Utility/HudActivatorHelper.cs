using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudActivatorHelper : MonoBehaviour
{
    public GameObject hud;
    public float fadeSpeed = 0.1f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            HudActivation();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            HudDesactivation();
        }
    }
    public void HudActivation()
    {
        hud.gameObject.SetActive(true);
    }

    public void HudDesactivation()
    {
        hud.gameObject.SetActive(false);
    }
}
