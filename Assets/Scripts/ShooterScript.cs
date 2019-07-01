using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gunPoint;
    [SerializeField]
    private GameObject enemie;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gunPoint.transform.position, gunPoint.transform.forward, out hit, 100))
        {
            if (hit.collider.gameObject.tag == "inamic")
            {
                Debug.Log("is here");
                enemie.SetActive(false);
            }
        }
    }
}
