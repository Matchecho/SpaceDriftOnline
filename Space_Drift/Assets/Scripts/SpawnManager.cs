using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Vector2 spawnRangeY;
    public float spawnStartDelay = 2.0f;
    public float spawnInterval = 1.5f;

    private GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    public void Spawnning()
    {
        InvokeRepeating("SpawnObjects",spawnStartDelay, spawnInterval);
    }

    private void SpawnObjects()
    {
        if (GM.isGameActive)
        {
            Vector3 spawnPosition = new Vector3(5.0f, Random.Range(spawnRangeY.x, spawnRangeY.y));
            int idx = Random.Range(0, spawnObjects.Length);
            Instantiate(spawnObjects[idx], spawnPosition, spawnObjects[idx].transform.rotation);
        }
    }
}
