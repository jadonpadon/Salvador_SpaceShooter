using UnityEngine;
using System.Collections;
using Codice.Client.BaseCommands.CheckIn.Progress;
using JetBrains.Annotations;

public class Enemy : MonoBehaviour
{
    public Transform playerTransform;
    public float speed;

    private void Update()
    {
        EnemyMovement();
    }

    public void EnemyMovement()
    {
        Vector3 enemyToPlayer = playerTransform.position - transform.position;
        enemyToPlayer.Normalize();

        Vector3 follow = enemyToPlayer * speed * Time.deltaTime;

        transform.position += follow;
    }

}
