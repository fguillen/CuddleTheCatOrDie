using UnityEngine;

public class ArrowController : MonoBehaviour
{
    void Update()
    {
        OrientArrow();    
    }

    void OrientArrow()
    {
        if(ObjectsInstances.instance.catsController.GetActiveCat())
        {
            Vector2 catPosition = Camera.main.WorldToScreenPoint(ObjectsInstances.instance.catsController.GetActiveCat().transform.position);
            Vector2 arrowPosition2D = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            gameObject.transform.right = catPosition - arrowPosition2D;
        }
    }

}
