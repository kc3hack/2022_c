using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ItemRegisterScript : MonoBehaviour
{
    //InputFieldを格納するための変数
    InputField infItemName;
    InputField infItemV;
    InputField infItemY;
    InputField infItemM;
    InputField infItemD;
    InputField infItemND;

    //取得したテキストを代入するための変数
    public static string ItemName;
    public static int ItemV;
    public static int ItemY;
    public static int ItemM;
    public static int ItemD;
    public static int ItemND;

    // Start is called before the first frame update
    void Start()
    {
        //InputFieldコンポーネントを取得
        infItemName = GameObject.Find("IFItemName").GetComponent<InputField>();
        infItemV = GameObject.Find("IFValue").GetComponent<InputField>();
        infItemY = GameObject.Find("IFItemYear").GetComponent<InputField>();
        infItemM = GameObject.Find("IFItemMonth").GetComponent<InputField>();
        infItemD = GameObject.Find("IFItemDay").GetComponent<InputField>();
        infItemND = GameObject.Find("IFNotiDay").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetInformation()
    {
        //取得したテキストを代入
        ItemName = infItemName.text;

        //テキストを数値に変換して代入
        ItemV = int.Parse(infItemV.text);
        ItemY = int.Parse(infItemY.text);
        ItemM = int.Parse(infItemM.text);
        ItemD = int.Parse(infItemD.text);
        ItemND = int.Parse(infItemND.text);
    }

    //代入した値を別のスクリプトで使うための設定
    public static string RegIName()
    {
        return ItemName;
    }
    public static int RegIV()
    {
        return ItemV;
    }
    public static int RegIY()
    {
        return ItemY;
    }
    public static int RegIM()
    {
        return ItemM;
    }
    public static int RegID()
    {
        return ItemD;
    }
    public static int RegIND()
    {
        return ItemND;
    }
}
