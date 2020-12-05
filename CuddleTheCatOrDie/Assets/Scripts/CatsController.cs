using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatsController : MonoBehaviour
{
    [SerializeField] GameObject catPrefab;
    [SerializeField] Transform[] catSpawners;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCat();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCat()
    {
        Transform spawner = RandomSpawner();
        Instantiate(catPrefab, spawner.position, spawner.rotation);
    }
    Transform RandomSpawner()
    {
        return catSpawners[Random.Range(0, catSpawners.Length)];
    }
}
