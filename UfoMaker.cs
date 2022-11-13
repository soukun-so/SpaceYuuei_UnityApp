using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoMaker : MonoBehaviour
{
    GameObject UFO;

    float randomY;

    float time;
    // Start is called before the first frame update
    void Awake()
    {
        UFO = Resources.Load<GameObject>("UFO");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = time + Time.deltaTime;
        if (time >= 3)
        {
            randomY = Random.Range(-50f, 50f);
            GameObject ItemPrefab = Instantiate(UFO, new Vector3(50, randomY, 0f), Quaternion.identity);
            ItemPrefab.name = "UFO";
            time = 0;
        }
    }
}
