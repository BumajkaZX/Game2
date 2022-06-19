using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MenuCutSceneSkip : MonoBehaviour
{   
    [SerializeField]
    GameObject cutScene;
    double currTime;
    PlayableDirector tL;
    [SerializeField]
    double timeM;
    // Start is called before the first frame update
    void Start()
    {
        tL = GetComponent<PlayableDirector>();
        currTime = tL.duration;
    }

    private void Update()
    {
        if (tL.time >= currTime - timeM)
        {
            cutScene.SetActive(false);
       }
       
    }
    void FixedUpdate()
    {
       
    }
}
