using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour
{

    void Start()
    {
        //C#のあらゆる値は型に紐づけられる
        //コード内に埋め込めることができるデータをリテラルと呼ぶ
        //リテラルの書き方は型によって異なる

        //Debug.Log(1234);//整数リテラル
        //Debug.Log(3.14);//浮動小数点数リテラル
        //Debug.Log(true);//ブールリテラル
        //Debug.Log('A');//文字列リテラル
        //Debug.Log("Hello Unity");//文字リテラル
        //Debug.Log(null);//nullリテラル

        //// リテラル型、単体ではそんなに意識しないかも
        //// 以下のコードの結果は同じ
        //// 厳密には Unity が内部で文字列化して出力するので
        //Debug.Log(1234);
        //Debug.Log("1234");

        //// 違いが出るのは組み合わせたとき
        //// 型によって表現の範囲と操作が異なる
        //Debug.Log(1234 + 5678);
        //Debug.Log("1234" + 5678);

        //// ローカル変数宣言
        //// 変数型 変数名 = 初期値;
        //int a = 1234; // 32ビット符号付き整数型
        //byte b = 100; // 8ビット符号なし整数型
        //sbyte sb = -100; // 8ビット符号付き整数型

        ////リテラルにも違いがあり、整数リテラルの既定値はint型
        //var x = 1234;//ｘ変数はin型
        ////整数リテラルの末尾にＬをつけるとlong型
        //var y = 1234L;//y変数はlong型
        ulong date = 0b01010101_01010101_01010101_01010101_01010101_01010101_01010101_01010101;
        GenerateMap(date);
    }

    private void GenerateMap(ulong date)
    {
        // ランダムで白か黒のセルを8x8のマス目に生成する
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
