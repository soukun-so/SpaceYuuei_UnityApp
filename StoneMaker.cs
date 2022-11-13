using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMaker : MonoBehaviour
{
    GameObject Stone;
    GameObject StoneFolder;
    float randomX;
    float randomY;

    float time;

    void Awake()
    {
        StoneFolder = GameObject.Find("StoneFolder");
    }
    // Start is called before the first frame update
    void Start()
    {
        Stone = Resources.Load<GameObject>("Stone");

        InstantiateStone();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        time = time + Time.deltaTime;
        if (time >= 60)
        {
            foreach (Transform child in StoneFolder.transform)
            {
                Destroy(child.gameObject);
            }
            Invoke("InstantiateStone",1f);
            time = 0;
        }
    }

    void InstantiateStone()
    {
        for (int i = 0; i <= 100; i++)
        {
            randomX = Random.Range(-50f, 50f);
            randomY = Random.Range(-50f, 50f);
            GameObject ItemPrefab = Instantiate(Stone, new Vector3(randomX, randomY, 0f), Quaternion.identity);
            ItemPrefab.name = "Stone";
            ItemPrefab.transform.parent = StoneFolder.transform;
        }
    }
}
