using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToItemSceneScript : MonoBehaviour
{
    public int itemnom;
    public void Select()
    {
        SceneManager.LoadScene("Itemscene");
    }
}