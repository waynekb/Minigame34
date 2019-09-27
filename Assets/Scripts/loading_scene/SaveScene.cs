using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class SaveScene : MonoBehaviour
{
    private Button SaveButton;
    // Start is called before the first frame update
    void Start()
    {
       
        SaveButton.onClick.AddListener(Save);
    }

    void Save()
    {
        PlayerPrefs.SetString("SaveScene_name", SceneManager.GetActiveScene().name);
    }
}
