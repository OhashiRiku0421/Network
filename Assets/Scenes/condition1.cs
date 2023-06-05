using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class condition : MonoBehaviour
{
    private byte _player = 0b0000_0000;
    private byte _poison = 0b0000_0001;
    private byte _poison2 = 0b0000_0010;
    private byte _sleep = 0b0000_0100;
    private byte _silence = 0b0000_1000;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            _player |= _poison;

            Debug.Log("_poison => Condition" + Convert.ToString(_player, 2).PadLeft(4, '0'));
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            _player &= _poison = (byte)~_poison;
            Debug.Log("_poison => Condition" + Convert.ToString(_player, 2).PadLeft(4, '0'));
        }
    }
}
