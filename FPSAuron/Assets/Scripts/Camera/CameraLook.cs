using UnityEngine;
using UnityEngine.InputSystem;

public class CameraLook : MonoBehaviour
{

    public float mouseSensitivity = 80f;
    private Vector2 mouseDelta;

    public Transform playerBody;

    float xRotation = 0f;

    public WeaponSway weaponSway; // Referencia al script WeaponSway

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

  public void OnLook (InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();

        // Pasa el valor del mouseDelta al WeaponSway

        if (weaponSway != null)
        {
            weaponSway.UpdateMouseDelta(mouseDelta);
        }
    }
    void Update()
    {
        float mouseX = mouseDelta.x*mouseSensitivity * Time.deltaTime;

        float mouseY = mouseDelta.y*mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY; // Invertimos el mouseY para que subir la cámara sea hacia arriba

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Limitamos la rotación vertical para que no gire 360 grados

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotamos la cámara en el eje X

        playerBody.Rotate(Vector3.up * mouseX); // Rotamos el cuerpo del jugador en el eje Y
    }
}
