using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform _player;
    NavMeshAgent _agent;
    [SerializeField] LayerMask groundLayer, playerLayer;

    Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    public float sightRange;
    bool playerInSight;

    void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerInSight = Physics.CheckSphere(transform.position, sightRange, playerLayer);

        if (!playerInSight)
            Patroling();
        else
            ChasePlayer();
    }

    void Patroling()
    {
        if (!walkPointSet)
            SearchWalkPoint();
        else
            _agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    void SearchWalkPoint()
    {
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 1.0f, groundLayer))
            walkPointSet = true;
    }

    void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }
}
