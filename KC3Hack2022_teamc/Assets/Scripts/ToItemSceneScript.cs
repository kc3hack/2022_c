using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToItemSceneScript : MonoBehaviour
{
    public int itemid;
    public void Select()
    {
        transform.parent = null;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("Itemscene");
    }

}