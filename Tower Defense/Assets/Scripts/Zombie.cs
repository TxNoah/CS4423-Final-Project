using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // This ensures that a Rigidbody component is added automatically if not present
public class Zombie : MonoBehaviour
{
    [SerializeField] float zom_speed;
    [SerializeField] int maxHealth = 0;
    private int currentHealth;
    public bool move;
    public int damage = 10;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (this.move)
        {
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

    
    public void AttackTower(Tower tower)
    {
        tower.TakeDamage(damage);
    }
}
