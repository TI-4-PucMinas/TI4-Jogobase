using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes; // Corrigido o nome

    public void Jogar()
    {
        SceneManager.LoadScene(nomeDoLevelDeJogo); // Corrigido "loadScene" para "LoadScene"
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true); // Corrigido o nome
    }

    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false); // Corrigido o nome
        painelMenuInicial.SetActive(true);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
