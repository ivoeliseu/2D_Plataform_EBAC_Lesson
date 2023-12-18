using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameActivation : MonoBehaviour
{
    public string tagToCompare = "Player";
    public GameObject endGameScreen;


    // Essa função detecta o trigger para chamar a função EndGame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            EndGame();
            
        }
    }

    //Essa função o atual gameplay, ativando a tela de resultados.
    public void EndGame()
    {
        endGameScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
