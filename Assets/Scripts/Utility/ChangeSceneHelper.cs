using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneHelper : MonoBehaviour
{
    public string sceneToChange;

    public void OpenScene()
    {
        SceneManager.LoadScene(sceneToChange);
    }
}
