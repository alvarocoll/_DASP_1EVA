using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float timeToAutoDestroy = 5f;
    void Start()
    {
        Invoke(nameof(AutoDestroyBullet), timeToAutoDestroy);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

    void AutoDestroyBullet()
    {
        Destroy(gameObject);
    }
}
