using UnityEngine;
using UnityEngine.InputSystem;

public class GunPool : MonoBehaviour
{

    public Transform spawnPoint; // punto desde donde se dispara la bala

    public GameObject bullet; // prefab de la bala

    public float shotForce = 1500f;
    public float shotRate = 0.5f; // tiempo entre disparos, para evitar disparos continuos

    private float ShotRateTime = 0f; // tiempo en el que se puede disparar de nuevo

    private float bulletOffset = 0.5f; // Offset para posicionar el láser ligeramente por delante del punto de disparo


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

            //GameObject newBullet;

            //newBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);

            GameObject newBullet = BulletPool.Instance.RequestBullet(); // Solicitar una bala del pool
            newBullet.SetActive(true); // Activar la bala para que sea visible e interactuable
            if (newBullet == null)
            {
               return;
            }// Si no hay balas disponibles, salir de la función
            
            newBullet.transform.position = spawnPoint.position + spawnPoint.position * bulletOffset; // Posicionar la bala ligeramente por delante del punto de disparo para evitar colisiones con el arma
            newBullet.transform.rotation = spawnPoint.rotation; // Asegurar que la bala tenga la misma rotación que el punto de disparo
            


            Rigidbody rb = newBullet.GetComponent<Rigidbody>(); // Obtener el componente Rigidbody de la bala
            rb.linearVelocity = spawnPoint.forward * shotForce; // Aplicar velocidad a la bala para que se mueva hacia adelante desde el punto de disparo
      


            // Aplicar fuerza a la bala para que se mueva

            //newBullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * shotForce);

            ShotRateTime = Time.time + shotRate;

            // Destruir la bala despues de 5 segundos para evitar acumulacion de objetos

            //Destroy(newBullet, 5f);
        }

        // Controlar la cadencia de disparo
        /*if (Time.time > ShotRateTime)
        {
            ShotRateTime = Time.time + shotRate;
        }
        */
    }
}
