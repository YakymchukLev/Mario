using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer enemySprite;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] private float moveSpeed = 2f;
    private Vector3 targetPoint;
    private Animator _animator;

    private void Start()
    {
        targetPoint = pointB.position;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Patrol();
        _animator.SetFloat("EnemySpeed", moveSpeed);
    }

    private void Patrol()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPoint, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, targetPoint) < 0.3f)
        {
            if (targetPoint == pointB.position)
            {
                targetPoint = pointA.position;
                enemySprite.flipX = false;
            }
            else
            {
                targetPoint = pointB.position;
                enemySprite.flipX = true;
            }
        }
    }
}
