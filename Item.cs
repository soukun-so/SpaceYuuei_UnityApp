using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string PlayerItem;
    public List<string> ItemList = new List<string>();

    UiController UiController;

    void Start()
    {
        PlayerItem = "Punch";
        ItemList.Clear();
        ItemList.Add("Punch");
        ItemList.Add("WoodPic");
        ItemList.Add("IronPic");
        ItemList.Add("GoldPic");
        ItemList.Add("DarkPic");
        ItemList.Add("RainbowPic");

        UiController = GameObject.Find("UiController").GetComponent<UiController>();
    }

    public void ChangeItem(string ItemName)
    {
        if (ItemList.IndexOf(PlayerItem) < ItemList.IndexOf(ItemName))
        {
            PlayerItem = ItemName;
            UiController.DigItemUpdate(ItemName);
        }
    }

    public string ReturnPlayerItem()
    {
        return PlayerItem;
    }
}
