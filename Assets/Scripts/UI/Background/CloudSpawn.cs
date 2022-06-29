using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour
{
    public GameObject cloud;
    public float spawnTime = 1f;
    public float spawnDelay = 0.5f;
    GameObject newCloud;
    // Start is called before the first frame update
    void Start()
    {
        newCloud = Instantiate(cloud, transform.position, transform.rotation) as GameObject;
        newCloud.transform.SetParent(GameObject.FindGameObjectsWithTag("Spawn")[0].transform, false);
        InvokeRepeating("SpawnCloud", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnCloud()
    {
        Vector2 cloudPos = new Vector2(newCloud.transform.position.x, Random.Range(transform.position.y - 100, transform.position.y + 100));
        Instantiate(newCloud, cloudPos, Quaternion.identity);
    }
}
