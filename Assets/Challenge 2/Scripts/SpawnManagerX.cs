using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -26;
    private float spawnLimitXRight = -1;
    private float spawnPosY = 25f;
    /*
    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;
    */
    private int random;
    private WaitForSeconds spawnInterval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomBall());
    }

    // Spawn random ball at random x position at top of play area
    IEnumerator SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        random = Random.Range(0, 2 + 1);
        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[random], spawnPos, ballPrefabs[random].transform.rotation);

        spawnInterval = new WaitForSeconds(Random.Range(3f, 5f));
        yield return spawnInterval;

        StartCoroutine(SpawnRandomBall());
    }

}
