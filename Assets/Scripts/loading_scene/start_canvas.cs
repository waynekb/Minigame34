﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class start_canvas : MonoBehaviour
{
    public Button start_game;
    public Button choice_level;
    public Button end_game;

    // Start is called before the first frame update
    void Start()
    {
        start_game.onClick.AddListener(startgame);
        choice_level.onClick.AddListener(choicelevel);
        end_game.onClick.AddListener(endgame);
    }

    void startgame()
    {
        PassSceneName.SceneName = "First";
        SceneManager.LoadScene("loading_sce");
    }
    void choicelevel()
    {
        SceneManager.LoadScene("level_sce");
    }
    void endgame()
    {
        Application.Quit();
    }
}