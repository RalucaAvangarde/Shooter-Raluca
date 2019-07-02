using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
   // [SerializeField]
   // private GameObject enemy;
    [SerializeField]
    private Transform container;
    private Collider[] Colliders;
    private float radius = 200;
    public GameObject zombie;
    public float spawninterval;
    public float nextspawn;
    public LayerMask mask;
    // Use this for initialization
    void Start()
    {
        nextspawn = Time.time + spawninterval; // set initial next spawn time
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextspawn)
        {
            nextspawn = Time.time + spawninterval;
            SpawnZombie();
        }
    }

    void SpawnZombie()
    {

        bool canInstantiate = false;

        Vector3 spawnPos = new Vector3(0, 0, 0);

        while (!canInstantiate)
        {

            var instantiateZ = Random.Range(-15f, 20f);
            //var instantiateY = this.transform.position.y + Random.Range(0f, 130f);
            var instantiateX = this.transform.position.y + Random.Range(-15f, 5f);

            spawnPos = new Vector3(instantiateX, 0, instantiateZ);
            canInstantiate = PreventOverlap(spawnPos);

            if (canInstantiate)
            {
                break;
            }
        }

        //var position = new Vector3(Random.Range(-15, 5), 0, Random.Range(-15, 20));
        Instantiate(zombie, spawnPos, transform.rotation, container);
    }
    /*public void InstatiateEnemy(int nr)
    {
        var position = new Vector3(Random.Range(-15, 5), 0 , Random.Range(-15, 20));
        for (int i = 0; i < nr; i++)
        {
            Instantiate(enemy, position, Quaternion.identity,container); 
        }
    }*/

    public bool PreventOverlap(Vector3 spawnPos)
    {
        Colliders = Physics.OverlapSphere(spawnPos, radius, mask);

        for (int i = 0; i < Colliders.Length; i++)
        {
            Vector3 centerPoint = Colliders[i].bounds.center;
            float width = Colliders[i].bounds.extents.z;
            float height = Colliders[i].bounds.extents.y;

            float leftExtent = centerPoint.z - width * 4;
            float rightExtent = centerPoint.z + width * 4;
            float lowerExtent = centerPoint.y - height * 4;
            float upperExtent = centerPoint.y + height * 4;

            if (spawnPos.z >= leftExtent && spawnPos.z <= rightExtent)
            {
                if (spawnPos.y >= lowerExtent && spawnPos.y <= upperExtent)
                {
                    return false;
                }
            }
        }
        return true;
    }
}
