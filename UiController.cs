using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class UiController : MonoBehaviour
{
    float DigGaugeValue;
    float DigSpead;
    bool StartBool;
    bool NowDig;
    bool DengerBool;

    public GameObject Player;
    GameObject DigStone;
    GameObject Canvas;

    public Text Text;
    Text Coin;
    Text Timer;
    Text ResultDigText;
    Text ResultCoinText;
    Image DigItemSprite;
    Transform DigGauge;
    Transform Result;
    Transform Denger;
    SoundController SoundController;
    ButtonControler ButtonControler;
    public Sprite PlayerLeft;
    public Sprite PlayerRight;

    NCMBObject LeaderBoard = new NCMBObject("SpaceDigLeaderBoard");
    // Start is called before the first frame update
    void Awake()
    {
        Application.targetFrameRate = 60;

        Player = GameObject.Find("Player");
        Text = GameObject.Find("UIText").GetComponent<Text>();
        Coin = GameObject.Find("CoinText").GetComponent<Text>();
        Timer = GameObject.Find("TimeText").GetComponent<Text>();
        DigItemSprite = GameObject.Find("DigItem").GetComponent<Image>();
        Canvas = GameObject.Find("Canvas");
        DigGauge = Canvas.transform.Find("DigGauge");
        Denger = Canvas.transform.Find("Denger");
        Result = Canvas.transform.Find("Result");
        ResultDigText = Canvas.transform.Find("Result").transform.Find("ResultDigText").GetComponent<Text>();
        ResultCoinText = Canvas.transform.Find("Result").transform.Find("ResultCoinText").GetComponent<Text>();
        SoundController = GameObject.Find("SoundController").GetComponent<SoundController>();
        ButtonControler = GameObject.Find("stick").GetComponent<ButtonControler>();
        PlayerLeft = Resources.Load<Sprite>("PlayerLeft");
        PlayerRight = Resources.Load<Sprite>("PlayerRight");

        DigGaugeValue = 1f;
        StartBool = false;
        DengerBool = false;
    }

    void Start()
    {
        Text.text = "3";
        SoundController.StartSeFunction();
        Invoke("two", 1f);
        Invoke("one", 2f);
        Invoke("Go", 3f);
        Invoke("Del", 4f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (NowDig == true && StartBool == true)
        {
            DigGaugeValue -= DigSpead;
            DigGauge.gameObject.GetComponent<Image>().fillAmount = DigGaugeValue;
            if (DigGaugeValue <= 0)
            {
                DigStone.GetComponent<Stone>().DestroyStone();
                Destroy(DigStone);
                DigGaugeValue = 1f;
                DigGauge.gameObject.SetActive(false);
                NowDig = false;
            }
        }
    }

    public void two()
    {
        Text.text = "2";
        SoundController.StartSeFunction();
    }
    public void one()
    {
        Text.text = "1";
        SoundController.StartSeFunction();
    }
    public void Go()
    {
        Text.text = "Start!!";
        SoundController.GoSe();
        StartBool = true;
        ButtonControler.MoveOn();
    }
    public void Del()
    {
        Text.text = "";
    }

    public void TextUpdate(string text)
    {
        Text.text = text;
    }

    public void TimeUpdate(float time)
    {
        Timer.text = time.ToString();
    }

    public void CoinUpdate(int coin)
    {
        Coin.text = coin.ToString();
    }

    public void DigItemUpdate(string ItemName)
    {
        Sprite ItemSprite = Resources.Load<Sprite>(ItemName);
        DigItemSprite.sprite = ItemSprite;
    }

    public void DigGaugeFunction(GameObject Stone,bool PlayerBool, string PlayerItem) 
    {
        if (PlayerItem == "Punch")
        {
            DigSpead = 0.008f;
        }
        else if (PlayerItem == "WoodPic")
        {
            DigSpead = 0.012f;
        }
        else if (PlayerItem == "IronPic")
        {
            DigSpead = 0.018f;
        }
        else if (PlayerItem == "GoldPic")
        {
            DigSpead = 0.022f;
        }
        else if (PlayerItem == "DarkPic")
        {
            DigSpead = 0.03f;
        }
        else if (PlayerItem == "RainbowPic")
        {
            DigSpead = 0.05f;
        }

        if (PlayerBool == true)
        {
            DigGauge.gameObject.SetActive(true);
            NowDig = true;
            DigStone = Stone;
        }
        else if (PlayerBool == false)
        {
            DigGauge.gameObject.SetActive(false);
            DigGaugeValue = 1f;
            NowDig = false;
        }
    }

    public void OnResult(string PlayerItem,int Coin)
    {
        Result.gameObject.SetActive(true);
        ResultDigText.text = "ゲットしたツルハシ\n" + PlayerItem;
        ResultCoinText.text = "獲得したコイン\n" + Coin.ToString();

        if (Coin > 0)
        {
            LeaderBoard["Coin"] = Coin;
            LeaderBoard["Name"] = GetRanking.ReturnPlayerName();
            LeaderBoard.SaveAsync();
        }
    }

    public void PlayerLeftFunction()
    {
        Player.GetComponent<SpriteRenderer>().sprite = PlayerLeft;
    }
    public void PlayerRightFunction()
    {
        Player.GetComponent<SpriteRenderer>().sprite = PlayerRight;
    }

    public void DengerFunction()
    {
        if (DengerBool == false)
        {
            SoundController.DengerSe();
            Denger.gameObject.SetActive(true);
            Invoke("DengerFalseFunction", 2f);
            DengerBool = true;
        }
    }

    public void DengerFalseFunction()
    {
        DengerBool = false;
        Denger.gameObject.SetActive(false);
    }
}
