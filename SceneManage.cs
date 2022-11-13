using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneManage : MonoBehaviour
{
    bool GoMainBool = false;
    float GoMainTime = 0;
    Image Panel;
    SoundController SoundController;
    public GameObject DontDestroy;

    void Awake()
    {
        SoundController = GameObject.Find("SoundController").GetComponent<SoundController>();
        if (SceneManager.GetActiveScene().name == "Title")
        {
            DontDestroy = GameObject.Find("BGM");
            DontDestroyOnLoad(DontDestroy);
        }
    }

    void FixedUpdate()
    {
        if (GoMainBool == true)
        {
            GoMainTime += 0.01f;
            Panel.color = new Color(0, 0, 0, GoMainTime);
        }
    }

    public void GoMain()
    {
        SoundController.GoMainSe();
        Panel = GameObject.Find("Panel").GetComponent<Image>();
        GoMainBool = true;
        Invoke("GoMain2", 3f);
    }

    public void GoMain2()
    {
        SceneManager.LoadScene("main");
    }

    public void ReTry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoTitle()
    {
        Destroy(GameObject.Find("BGM"));
        SoundController.ChoiceSe();
        SceneManager.LoadScene("Title");
    }
}
