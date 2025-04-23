using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifes : MonoBehaviour
{
    public static void Damage()
    {
        GameData.lifes--;
        if (GameData.lifes <= 0)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
