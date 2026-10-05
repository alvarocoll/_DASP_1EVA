using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastPlayer : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    private Camera cam;
    private LineRenderer lineRenderer;
  
   private float laserRange = 100f; // Distancia máxima del rayo
    private float laserDuration = 0.2f; // Duración del rayo en segundos

    void Start()
    {
        cam = Camera.main; // Obtener la cámara principal
        lineRenderer = GetComponent<LineRenderer>(); // Obtener el componente LineRenderer
        lineRenderer.enabled = false; // Deshabilitar el LineRenderer al inicio
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
        if (GameManager.Instance.gunAmmo > 0)
        {

            GameManager.Instance.gunAmmo--; // Disminuir la municion al disparar

            RaycastHit hit;
            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)); // Origen del rayo en el centro de la pantalla
            Ray ray = new Ray(rayOrigin, cam.transform.forward);  
            
           lineRenderer.SetPosition(0, spawnPoint.position);

            if (Physics.Raycast(ray, out hit))
            {
                lineRenderer.SetPosition(1, hit.point); // Establecer el punto final del rayo en el punto de impacto
                if (hit.collider.CompareTag("Enemy")) // Verificar si el objeto impactado tiene la etiqueta "Enemy"
                {
                    Destroy(hit.collider.gameObject); // Destruir el enemigo al impactar
                }
            }
            else
            {
                lineRenderer.SetPosition(1, spawnPoint.position + cam.transform.forward * laserRange); // Establecer un punto lejano si no hay impacto

            }
            StartCoroutine(RenderLine());
        }   
    }
    IEnumerator RenderLine()
    {
        lineRenderer.enabled = true; // Habilitar el LineRenderer para mostrar el rayo
        yield return new WaitForSeconds(laserDuration); // Esperar un breve momento para que el rayo sea visible
        lineRenderer.enabled = false; // Deshabilitar el LineRenderer después de mostrar el rayo
    }
}


