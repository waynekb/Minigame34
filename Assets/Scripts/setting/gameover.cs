using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject setbtn_obj = GameObject.Find("Canvas/gameover");
        Button setbtn = (Button)setbtn_obj.GetComponent<Button>();
        setbtn.onClick.AddListener(ret_start);
    }

    // Update is called once per frame
    void ret_start()
    {
        SceneManager.LoadScene("Start");
    }
}
