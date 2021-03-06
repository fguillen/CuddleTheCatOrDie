﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CatsController : MonoBehaviour
{
    [SerializeField] GameObject catPrefab;
    [SerializeField] Transform[] catSpawners;

    [SerializeField] public GameObject activeCat;

    BeizerCalculator difficultyBeizer;
    Transform actualSpawner;

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
        actualSpawner = RandomSpawner();
        activeCat = Instantiate(catPrefab, actualSpawner.position, actualSpawner.rotation);

        SetSecondsToBeAngry(activeCat);
    }
    Transform RandomSpawner()
    {
        var allSpawnersButTheActualOne = catSpawners.Where(e => e != actualSpawner).ToArray();

        return allSpawnersButTheActualOne[Random.Range(0, allSpawnersButTheActualOne.Length)];
    }

    public GameObject GetActiveCat()
    {
        return activeCat;
    }

    float SecondsToGetAngry(int numOfAlreadyCuddleCats)
    {
        if(numOfAlreadyCuddleCats > 30)
        {
            return 3;
        }

        // normalize
        float t = numOfAlreadyCuddleCats / 30f;

        Vector3 resultVector = DifficultyBeizer().calculate(t);
        float result = resultVector.y;

        return result;
    }

    BeizerCalculator DifficultyBeizer()
    {
        if(difficultyBeizer != null)
        {
            return difficultyBeizer;
        }
        // https://www.desmos.com/calculator/gagy1auuwq
        Vector3 p0 = new Vector3(0, 20, 0);
        Vector3 p1 = new Vector3(4, 2, 0);
        Vector3 p2 = new Vector3(20, 3, 0);
        Vector3 p3 = new Vector3(30, 3, 0);

        difficultyBeizer = new BeizerCalculator(p0, p1, p2, p3);

        return difficultyBeizer;
    }

    void SetSecondsToBeAngry(GameObject cat)
    {
        int numOfAlreadyCuddleCats = ObjectsInstances.instance.scoreController.GetScore();
        float seconds = SecondsToGetAngry(numOfAlreadyCuddleCats);

        // Adding buffer for distance based more or less the half of the Hand speed
        float distance = Vector3.Distance(ObjectsInstances.instance.handController.gameObject.transform.position, cat.transform.position);
        float handSpeed = ObjectsInstances.instance.handController.GetSpeed();
        
        float buffer = distance / (handSpeed / 2);

        print("distance: " + distance);
        print("buffer: " + buffer);

        seconds += buffer;

        cat.GetComponent<CatController>().SetSecondsToBeAngry(seconds);

        // cat.GetComponent<CatController>().SetSecondsToBeAngry(3);
    }


}
