using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    Transform _playerTransform;
    NavMeshAgent _agent;
    [SerializeField] LayerMask groundLayer, playerLayer;

    Vector3 walkPoint;
    bool walkPointSet;
    [SerializeField] float walkPointRange;

    [SerializeField] float sightRange;
    bool playerInSight;

    void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        _playerTransform = GameManager.Instance.player.transform;
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
        _agent.SetDestination(_playerTransform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.loseLevelScreen.SetActive(true);
        }
    }
}
