using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject enemyBullet;

    public Transform spawnBulletPoint;

    private Transform playerPosition;

    public float bulletVelocity = 1000f;
    void Start()
    {
        playerPosition = GameObject.FindFirstObjectByType<PlayerInteractions>().transform;

        Invoke("ShootPlayer", 3);
    }

   
    void Update()
    {
        
    }

    void ShootPlayer()
    {

        Vector3 playerDirection = playerPosition.position - transform.position;

        GameObject newBullet;

        newBullet = Instantiate(enemyBullet, spawnBulletPoint.position, spawnBulletPoint.rotation);

        newBullet.GetComponent<Rigidbody>().AddForce(playerDirection * bulletVelocity, ForceMode.Impulse);

        Invoke("ShootPlayer", 3);
    }


}
