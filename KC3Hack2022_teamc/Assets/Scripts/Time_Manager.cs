using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Time_Manager : MonoBehaviour
{

    public Text text;
    public int nowY;
    public int nowM;
    public int nowD;

    void Start()
    {
        Time_Get();
        Text_Now();
    }

    void Update(){
        Time_Get();
        Text_Now();
    }

    void Time_Get(){
        System.DateTime now = System.DateTime.Now;
        //androidのDataTimeは月/年/日 時間という構造なので欲しい部分だけ分解して取り出す
        string[] arr1 = now.ToString().Split(' '); 
        string[] arr2 = arr1[0].Split('/');
        //Debug.Log(arr2[2] + "/" + arr2[0] + "/" + arr2[1] + " " + arr1[1]);
        nowY = int.Parse(arr2[2]);
        nowM = int.Parse(arr2[0]);
        nowD = int.Parse(arr2[1]);
    }

    void Text_Now(){
        text.text = nowY.ToString("0000") + "/" + nowM.ToString("00") + "/" + nowD.ToString("00");
    }

    public void SettingPush(List<ItemData> itemDatas){
        int ItemY = 2022;
        int ItemM = 3;
        int ItemD = 21;
        
        //　Androidチャンネルの登録
        //LocalPushNotification.RegisterChannel(引数1,引数２,引数３);
        //引数１ Androidで使用するチャンネルID なんでもいい LocalPushNotification.AddSchedule()で使用する
        //引数2　チャンネルの名前　なんでもいい　アプリ名でも入れておく
        //引数3　通知の説明 なんでもいい　自分がわかる用に書いておくもの　
        LocalPushNotification.RegisterChannel("channelId", "PushTest", "通知の説明");

        //通知のクリア
        LocalPushNotification.AllClear();

        // プッシュ通知の登録
        //LocalPushNotification.AddSchedule(引数１,引数2,引数3,引数4,引数5);
        //引数１ プッシュ通知のタイトル
        //引数2　通知メッセージ
        //引数3　表示するバッジの数(バッジ数はiOSのみ適用の様子 Androidで数値を入れても問題無い)
        //引数4　何秒後に表示させるか？
        //引数5　Androidで使用するチャンネルID　「Androidチャンネルの登録」で登録したチャンネルIDと合わせておく
        //注意　iOSは45秒経過後からしかプッシュ通知が表示されない        
        LocalPushNotification.AddSchedule("プッシュ通知一つ目", "45秒経過", 1, new DateTime(ItemY, ItemM, ItemD), "channelId");
        LocalPushNotification.AddSchedule("プッシュ通知二つ目", "60秒経過", 2, new DateTime(2022, 3, 21, 17, 40, 0), "channelId");
        LocalPushNotification.AddSchedule("プッシュ通知三つ目", "75秒経過", 3, new DateTime(2022, 8, 21, 17, 50, 0), "channelId");

        List<ItemData> SetItemList = new List<ItemData>(itemDatas);
        SetItemList.Sort((a,b) => (b.ItemY*365 + b.ItemM*31 + b.ItemD) - (a.ItemY*365 + a.ItemM*31 + a.ItemD));

        string ItemName = "";
        int ItemCount = 0;

        while(SetItemList.Count > 0){
            if(nowY < SetItemList[0].ItemY || nowY == SetItemList[0].ItemY && nowM < SetItemList[0].ItemM || nowY == SetItemList[0].ItemY && nowM == SetItemList[0].ItemM && nowD < SetItemList[0].ItemD){
                ItemName = SetItemList[0].ItemName;
                ItemCount++;
                int i = 0;
                while(i < SetItemList.Count){

                }
            }
            if(ItemCount > 0){
                LocalPushNotification.AddSchedule("賞味期限切れ", ItemName + "など" + ItemCount + "個の賞味期限が切れた食材があります", 1, new DateTime(ItemY, ItemM, ItemD), "channelId");
            }
        }
        
    }

}