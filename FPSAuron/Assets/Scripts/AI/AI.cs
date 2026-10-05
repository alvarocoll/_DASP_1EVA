using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject destination1;

    public GameObject destination2;
    void Start()
    {
        agent.destination = destination1.transform.position;
    }


    void Update()
    {
       float distance = Vector3.Distance(transform.position, destination1.transform.position);
        {
            if(distance < 2f)
            {
                agent.destination = destination2.transform.position;
            }
        }
    }
}
