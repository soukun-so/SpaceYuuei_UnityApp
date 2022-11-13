using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wall : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "enemy")
        {
            Destroy(obj.gameObject);
        }
    }
}
