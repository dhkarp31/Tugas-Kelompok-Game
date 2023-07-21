using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : MonoBehaviour
{
    public int damage;
    public bool canStickToEnemies = true; // Tambahkan variabel ini untuk mengontrol apakah proyektil bisa menempel pada musuh atau tidak

    private Rigidbody rb;
    private bool targetHit;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // make sure only to stick to the first target you hit
        if (targetHit)
            return;
        else
            targetHit = true;

        // check if you hit an enemy
        if (canStickToEnemies && collision.gameObject.GetComponent<EnemyDamage>() != null)
        {
            EnemyDamage enemy = collision.gameObject.GetComponent<EnemyDamage>();

            enemy.TakeDamage(damage);
            // destroy projectile
            Destroy(gameObject);
        }
        else
        {
            // make sure projectile sticks to surface only if canStickToEnemies is false
            if (!canStickToEnemies)
            {
                rb.isKinematic = true;
                // destroy projectile after a short delay
                Destroy(gameObject, 2f);
            }
        }
    }
}
