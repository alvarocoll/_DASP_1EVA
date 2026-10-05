using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public Transform startPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GunAmmo"))
        {
            GameManager.Instance.gunAmmo += other.gameObject.GetComponent<AmmoBox>().ammo;
            Destroy(other.gameObject);
        }


        if (other.gameObject.CompareTag("DeathGround"))
        {
            //Perder Vida y respawnear al jugador


            GameManager.Instance.LoseHealth(5);

            GetComponent<CharacterController>().enabled = false;
            gameObject.transform.position = startPosition.position;
            GetComponent<CharacterController>().enabled = true;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            GameManager.Instance.LoseHealth(5);
            Destroy(collision.gameObject);
        }
    }
}
