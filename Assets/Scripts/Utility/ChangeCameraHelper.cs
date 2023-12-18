using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraHelper : MonoBehaviour
{
    public GameObject actualCamera;
    public GameObject nextCamera;
    public HudActivatorHelper hud;

    private void Awake()
    {
        Invoke(nameof(ChangeCamera), 0.5f);
        hud.HudActivation();
    }

    public void ChangeCamera()
    {
        actualCamera.gameObject.SetActive(false);
        nextCamera.gameObject.SetActive(true);
    }
}
