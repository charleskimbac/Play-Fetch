using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -26;
    private float spawnLimitXRight = -1;
    private float spawnPosY = 25f;
    
    private int random;
    private WaitForSeconds spawnInterval;
    Vector3 spawnPos;
    public float randomMin = 1.5f;
    public float randomMax = 2.5f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBall());
    }

    // Spawn random ball at random x position at top of play area
    IEnumerator SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        random = Random.Range(0, 2 + 1);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[random], spawnPos, ballPrefabs[random].transform.rotation);

        spawnInterval = new WaitForSeconds(Random.Range(randomMin, randomMax));
        yield return spawnInterval;

        StartCoroutine(SpawnRandomBall());
    }

}
