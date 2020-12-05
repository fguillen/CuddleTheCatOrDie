using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreensController : MonoBehaviour
{
    public void DeadScreen()
    {
        print("You are dead");
        ObjectsInstances.instance.canvasController.DeadScreen();
    }
}
