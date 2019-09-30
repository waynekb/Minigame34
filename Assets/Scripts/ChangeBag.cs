using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBag : MonoBehaviour
{
    public Button OpenButton;
    public Canvas ChooseCanvas;
    public Canvas ThingsCanvas;
    public Canvas ThingsDetailCanvas;
    public Canvas ExpCanvas;
    public Button ThingsButton;
    public Button ExpButton;
    public Button ExitButton;

    public Button[] ThingsButtonSet = new Button[9];
    public Image[] CardImageSet   = new Image[6];

    public Text DetailText;

    private int[] IsExitThings = new int[9];
    private int[] IsExitCards = new int[6];

    private Sprite[] ImageSpritSet = new Sprite[30];

    void Start()
    {
        ChooseCanvas.enabled = false;
        ThingsCanvas.enabled = false;
        ExpCanvas.enabled = false;
        ThingsDetailCanvas.enabled = false;

        string[] FileName = new string[30];
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
        FileName[12] = "Things/beike";
        FileName[13] = "Things/beike";
        FileName[14] = "Things/beike";
        FileName[15] = "Things/beike";
        FileName[16] = "Things/beike";
        FileName[17] = "Things/beike";

        FileName[18] = "Card/Card1";
        FileName[19] = "Card/Card1_Color";
        FileName[20] = "Card/Card2";
        FileName[21] = "Card/Card2_Color";
        FileName[22] = "Card/Card3";
        FileName[23] = "Card/Card3_Color";
        FileName[24] = "Card/Card4";
        FileName[25] = "Card/Card4_Color";
        FileName[26] = "Card/Card5";
        FileName[27] = "Card/Card5_Color";
        FileName[28] = "Card/Card6";
        FileName[29] = "Card/Card6_Color";

        for (int i = 0; i<30; ++i)
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
        ChooseCanvas.enabled = true;
        ThingsCanvas.enabled = true;
        ExpCanvas.enabled = false;
        ThingsDetailCanvas.enabled = false;

        DisplayThingPanel();
    }

    public void excuteClickExitButton()
    {
        ChooseCanvas.enabled = false;
        ThingsCanvas.enabled = false;
        ExpCanvas.enabled = false;
        ThingsDetailCanvas.enabled = false;
    }

    public void excuteClickThingsButton()
    {
        ChooseCanvas.enabled = true;
        ThingsCanvas.enabled = true;
        ExpCanvas.enabled = false;
        ThingsDetailCanvas.enabled = false;
    }

    public void excuteClickExpButton()
    {
        ChooseCanvas.enabled = true;
        ThingsCanvas.enabled = false;
        ExpCanvas.enabled = true;
        ThingsDetailCanvas.enabled = false;
    }

    public void DisplayThingPanel()
    {
        excuteClickThingsButton();

        IsExitThings[0] = Package.xiaofu;
        IsExitThings[0] = 1;
        IsExitThings[1] = Package.chizi;
        IsExitThings[2] = Package.yueqi;
        IsExitThings[3] = Package.yinyueren;
        IsExitThings[4] = Package.xiangyantou;
        IsExitThings[5] = Package.beike;
        IsExitThings[6] = Package.haiyanglaji;
        IsExitThings[7] = Package.yunduo;
        IsExitThings[8] = Package.huaxiangji;

        for (int i = 0; i<9; ++i)
        {

            if(IsExitThings[i] != 0)
            {
                ThingsButtonSet[i].GetComponent<Image>().sprite = ImageSpritSet[2*i + 1];
            }
            else
            {
                ThingsButtonSet[i].GetComponent<Image>().sprite = ImageSpritSet[2 * i];
            }
        }
    }

    public void DisplayExpPanel()
    {
        excuteClickExpButton();

        IsExitCards[0] = 1;
        IsExitCards[1] = 1;
        IsExitCards[2] = 1;
        IsExitCards[3] = 0;
        IsExitCards[4] = 0;
        IsExitCards[5] = 0;

        for (int i = 0; i < 6; ++i)
        {

            if (IsExitCards[i] != 0)
            {
                CardImageSet[i].GetComponent<Image>().sprite = ImageSpritSet[18+2*i + 1];
            }
            else
            {
                CardImageSet[i].GetComponent<Image>().sprite = ImageSpritSet[18+2*i];
            }
        }
    }

    public void clickThingsButton0()
    {
        if(IsExitThings[0] == 0)
        {
            ThingsDetailCanvas.enabled = false;
        }
        else
        {
            ThingsDetailCanvas.enabled = true;
            DetailText.text = "Myfirst";
            
        }
    }

    public void clickThingsButton1()
    {
        IsExitThings[1] = 1;
        if (IsExitThings[1] == 0)
        {
            ThingsDetailCanvas.enabled = false;
        }
        else
        {
            ThingsDetailCanvas.enabled = true;
            DetailText.text = "第2个按钮";

        }
    }
}
