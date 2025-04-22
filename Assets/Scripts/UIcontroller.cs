using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIcontroller : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    public static bool isActive = false;

    private void Awake()
    {
        gameOverPanel.SetActive(false);
    }

    private void Update()
    {
        gameOverPanel.SetActive(isActive);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGame");
        CoinController.coinCountS = 0;
        isActive = false;
    }

    public void Exit()
    {
        Application.Quit(); 
    }


}
