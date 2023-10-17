using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectiles : MonoBehaviour
{
	[SerializeField] int damage = 1; // Adjust the damage value per bullet.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Zombie"))
        {
            Zombie zombie = other.GetComponent<Zombie>();

            if (zombie != null)
            {
                zombie.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }

}
