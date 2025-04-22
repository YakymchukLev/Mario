using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollAndTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem deathParticleSystem;
    [SerializeField] private ParticleSystem winParticle;
    [SerializeField] private GameObject winPanel;

    private static ParticleSystem staticDeathParticleSystem;

    private void Start()
    {
        winPanel.SetActive(false);
        staticDeathParticleSystem = deathParticleSystem;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (staticDeathParticleSystem != null)
            {
                DeathEffect(transform.position);
            }

            gameObject.SetActive(false);
            UIcontroller.isActive = true;
        }

        else if (collision.gameObject.CompareTag("Wall"))
        {
            DeathEffect(transform.position);
            gameObject.SetActive(false);
            UIcontroller.isActive = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            Instantiate(winParticle, transform.position, Quaternion.identity);
            winParticle.Play();

            winPanel.SetActive(true);
            Destroy(gameObject);
        }
    }

    public static void DeathEffect(Vector3 position)
    {
        if (staticDeathParticleSystem != null)
        {
            ParticleSystem instantiatedParticles = Instantiate(staticDeathParticleSystem, position, Quaternion.identity);
            instantiatedParticles.Play();
        }
    }
}
