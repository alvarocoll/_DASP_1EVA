using UnityEngine;

public class BulletOptimiz : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5f; // Velocidad a la que se mueve la bala
    [SerializeField] private Rigidbody bulletRb;

    private void OnEnable()
    {
        if (bulletRb == null) // Verificar si el Rigidbody no está asignado en el Inspector
            bulletRb = GetComponent<Rigidbody>(); // Asegurar que el componente Rigidbody esté asignado

        bulletRb.linearVelocity = Vector3.zero; // Reiniciar la velocidad de la bala para evitar que conserve la velocidad anterior al ser reutilizada desde el pool
        bulletRb.angularVelocity = Vector3.zero; // Reiniciar la velocidad angular de la bala para evitar que conserve la rotación anterior al ser reutilizada desde el pool

    }

    private void OnCollisionEnter(Collision collision)
    {
        if ( collision.gameObject.CompareTag("Enemy"))
        {
            //Destroy(collision.gameObject);
            gameObject.SetActive(false); // Desactivar la bala en lugar de destruirla para reutilizarla desde el pool
        }
    }


}
