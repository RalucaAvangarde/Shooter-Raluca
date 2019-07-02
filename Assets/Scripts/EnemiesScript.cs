using UnityEngine;
using UnityEngine.AI;

public class EnemiesScript : MonoBehaviour
{
    private Transform player;
    private NavMeshAgent agent;

    public void Start()
    {
        player = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination =player.position;
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log("hit");
        GetComponent<CapsuleCollider>().enabled = false;

        Destroy(col.gameObject);

        agent.destination = gameObject.transform.position;

        Destroy(gameObject, 6);
    }
}
