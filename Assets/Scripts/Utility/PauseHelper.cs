using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHelper : MonoBehaviour
{
    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void UnPause()
    {
        Time.timeScale = 1f;
    }
}
