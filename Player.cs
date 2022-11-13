using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int Coin;
    float Timer;
    float TimerFunction;

    bool Result;

    Item PlayerItem;
    UiController UiController;
    SoundController SoundController;
    ButtonControler ButtonControler;

    GameObject DengerArea;

    void Awake()
    {
        PlayerItem = this.gameObject.GetComponent<Item>();
        UiController = GameObject.Find("UiController").GetComponent<UiController>();
        SoundController = GameObject.Find("SoundController").GetComponent<SoundController>();
        ButtonControler = GameObject.Find("stick").GetComponent<ButtonControler>();
        DengerArea = GameObject.Find("DengerArea");
    }

    void Start()
    {
        Coin = 0;
        Timer = 124f;
        Result = false;
        UiController.CoinUpdate(Coin);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Timer = Timer - Time.deltaTime;
        UiController.TimeUpdate(Mathf.Floor(Timer));

        if (Timer <= 1 && Result == false)
        {
            SoundController.TimeOverSe();
            ButtonControler.MoveOff();
            string ReturnPlayerItem = PlayerItem.ReturnPlayerItem();
            UiController.OnResult(ReturnPlayerItem,Coin);
            Result = true;
        }
    }

    public void MovePlayer(float MoveVolumeX ,float MoveVolumeY)
    {
        transform.Translate(MoveVolumeX, MoveVolumeY, 0);
        DengerArea.transform.position = new Vector3(this.gameObject.transform.position.x + 6, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.name == "Stone")
        {
            UiController.DigGaugeFunction(obj.gameObject, true, PlayerItem.ReturnPlayerItem());
            SoundController.DigSe();
        }
        else if (obj.name == "Coin")
        {
            Coin += 1;
            Destroy(obj.gameObject);
            UiController.CoinUpdate(Coin);
            SoundController.CoinSe();
        }
        else if (obj.name == "Timer")
        {
            Timer += 10;
            Destroy(obj.gameObject);
            SoundController.ItemSe();
        }
        else if (obj.tag == "pic")
        {
            this.gameObject.GetComponent<Item>().ChangeItem(obj.name);
            Destroy(obj.gameObject);
            SoundController.ItemSe();
        }

        if (obj.tag == "enemy")
        {
            Coin -= 5;
            Destroy(obj.gameObject);
            UiController.CoinUpdate(Coin);
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if (obj.name == "Stone")
        {
            UiController.DigGaugeFunction(obj.gameObject, false ,"");
        }
    }

}
