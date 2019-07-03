using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField]
    private Transform container;
    [SerializeField]
    private Transform portal1;
    [SerializeField]
    private Transform portal2;
    [SerializeField]
    private GameObject zombie;
    [SerializeField]
    private float radius = 200;
    [SerializeField]
    private float spawninterval;
    [SerializeField]
    private float nextspawn;
    [SerializeField]
    private LayerMask mask;
    private Collider[] colliders;

    void Start()
    {
        nextspawn = Time.time + spawninterval; 
    }

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
        Vector3 spawnPos2 = new Vector3(0, 0, 0);

        while (!canInstantiate)
        {

            spawnPos = new Vector3(portal2.position.x, 0, 0);
            spawnPos2 = new Vector3(portal1.position.x, 0, portal1.position.z);
            canInstantiate = PreventOverlap(spawnPos);

            if (canInstantiate)
            {
                break;
            }
        }

        Instantiate(zombie, spawnPos, transform.rotation, container);
        Instantiate(zombie, spawnPos2, transform.rotation, container);
    }
 
    public bool PreventOverlap(Vector3 spawnPos)
    {
        colliders = Physics.OverlapSphere(spawnPos, radius, mask);

        for (int i = 0; i < colliders.Length; i++)
        {
            Vector3 centerPoint = colliders[i].bounds.center;
            float width = colliders[i].bounds.extents.z;
            float height = colliders[i].bounds.extents.y;

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
