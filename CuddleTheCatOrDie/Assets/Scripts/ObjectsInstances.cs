using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ObjectsInstances : MonoBehaviour
{
    [SerializeField] public HandController handController;
    [SerializeField] public CatsController catsController;
    [SerializeField] public ScreensController screensController;
    [SerializeField] public ScoreController scoreController;
    [SerializeField] public CanvasController canvasController;
    [SerializeField] public CounterController counterController;
    [SerializeField] public CinemachineVirtualCamera virtualCamera;

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
