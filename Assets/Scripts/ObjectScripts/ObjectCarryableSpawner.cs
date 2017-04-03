using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCarryableSpawner : MonoBehaviour
{
    public List<GameObject> spawnedObjects = new List<GameObject>();
    public GameObject toSpawn;
    public float timeToSpawn;
    public float despawnTime;
    public bool startImmediate = false;
  public AudioClip hereICome;
    bool canSpawn;

    private void Start()
    {
        //Call the SpawnObj() method every timeToSpawnSeconds
        InvokeRepeating("SpawnObj", timeToSpawn, timeToSpawn);
    }

    void SpawnObj()
    {
        //set canSpawn to true
        canSpawn = true;

        //loop throught all objects in the list 
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
      //SoundManager.instance.Random(hereICome);

            if (spawnedObjects[i] == null)
            {
                spawnedObjects.RemoveAt(i);
                i--;
            }

        }
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            float distanceOfObjects = Vector3.Distance(transform.position, spawnedObjects[i].transform.position);
            //is it close enough
            if (distanceOfObjects < 2)
            {
                //say we cannot open
                canSpawn = false;
                break;
            }

        }
        if(canSpawn)
        {
            GameObject tempObj = Instantiate(toSpawn, transform.position, Quaternion.identity);

            spawnedObjects.Add(tempObj);

            if(despawnTime>0)
            {
                if(startImmediate==true)
                {
                    Destroy(tempObj, despawnTime);
                }
                else
                {
                    tempObj.GetComponent<ObjectCarryable>().despawnTime = despawnTime;
                }
            }
        }


    }
}
