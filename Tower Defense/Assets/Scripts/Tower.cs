using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // This ensures that a Rigidbody component is added automatically if not present
public class Tower : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Zombie zombie = collision.gameObject.GetComponent<Zombie>();
            if (zombie != null)
            {
                zombie.AttackTower(this);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            DestroyTower();
        }
    }

    private void DestroyTower()
    {
        // Destroy the tower or handle game over logic
        Debug.Log("Tower Destroyed!");
        // Example: You can deactivate tower's gameObject or perform other actions for game over.
        gameObject.SetActive(false);
    }
}
