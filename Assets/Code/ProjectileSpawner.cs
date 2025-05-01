using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject[] projectilePrefabs; //ปาได้หลายแบบ
    public Transform leftSpawner, rightSpawner, topSpawner;
    public float spawnInterval = 2f;
    public float projectileForce = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnProjectile", 1f, spawnInterval);
    }

    void SpawnProjectile()
    {
        if (projectilePrefabs.Length == 0)
        {
            Debug.LogWarning("ยังไม่ได้ใส่ projectile prefab!");
            return;
        }

        int projectileIndex = Random.Range(0, projectilePrefabs.Length);
        GameObject selectedProjectile = projectilePrefabs[projectileIndex];

        int side = Random.Range(0, 3);
        Transform spawnPoint = leftSpawner;

        if (side == 0) spawnPoint = leftSpawner;
        else if (side == 1) spawnPoint = rightSpawner;
        else spawnPoint = topSpawner;

        GameObject projectile = Instantiate(selectedProjectile, spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

#if UNITY_2023_หรือ_สูงกว่า
        rb.linearVelocity = GetDirection(side) * projectileForce; // Unity 2023+
#else
        rb.velocity = GetDirection(side) * projectileForce; 
#endif
    }

    Vector2 GetDirection(int side)
    {
        if (side == 0) return new Vector2(1, Random.Range(-0.5f, -1f));
        if (side == 1) return new Vector2(-1, Random.Range(-0.5f, -1f));
        return new Vector2(Random.Range(-1f, 1f), -1);
    }
}
