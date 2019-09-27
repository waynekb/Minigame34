using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenBag: MonoBehaviour
{
    Canvas BagCanvas;
    Button OpenBagButton;

    void Start()
    {
        BagCanvas     = GameObject.Find("BagCanvas").GetComponent<Canvas>();
        OpenBagButton = GameObject.Find("OpenBagButton").GetComponent<Button>();

        BagCanvas.enabled = false;
        OpenBagButton.enabled = true;

        OpenBagButton.onClick.AddListener(openBagCanves);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void openBagCanves()
    {
        BagCanvas.enabled = true;
    }

}
