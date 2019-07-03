using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private float damage = 10f;
    [SerializeField]
    private ParticleSystem flash;
    [SerializeField]
    private GameObject impactParticle;
    private PlayerManager playerManager;

    void Start()
    {
        playerManager = cam.transform.GetComponent<PlayerManager>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            playerManager.ScoreText.text = playerManager.score.ToString() + " Kills";
        }
        playerManager.LifeText.text = playerManager.hp.ToString() + " HP";
    }
  
    void Shoot()
    {
        flash.Play();
        RaycastHit hit;

        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                EnemiesScript target = hit.transform.GetComponent<EnemiesScript>();
                if (target != null)
                {
                    target.GetDamage(damage, ref playerManager.score);
                }

                GameObject hitEffect = Instantiate(impactParticle, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(hitEffect, 2f);
            }
        }

    }
    
    
}


