using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    KillCounter killCounterScript;

    private void Start()
    {
        killCounterScript=GameObject.Find("KillCount").GetComponent<KillCounter>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
            DestroyEnemy();
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
        killCounterScript.AddKill();
    }
}