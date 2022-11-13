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
            // ���݂̃Q�[���p�b�h���
            var current = Gamepad.current;

            // �Q�[���p�b�h�ڑ��`�F�b�N
            if (current == null)
                return;

            // ���X�e�B�b�N���͎擾
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
