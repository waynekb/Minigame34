using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBag : MonoBehaviour
{
    public GameObject TotalPanel;
    public GameObject ChoosePanel;
    public GameObject ThingsPanel;
    public GameObject ThingsDetailPanel;
    public GameObject ExperiencePanel;

    public Button OpenButton;
    public Button ThingsButton;
    public Button ExpButton;
    public Button ExitButton;

    public Button[] ThingsButtonSet = new Button[6];
    public Image[] CardImageSet   = new Image[6];

    private int[] IsExitThings = new int[6];
    private int[] IsExitCards = new int[6];

    private Sprite[] ImageSpritSet = new Sprite[31];

    void Start()
    {
        TotalPanel.SetActive(false);
        ChoosePanel.SetActive(false);
        ThingsPanel.SetActive(false);
        ThingsDetailPanel.SetActive(false);
        ExperiencePanel.SetActive(false);

        string[] FileName = new string[31];
        FileName[0] = "Things/beike";
        FileName[1] = "Things/beike_color";
        FileName[2] = "Things/chizi";
        FileName[3] = "Things/chizi_color";
        FileName[4] = "Things/jita";
        FileName[5] = "Things/jita_color";
        FileName[6] = "Things/laji";
        FileName[7] = "Things/laji_color";
        FileName[8] = "Things/xiangyan";
        FileName[9] = "Things/xiangyan_color";
        FileName[10] = "Things/yundong";
        FileName[11] = "Things/yunduo_color";

        FileName[12] = "Things/beiketext";
        FileName[13] = "Things/chizitext";
        FileName[14] = "Things/jitatexdt";
        FileName[15] = "Things/lajitext";
        FileName[16] = "Things/xiangyantext";
        FileName[17] = "Things/yunduotext";
        FileName[18] = "Things/wenhao";

        FileName[19] = "Card/Card1";
        FileName[20] = "Card/Card1_Color";
        FileName[21] = "Card/Card2";
        FileName[22] = "Card/Card2_Color";
        FileName[23] = "Card/Card3";
        FileName[24] = "Card/Card3_Color";
        FileName[25] = "Card/Card4";
        FileName[26] = "Card/Card4_Color";
        FileName[27] = "Card/Card5";
        FileName[28] = "Card/Card5_Color";
        FileName[29] = "Card/Card6";
        FileName[30] = "Card/Card6_Color";

        for (int i = 0; i<31; ++i)
        {
            string SpritePath = "Image/" + FileName[i];
            ImageSpritSet[i] = Resources.Load(SpritePath, typeof(Sprite)) as Sprite;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void excuteClickOpenButton()
    {
        DisplayThingPanel();
    }

    public void excuteClickExitButton()
    {
        TotalPanel.SetActive(false);
        ChoosePanel.SetActive(false);
        ThingsPanel.SetActive(false);
        ThingsDetailPanel.SetActive(false);
        ExperiencePanel.SetActive(false);

    }

    public void DisplayThingPanel()
    {
        TotalPanel.SetActive(true);
        ChoosePanel.SetActive(true);
        ThingsPanel.SetActive(true);
        ThingsDetailPanel.SetActive(true);
        ExperiencePanel.SetActive(false);

        IsExitThings[0] = Package.beike;
        IsExitThings[1] = Package.chizi;
        IsExitThings[2] = Package.yueqi;
        IsExitThings[3] = Package.haiyanglaji;
        IsExitThings[4] = Package.xiangyantou;
        IsExitThings[5] = Package.yunduo;

        for (int i = 0; i<6; ++i)
        {
            IsExitThings[i] = 2;
        }

        for (int i = 0; i<6; ++i)
        {

            if(IsExitThings[i] != 0)
            {
                ThingsButtonSet[i].GetComponent<Image>().sprite = ImageSpritSet[2*i + 1];
                ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[12 + i];

            }
            else
            {
                ThingsButtonSet[i].GetComponent<Image>().sprite = ImageSpritSet[2 * i];
                ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[18];
            }
        }

    }

    public void DisplayExpPanel()
    {
        TotalPanel.SetActive(true);
        ChoosePanel.SetActive(true);
        ThingsPanel.SetActive(false);
        ThingsDetailPanel.SetActive(false);
        ExperiencePanel.SetActive(true);

        for (int i = 0; i < 6; ++i)
        {

            if (IsExitCards[i] != 0)
            {
                CardImageSet[i].GetComponent<Image>().sprite = ImageSpritSet[19+2*i + 1];
            }
            else
            {
                CardImageSet[i].GetComponent<Image>().sprite = ImageSpritSet[19+2*i];
            }
        }
    }

    public void clickThingsButton0()
    {
        if(IsExitThings[0] == 0)
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[18];
        }
        else
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[12];
        }
    }

    public void clickThingsButton1()
    {
        if (IsExitThings[0] == 0)
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[18];
        }
        else
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[13];
        }
    }

    public void clickThingsButton2()
    {
        if (IsExitThings[0] == 0)
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[18];
        }
        else
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[14];
        }
    }

    public void clickThingsButton3()
    {
        if (IsExitThings[0] == 0)
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[18];
        }
        else
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[15];
        }
    }

    public void clickThingsButton4()
    {
        if (IsExitThings[0] == 0)
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[18];
        }
        else
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[16];
        }
    }

    public void clickThingsButton5()
    {
        if (IsExitThings[0] == 0)
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[18];
        }
        else
        {
            ThingsDetailPanel.GetComponent<Image>().sprite = ImageSpritSet[17];
        }
    }

    public void clickExitDetailButton()
    {
        TotalPanel.SetActive(true);
        ChoosePanel.SetActive(true);
        ChoosePanel.SetActive(true);
        ThingsPanel.SetActive(true);
        ThingsDetailPanel.SetActive(false);
        ExperiencePanel.SetActive(false);
    }
}
