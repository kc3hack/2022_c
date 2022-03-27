using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MemoData
{
    public string MemoTitle;
    public string Memo;
}



[System.Serializable]
public class MemoSaveJson : MonoBehaviour
{
    public SaveJson save;
    public Time_Manager time;
    //InputFieldを格納するための変数
    InputField infMemoTitle;
    InputField infMemo;

    //取得したテキストを代入するための変数
    public static string MemoTitle;
    public static string Memo;

    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        infMemoTitle = GameObject.Find("IFMemoTitle").GetComponent<InputField>();
        infMemo = GameObject.Find("IFMemo").GetComponent<InputField>();
    }

    public void select()
    {
        //取得したテキストを代入
        MemoTitle = infMemoTitle.text;
        Memo = infMemo.text;

        MemoData MemoDataWrap = new MemoData();
        MemoDataWrap.MemoTitle = MemoTitle;
        MemoDataWrap.Memo = Memo;
        save.SaveM(MemoDataWrap);
    }
}
