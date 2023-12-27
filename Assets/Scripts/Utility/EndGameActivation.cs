using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameActivation : MonoBehaviour
{
    public string tagToCompare = "Player";
    public GameObject endGameScreen;


    // Essa fun��o detecta o trigger para chamar a fun��o EndGame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag(tagToCompare))
        {
            EndGame();
            
        }
    }

    //Essa fun��o o atual gameplay, ativando a tela de resultados.
    public void EndGame()
    {
        endGameScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
