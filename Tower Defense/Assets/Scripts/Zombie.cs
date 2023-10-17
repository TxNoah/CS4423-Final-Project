using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    [SerializeField] float zom_speed;
    [SerializeField] int maxHealth = 0;
    private int currentHealth;
    public bool move;

    void Start(){
        currentHealth = maxHealth;
    }

    void Update()
    {
        if(this.move){
            this.transform.Translate(Vector3.left * this.zom_speed * Time.deltaTime);
        }        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
