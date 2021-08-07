using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilesPrefabs;
    public float zSpaw = 0;
    public float tileslength = 30;
    public int numberOfTiles = 5;
    private List<GameObject> activeTiles = new List<GameObject>();

    public Transform playerTransform;
    void Start()
    {
        for(int i=0;i<numberOfTiles;i++)
        {
            if(i==0)
                SpawnTile(0);
            else
                SpawnTile(Random.Range(0,tilesPrefabs.Length));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - 35 > zSpaw - (numberOfTiles * tileslength))
        {
            SpawnTile(Random.Range(0,tilesPrefabs.Length));
            DeleteTile();
        }
    }

    public void SpawnTile(int tileIndex)
    {
        GameObject go = Instantiate(tilesPrefabs[tileIndex], transform.forward * zSpaw, transform.rotation);
        activeTiles.Add(go);
        zSpaw += tileslength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}
