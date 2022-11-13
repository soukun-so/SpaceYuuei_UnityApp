using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Explanation : MonoBehaviour
{
    Transform ExplanationImg;

    int SetumeiInt;

    Sprite setumei1;
    Sprite setumei2;
    Sprite setumei3;
    Sprite setumei4;
    Sprite setumei5;

    SoundController SoundController;
    // Start is called before the first frame update
    void Awake()
    {
        ExplanationImg = GameObject.Find("Canvas").transform.Find("ExplanationImg");
        setumei1 = Resources.Load<Sprite>("setumei");
        setumei2 = Resources.Load<Sprite>("setumei1");
        setumei3 = Resources.Load<Sprite>("setumei2");
        setumei4 = Resources.Load<Sprite>("setumei3");
        setumei5 = Resources.Load<Sprite>("setumei4");
        SoundController = GameObject.Find("SoundController").GetComponent<SoundController>();
    }

    public void ViewExplanation()
    {
        SoundController.ChoiceSe();
        ExplanationImg.gameObject.SetActive(true);
        ExplanationImg.GetComponent<Image>().sprite = setumei1;
        SetumeiInt = 0;
    }

    public void ExplanationNext()
    {
        SoundController.ChoiceSe();
        SetumeiInt += 1;

        if (SetumeiInt == 1)
        {
            ExplanationImg.GetComponent<Image>().sprite = setumei2;
        }
        else if (SetumeiInt == 2)
        {
            ExplanationImg.GetComponent<Image>().sprite = setumei3;
        }
        else if (SetumeiInt == 3)
        {
            ExplanationImg.GetComponent<Image>().sprite = setumei4;
        }
        else if (SetumeiInt == 4)
        {
            ExplanationImg.GetComponent<Image>().sprite = setumei5;
        }
        else if (SetumeiInt >= 5)
        {
            SetumeiInt = 0;
            ExplanationImg.gameObject.SetActive(false);
        }
    }

    public void ExplanationDel()
    {
        SoundController.ChoiceSe();
        ExplanationImg.gameObject.SetActive(false);
    }
}
