using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    string ItemName;

    public void DestroyStone()
    {
        float random = Random.Range(1f,100f);
        if (random >= 0 && random <= 80)
        {
            ItemName = "Coin";
        }
        else if (random > 80 && random <= 85)
        {
            ItemName = "Timer";
        }
        else if (random > 85 && random <= 92)
        {
            ItemName = "WoodPic";
        }
        else if (random > 92 && random <= 95)
        {
            ItemName = "IronPic";
        }
        else if (random > 95 && random <= 98)
        {
            ItemName = "GoldPic";
        }
        else if (random > 98 && random <= 99.5)
        {
            ItemName = "DarkPic";
        }
        else if (random > 99.5 && random <= 100)
        {
            ItemName = "RainbowPic";
        }

        GameObject Item = Resources.Load<GameObject>(ItemName);
        GameObject ItemPrefab = Instantiate(Item,this.gameObject.transform.position, Quaternion.identity);
        ItemPrefab.name = ItemName;
    }
}
