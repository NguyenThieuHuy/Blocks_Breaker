using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Level : MonoBehaviour
{
    [SerializeField] int breakableBlocks; // For debugging purposes
    [SerializeField] int breakableBlockswithtag; // For debugging purposes
    SceneLoader sceneLoader;
    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        breakableBlockswithtag = GameObject.FindGameObjectsWithTag("Block").Length;
    }
/*    private void Update()
    {
        breakableBlockswithtag = GameObject.FindGameObjectsWithTag("Block").Length;
        if (breakableBlockswithtag == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }*/
    public void countBreakableBlocks()
    {
        breakableBlocks++;
    }
    public void destroyBreakableBlocks()
    {
        breakableBlocks--;
        if (breakableBlocks == 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

}
