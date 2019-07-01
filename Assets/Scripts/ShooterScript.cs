using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gunPoint;
    public Camera cam;
    [SerializeField]
    private GameObject enemie;
    
    void Start()
    {

    }

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 1000))
        {
            if (hit.collider.gameObject.tag == "enemy")
            {
                Debug.DrawRay(this.transform.position, this.transform.forward, Color.green);
                Debug.Log("is here");
               // enemie.SetActive(false);

            }
        }
    }
}
