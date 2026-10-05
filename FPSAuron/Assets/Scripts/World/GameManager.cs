using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  public TextMeshProUGUI ammoText;
    public static GameManager Instance { get; private set; }

    public int gunAmmo = 10;

    public TextMeshProUGUI healthText;

    public int health = 100;

    private void Awake()
{
    if (Instance == null)
    {
        Instance = this;

    }
    else
    {
        Destroy(gameObject);
    }
}

private void Update()
{
    ammoText.text = gunAmmo.ToString();
    healthText.text = health.ToString();
}

public void LoseHealth(int healtToReduce)
{
    health -= healtToReduce; // health = health - healtToReduce
    CheckHealth();
}


public void CheckHealth()
{
    if (health <= 0)
    {
        Debug.Log("Game Over");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
}
