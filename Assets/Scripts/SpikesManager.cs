using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikesManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SetActive(false);
            UIcontroller.isActive = true;
            PlayerCollAndTrigger.DeathEffect(playerTransform.position);
            PlayerLifes.Damage();
        }
    }
}
