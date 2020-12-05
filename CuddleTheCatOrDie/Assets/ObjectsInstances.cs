using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInstances : MonoBehaviour
{
    [SerializeField] HandsController handsController;
    [SerializeField] CatsController catsController;

    public static ObjectsInstances instance;
    
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
