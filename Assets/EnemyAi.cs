using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    private Transform target; // O transform do jogador
    public float moveSpeed = 5f; // Velocidade de movimento do inimigo
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        target  = FindObjectOfType<spaceship>().transform; // encontra instancia do tipo de objeto na scene
    }

    void Update()
    {
        agent.SetDestination(target.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && spaceship.shield == false)
        {
           // Destroy(collision.gameObject);
        }
    }
}