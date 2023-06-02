using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{

    void Start()
    {
        //C#�̂�����l�͌^�ɕR�Â�����
        //�R�[�h���ɖ��ߍ��߂邱�Ƃ��ł���f�[�^�����e�����ƌĂ�
        //���e�����̏������͌^�ɂ���ĈقȂ�

        //Debug.Log(1234);//�������e����
        //Debug.Log(3.14);//���������_�����e����
        //Debug.Log(true);//�u�[�����e����
        //Debug.Log('A');//�����񃊃e����
        //Debug.Log("Hello Unity");//�������e����
        //Debug.Log(null);//null���e����

        //// ���e�����^�A�P�̂ł͂���ȂɈӎ����Ȃ�����
        //// �ȉ��̃R�[�h�̌��ʂ͓���
        //// �����ɂ� Unity �������ŕ����񉻂��ďo�͂���̂�
        //Debug.Log(1234);
        //Debug.Log("1234");

        //// �Ⴂ���o��̂͑g�ݍ��킹���Ƃ�
        //// �^�ɂ���ĕ\���͈̔͂Ƒ��삪�قȂ�
        //Debug.Log(1234 + 5678);
        //Debug.Log("1234" + 5678);

        //// ���[�J���ϐ��錾
        //// �ϐ��^ �ϐ��� = �����l;
        //int a = 1234; // 32�r�b�g�����t�������^
        //byte b = 100; // 8�r�b�g�����Ȃ������^
        //sbyte sb = -100; // 8�r�b�g�����t�������^

        ////���e�����ɂ��Ⴂ������A�������e�����̊���l��int�^
        //var x = 1234;//���ϐ���in�^
        ////�������e�����̖����ɂk�������long�^
        //var y = 1234L;//y�ϐ���long�^
        ulong date = 0b01010101_01010101_01010101_01010101_01010101_01010101_01010101_01010101;
        GenerateMap(date);
    }

    private void GenerateMap(ulong date)
    {
        // �����_���Ŕ������̃Z����8x8�̃}�X�ڂɐ�������
        for (var r = 0; r < 8; r++)
        {
            var line = (date >> (r * 8));
            GenerateMap2(line, r);
        }
    }
    private void GenerateMap2(ulong date, float r)
    {
        var x = 0;
        for (var c = 7; c >= 0; c--, x++)
        {
            var cell = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cell.transform.position = new(x * 1.1F, r * 1.1F, 0);
            var a = ((date >> c) & 1) == 0;
            var renderer = cell.GetComponent<Renderer>();
            renderer.material.color =
               a ? Color.white : Color.black;
        }
    }

    void Update()
    {
        
    }
}
