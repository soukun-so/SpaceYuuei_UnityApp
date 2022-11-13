using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class GetRanking : MonoBehaviour
{
    NCMBQuery<NCMBObject> query = new NCMBQuery<NCMBObject>("SpaceDigLeaderBoard");

    List<int> Ranking = new List<int>();
    List<string> RankingName = new List<string>();

    Transform RankingContent;
    Transform RankingImg;
    GameObject RankingText;

    public InputField inputField;
    public static string PlayerName;

    bool View = false;

    SoundController SoundController;
    void Awake()
    {
        RankingImg = GameObject.Find("Canvas").transform.Find("RankingImg");
        RankingText = Resources.Load<GameObject>("RankingText");
        inputField = inputField.GetComponent<InputField>();
        RankingContent = GameObject.Find("Canvas").transform.Find("RankingImg/ScrollView/Viewport/Content");
        SoundController = GameObject.Find("SoundController").GetComponent<SoundController>();
    }


    public void ViewRanking()
    {
        RankingImg.gameObject.SetActive(true);
        SoundController.ChoiceSe();

        if (View == false)
        {
            query.OrderByDescending("Coin");
            query.Limit = 20;
            query.FindAsync((List<NCMBObject> objList, NCMBException e) =>
            {
                if (e != null)
                {
            //検索失敗時の処理
            }   
                else
                {
                    foreach (NCMBObject obj in objList)
                    {
                        int Coin = System.Convert.ToInt32(obj["Coin"]);
                        string Name = System.Convert.ToString(obj["Name"]);
                        Ranking.Add(Coin);
                        RankingName.Add(Name);
                    }
                }
            });

            View = true;
            Invoke("ViewRanking2", 2f);
        }
    }

    public void InputText()
    {
        //テキストにinputFieldの内容を反映
        PlayerName = inputField.text;

    }

    public static string ReturnPlayerName()
    {

        return PlayerName;
    }

    public void DelRanking()
    {
        RankingImg.gameObject.SetActive(false);
        SoundController.ChoiceSe();
    }

    public void ViewRanking2()
    {
        for (int i = 0; i < Ranking.Count; i++)
        {
            GameObject RankingTextPrefab = Instantiate(RankingText);
            RankingTextPrefab.transform.SetParent(RankingContent);
            RankingTextPrefab.GetComponent<Text>().text = "#" + (i + 1) + "\n" + RankingName[i] + "/" + Ranking[i] + "Coin";
        }
    }
}
