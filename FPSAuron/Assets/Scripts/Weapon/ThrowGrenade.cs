using UnityEngine;
using UnityEngine.InputSystem;

public class ThrowGrenade : MonoBehaviour
{
    public float throwForce = 500f;

    public GameObject grenadePrefab;


    void Update()
    {
       
    }

    public void OnGrenade(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
          
            Throw();
        }
    }
    public void Throw()
    {
        GameObject newGrenade = Instantiate(grenadePrefab, transform.position, transform.rotation);

        newGrenade.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce);

    }
}
