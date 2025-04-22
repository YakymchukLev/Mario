using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;
    public static int coinCountS = 0;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            coinCountS++;
            UpdateCoinText();
        }
    }

    private void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = coinCountS.ToString();
        }
        else
        {
            Debug.LogWarning("Coin Text is not assigned in the Inspector.");
        }
    }
}
