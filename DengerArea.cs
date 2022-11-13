using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DengerArea : MonoBehaviour
{
    UiController UiController;

    void Awake()
    {
        UiController = GameObject.Find("UiController").GetComponent<UiController>();
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.tag == "enemy")
        {
            UiController.DengerFunction();
        }
    }
}
