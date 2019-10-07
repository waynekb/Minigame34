using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingbutton : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        GameObject setbtn_obj = GameObject.Find("Canvas/ButtonSetting");
        Button setbtn = (Button)setbtn_obj.GetComponent<Button>();
        setbtn.onClick.AddListener(ret_start);

    }

    void ret_start()
    {
        SceneManager.LoadScene("Start");
    }
}
