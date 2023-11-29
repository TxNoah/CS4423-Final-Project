using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject BulletPrefab;
    public Transform SpawnPoint;
    public float rangeRadius = 5f;
    public float fireRate = 1f; // Bullets per second
    public float bulletSpeed = 2f; // Velocity of the bullet
    private float nextFireTime;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            CheckForEnemies();
        }
    }

    void CheckForEnemies()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, rangeRadius);

        foreach (Collider2D col in hitColliders)
        {
            if (col.CompareTag("Zombie"))
            {
                // Check if the zombie's position is within the horizontal range
                float zombieXPosition = col.transform.position.x;
                float shooterXPosition = transform.position.x;

                if (Mathf.Abs(zombieXPosition - shooterXPosition) <= rangeRadius)
                {
                    Shoot();
                    return;
                }
            }
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + 1f / fireRate;
        GameObject bullet = Instantiate(BulletPrefab, SpawnPoint.position, SpawnPoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = SpawnPoint.right * bulletSpeed;
    }
}
