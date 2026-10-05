using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private int poolSize = 10; // Tamaño del pool de bullets
    [SerializeField] private GameObject bulletPrefab;
   private List<GameObject> bulletList = new List<GameObject>(); // Lista para almacenar los bullets del pool

    private static BulletPool _instance;
    public static BulletPool Instance { get { return _instance; } } 
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        AddBulletsToPool(poolSize); // Llamar a la función para agregar bullets al pool al inicio del juego

        for (int i = 0; i < poolSize; i++) // Crear el pool de bullets al inicio del juego
        {
            GameObject newBullet = Instantiate(bulletPrefab); // Instanciar un nuevo bullet a partir del prefab
            newBullet.SetActive(false); // Desactivar el bullet para que no sea visible ni interactuable
            bulletList.Add(newBullet); // Agregar el bullet a la lista del pool
           // newBullet.transform.parent = transform; // Hacer que el bullet sea hijo del objeto del pool para mantener el orden en la jerarquía
        }
    }
   private void AddBulletsToPool (int amount)
    {
        for (int i = 0; i < amount; i++) // Crear el pool de bullets al inicio del juego
        {
            GameObject newBullet = Instantiate(bulletPrefab); // Instanciar un nuevo bullet a partir del prefab
            newBullet.SetActive(false); // Desactivar el bullet para que no sea visible ni interactuable
            bulletList.Add(newBullet); // Agregar el bullet a la lista del pool
            newBullet.transform.parent = transform; // Hacer que el bullet sea hijo del objeto del pool para mantener el orden en la jerarquía
        }
    }

    public GameObject RequestBullet()
    {
        for (int i = 0; i < bulletList.Count; i++) // Recorrer la lista del pool para encontrar un bullet disponible
        {
            if (!bulletList[i].activeSelf) // Si el bullet no está activo, significa que está disponible para usar
            {
                return bulletList[i]; // Devolver el bullet disponible
            }
        }
        return null; // Si no hay bullets disponibles, devolver null
    }
}


