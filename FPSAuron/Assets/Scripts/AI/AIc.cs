using UnityEngine;
using UnityEngine.AI;

public class AIc : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform[] destinations;

    public float distanceToFollowpath = 2;

    private int i = 0; // Índice para rastrear el destino actual

    [Header("--¿FollowPlayer?--")]

    public bool followPlayer;

    private GameObject player; // Referencia al jugador

    private float distanceToPlayer;

    public float distanceToFollowPlayer = 10f;

    void Start()

    {

        if (destinations == null || destinations.Length == 0)
        {
            transform.gameObject.GetComponent<AIc>().enabled = false;
        }
        else
        {
            agent.destination = destinations[0].transform.position;
            player = FindFirstObjectByType<PlayerMovement>().gameObject; // Asumiendo que hay un script PlayerMovement en el jugador
        }
           
    }


    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
        if (distanceToPlayer <= distanceToFollowPlayer && followPlayer)
        {
            FollowPlayer();
        }
        else
        {
            EnemyPath();
        }
    }

    public void EnemyPath()
    {
        agent.destination = destinations[i].transform.position;

        if (Vector3.Distance(transform.position, destinations[i].transform.position) <= distanceToFollowpath)
        {
            i++;
            if (i >= destinations.Length)
            {
                i = 0; // Reiniciar el índice si se alcanza el final del array
            }
        }
    }

    public void FollowPlayer()
    {
        agent.destination = player.transform.position;
    }
}

