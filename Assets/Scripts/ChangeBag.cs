using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBag : MonoBehaviour
{
    public Button OpenButton;

    public Canvas ChooseCanvas;
    public Button ThingsButton;
    public Button ExpButton;
    public Button ExitButton;

    public Canvas ThingsCanvas;
    public Canvas ExpCanvas;

    public Image[] ImageSet = new Image[10];
    public Text[] TextSet = new Text[10];

    private Sprite[] ImageSpritSet = new Sprite[20];

    public int[] IsExitImage = new int[10];


    // Start is called before the first frame update
    void Start()
    {
        ChooseCanvas.enabled = false;
        ThingsCanvas.enabled = false;
        ExpCanvas.enabled = false;

        for (int i = 0; i<20; ++i)
        {
            string SpritePath = "Image/" + i;
            ImageSpritSet[i] = Resources.Load(SpritePath, typeof(Sprite)) as Sprite;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void excuteClickOpenButton()
    {
        ChooseCanvas.enabled = true;
        ThingsCanvas.enabled = true;
        ExpCanvas.enabled = false;
    }

    public void excuteClickExitButton()
    {
        ChooseCanvas.enabled = false;
        ThingsCanvas.enabled = false;
        ExpCanvas.enabled = false;
    }

    public void excuteClickThingsButton()
    {
        ChooseCanvas.enabled = true;
        ThingsCanvas.enabled = true;
        ExpCanvas.enabled = false;
    }

    public void excuteClickExpButton()
    {
        ChooseCanvas.enabled = true;
        ThingsCanvas.enabled = false;
        ExpCanvas.enabled = true;
    }

    public void DisplayThingPanel()
    {
        excuteClickThingsButton();

        for (int i = 0; i<10; ++i)
        {
            IsExitImage[i] = 0;

            if(IsExitImage[i] == 1)
            {
                ImageSet[i].GetComponent<Image>().sprite = ImageSpritSet[i];
                TextSet[i].GetComponent<Text>().text = "this is my data";
            }
            else
            {
                ImageSet[i].GetComponent<Image>().sprite = ImageSpritSet[i+10];
                TextSet[i].GetComponent<Text>().text = "";
            }




        }
    }
}
