using System.Collections;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gunPoint;
    
    [SerializeField]
    private Camera cam;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private GameObject gun;
    [SerializeField]
    private float bulletSpeed = 500f;
    private bool isShooting;

    void Start()
    {
        isShooting = false;
    }

    IEnumerator Shoot()
    {
        isShooting = true;
        GameObject localBullet = Instantiate(bullet, gunPoint.transform.position, Quaternion.identity);
        Rigidbody rb = localBullet.GetComponent<Rigidbody>();
        rb.AddForce(gunPoint.transform.forward * bulletSpeed);
        //Destroy(localBullet,1);
        yield return new WaitForSeconds(1f);
        isShooting = false;
    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1000))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                Debug.DrawRay(this.transform.position, this.transform.forward, Color.green);
                if (!isShooting)
                {
                    StartCoroutine("Shoot");
                    Destroy(hit.collider.gameObject);

                }
                
            }
        }
    }
}
