using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRegisterSceneScript : MonoBehaviour
{
    //ボタンが押されたときに呼び出される関数
    public void Select()
    {
        //ボタンが押されたときに呼び出される操作
        SceneManager.LoadScene("RegisterScene");
    }
}
