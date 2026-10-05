using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{

    public Transform spawnPoint; // punto desde donde se dispara la bala

    public GameObject bullet; // prefab de la bala

    public float shotForce = 1500f;
    public float shotRate = 0.5f; // tiempo entre disparos, para evitar disparos continuos

    private float ShotRateTime = 0f; // tiempo en el que se puede disparar de nuevo


    void Update()
    {

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        if (Time.time > ShotRateTime && GameManager.Instance.gunAmmo > 0)
        {

            GameManager.Instance.gunAmmo--; // Disminuir la municion al disparar

            GameObject newBullet;

            newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            // Aplicar fuerza a la bala para que se mueva

            newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

            ShotRateTime = Time.time + shotRate;

            // Destruir la bala despues de 5 segundos para evitar acumulacion de objetos

            Destroy(newBullet, 5f);
        }

        // Controlar la cadencia de disparo
        /*if (Time.time > ShotRateTime)
        {
            ShotRateTime = Time.time + shotRate;
        }
        */
    }
}
