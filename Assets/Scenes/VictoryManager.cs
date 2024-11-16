using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private string nomeDoMenu;
    [SerializeField] private string nomeDoJogo;
    public void Reiniciar()
    {
        SceneManager.LoadScene(nomeDoJogo);
    }
    public void VoltarMenu()
    {
        SceneManager.LoadScene(nomeDoMenu);
    }
}
