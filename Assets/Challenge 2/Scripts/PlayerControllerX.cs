using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float timeout = 0;

    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (timeout <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            timeout = 1;
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }

        if (timeout > 0)
            timeout -= Time.deltaTime;
    }
}
