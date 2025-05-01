using UnityEngine;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject[] projectilePrefabs; //Prefabหลายอัน
    public Transform leftSpawner, rightSpawner, topSpawner;
    public float spawnInterval = 2f;
    public float projectileForce = 5f;

    private void Start()
    {
        InvokeRepeating("SpawnProjectile", 1f, spawnInterval);
    }

    void SpawnProjectile()
    {
        // สุ่มเลือกว่าใช้ Prefab อันไหน
        int projectileIndex = Random.Range(0, projectilePrefabs.Length);
        GameObject selectedProjectile = projectilePrefabs[projectileIndex];

        // สุ่มจุด Spawn
        int side = Random.Range(0, 3);
        Transform spawnPoint = leftSpawner;

        if (side == 0) spawnPoint = leftSpawner;
        else if (side == 1) spawnPoint = rightSpawner;
        else if (side == 2) spawnPoint = topSpawner;

        GameObject projectile = Instantiate(selectedProjectile, spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        if (side == 0) rb.velocity = new Vector2(1, Random.Range(-0.5f, -1f)) * projectileForce;
        else if (side == 1) rb.velocity = new Vector2(-1, Random.Range(-0.5f, -1f)) * projectileForce;
        else if (side == 2) rb.velocity = new Vector2(Random.Range(-1f, 1f), -1) * projectileForce;
    }
}
