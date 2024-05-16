using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimesReplicator : MonoBehaviour
{
    public GameObject miniSlime;
    ///cuantos enemigos spawnean
    public int spawnCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDestroy()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Instantiate(miniSlime);
        }
    }
}
