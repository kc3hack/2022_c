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
        if(text != null){
            text.text = nowY.ToString("0000") + "/" + nowM.ToString("00") + "/" + nowD.ToString("00");
        }
    }

    public void SettingPush(List<ItemData> itemDatas){
        
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


        List<ItemData> SetItemList = itemDatas;
        SetItemList.Sort((a,b) => (a.ItemY*365 + a.ItemM*31 + a.ItemD) - (b.ItemY*365 + b.ItemM*31 + b.ItemD));

        int ItemCount = 0;

        while(SetItemList.Count > 0){
            if(nowY < SetItemList[0].ItemY || nowY == SetItemList[0].ItemY && nowM < SetItemList[0].ItemM || nowY == SetItemList[0].ItemY && nowM == SetItemList[0].ItemM && nowD < SetItemList[0].ItemD){
                ItemCount += SetItemList[0].ItemV;
                int i = 1;
                while(i < SetItemList.Count){
                    if (SetItemList[i].ItemY == SetItemList[0].ItemY && SetItemList[i].ItemM == SetItemList[0].ItemM && SetItemList[i].ItemD == SetItemList[0].ItemD){
                        if(SetItemList[i].ItemND != 0){
                            LocalPushNotification.AddSchedule("警告", SetItemList[i].ItemName + "の賞味期限があと" + SetItemList[i].ItemND + "日で切れます", 1, new DateTime(SetItemList[i].ItemY, SetItemList[i].ItemM, SetItemList[i].ItemD).AddDays(-1 * SetItemList[i].ItemND), "channelId");
                        }
                        SetItemList.RemoveAt(i);
                    }else{
                        i++;
                    }
                    ItemCount += SetItemList[i].ItemV;
                }
            }
            if(ItemCount > 0){
                LocalPushNotification.AddSchedule("賞味期限切れ", SetItemList[0].ItemName + "など" + ItemCount + "個の賞味期限が切れた食材があります", 1, new DateTime(SetItemList[0].ItemY, SetItemList[0].ItemM, SetItemList[0].ItemD), "channelId");
            }
            if(SetItemList[0].ItemND != 0){
                LocalPushNotification.AddSchedule("警告", SetItemList[0].ItemName + "の賞味期限があと" + SetItemList[0].ItemND + "日で切れます", 1, new DateTime(SetItemList[0].ItemY, SetItemList[0].ItemM, SetItemList[0].ItemD).AddDays(-1 * SetItemList[0].ItemND), "channelId");
            }
            SetItemList.RemoveAt(0);
        }
        
    }

}