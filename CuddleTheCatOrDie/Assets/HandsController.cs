using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class HandsController : MonoBehaviour
{
    [SerializeField] Transform[] limits;
    [SerializeField] float speed;

    float minX;
    float maxX;
    float minY;
    float maxY;


    // Start is called before the first frame update
    void Start()
    {
        minX = limits.Min(e => e.position.x);
        maxX = limits.Max(e => e.position.x);
        minY = limits.Min(e => e.position.y);
        maxY = limits.Max(e => e.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsCursor();
    }

    void MoveTowardsCursor()
    {
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        // transform.position = new Vector3(worldPosition.x, worldPosition.y, transform.position.z);

        transform.position = Vector3.MoveTowards(transform.position, worldPosition, speed * Time.deltaTime);

        if(transform.position.x > maxX) transform.position = new Vector3(maxX, transform.position.y, transform.position.z);
        if(transform.position.x < minX) transform.position = new Vector3(minX, transform.position.y, transform.position.z);
        if(transform.position.y > maxY) transform.position = new Vector3(transform.position.x, maxY, transform.position.z);
        if(transform.position.y < minY) transform.position = new Vector3(transform.position.x, minY, transform.position.z);
    }
}
