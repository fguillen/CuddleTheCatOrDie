using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{

    [SerializeField] Sprite[] spriteTemplates;
    [SerializeField] float secondsOfCuddling;
    [SerializeField] string state;


    // Start is called before the first frame update
    void Start()
    {
        RandomSprite();
        state = "idle";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RandomSprite()
    {
        Sprite sprite = spriteTemplates[Random.Range(0, spriteTemplates.Length)];

        GetComponent<SpriteRenderer>().sprite = sprite;
    }

    public void BeingCuddled()
    {
        print("Being Cuddled");

        secondsOfCuddling -= Time.deltaTime;
        if(secondsOfCuddling <= 0)
        {
            ObjectsInstances.instance.handsController.CatHappy(this.gameObject);
            IsHappy();
        }
    }

    void IsHappy()
    {
        Destroy(this.gameObject);
        ObjectsInstances.instance.catsController.SpawnCat();
    }


}
