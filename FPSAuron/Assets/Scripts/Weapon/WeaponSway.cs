using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    private Quaternion startRotation;

    public float swayAmount = 8f;

    private Vector2 mouseDelta;
    void Start()
    {
        startRotation = transform.localRotation; 
    }

    
    void Update()
    {
        Sway();
    }

    private void Sway()
    {
        float mouseX = mouseDelta.x; 
        float mouseY = mouseDelta.y;

        Quaternion xAngle = Quaternion.AngleAxis(mouseX * -1.25f, Vector3.up); 
        Quaternion yAngle = Quaternion.AngleAxis(mouseY * -1.25f, Vector3.right);
        Quaternion targetRotation = startRotation * xAngle * yAngle;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * swayAmount); // Interpolación suave hacia la rotación objetivo
    }

    public void UpdateMouseDelta(Vector2 delta) // Nuevo método para actualizar mouseDelta
    {
        mouseDelta = delta; 
    }
}
