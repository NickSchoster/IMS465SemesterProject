using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform player;
    public float detectionRadius = 10f;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= detectionRadius)
            agent.SetDestination(player.position);
        else
            agent.ResetPath();
    }
}
