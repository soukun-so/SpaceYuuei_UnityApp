using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonControler : MonoBehaviour
{
    public GameObject Player;

    bool Move;

    public UiController UiController;

    void Awake()
    {
        Player = GameObject.Find("Player");
        UiController = GameObject.Find("UiController").GetComponent<UiController>();
    }

    void Start()
    {
        Move = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Move == true)
        {
            // 現在のゲームパッド情報
            var current = Gamepad.current;

            // ゲームパッド接続チェック
            if (current == null)
                return;

            // 左スティック入力取得
            var leftStickValue = current.leftStick.ReadValue() / 10;

            Player.GetComponent<Player>().MovePlayer(leftStickValue.x, leftStickValue.y);

            if (leftStickValue.x < 0)
            {
                UiController.PlayerLeftFunction();
            }
            else if (leftStickValue.x > 0)
            {
                UiController.PlayerRightFunction();
            }
        }
    }

    public void MoveOn()
    {
        Move = true;
    }

    public void MoveOff()
    {
        Move = false;
    }
}
