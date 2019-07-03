using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemiesScript : MonoBehaviour
{
    
    [SerializeField]
    private Transform player;
    private PlayerManager playerManager;
    private NavMeshAgent agent;
    [SerializeField]
    private GameObject dieParticle;


    public float health = 100f;
    public void Start()
    {
        player = Camera.main.transform;
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.position;
    }

    void Update()
    {
        CheckDestinationReached();
    }

    void CheckDestinationReached()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    playerManager = player.GetComponent<PlayerManager>();
                    if (playerManager.hp > 0)
                    {
                        GameObject hitEffect = Instantiate(dieParticle, player.position, Quaternion.identity);
                        Destroy(hitEffect, 2f);
                        playerManager.DecreaseHP(5);
                        Die();
                    }
                    else
                    {
                        int scene = SceneManager.GetActiveScene().buildIndex;
                        SceneManager.LoadScene(scene, LoadSceneMode.Single);
                    }
                    

                }
            }
        }
    }

    public void GetDamage(float ammount,ref int score)
    {
        health -= ammount;
        if (health <= 0)
        {
            Die();
            score++;
        }
    }


    private void Die()
    {
        
        Destroy(gameObject);
    }

   
}
