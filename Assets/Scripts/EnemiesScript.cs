using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesScript : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private Transform container;
   

    public void InstatiateEnemy(int nr)
    {
        var position = new Vector3(Random.Range(-15, 5), 0 , Random.Range(-15, 20));
        for (int i = 0; i < nr; i++)
        {
            Instantiate(enemy, position, Quaternion.identity,container); 
        }
    }
}
