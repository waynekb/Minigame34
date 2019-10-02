using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBag : MonoBehaviour
{
    public GameObject TotalPanel;
    public GameObject ChoosePanel;
    public GameObject ThingsPanel;
    public GameObject ExperiencePanel;
    public GameObject DetailPanel;

    public Button OpenButton;
    public Button ThingsButton;
    public Button ExpButton;
    public Button ExitButton;
    public Button ExitDetailButton;

    public Button[] ThingsButtonSet = new Button[6];
    public Image[] CardImageSet   = new Image[6];

    public Text DetailText;

    private int[] IsExitThings = new int[9];
    private int[] IsExitCards = new int[6];

    private Sprite[] ImageSpritSet = new Sprite[24];

    void Start()
    {
        TotalPanel.SetActive(false);
        ChoosePanel.SetActive(false);
        ThingsPanel.SetActive(false);
        ExperiencePanel.SetActive(false);
        DetailPanel.SetActive(false);

        string[] FileName = new string[24];
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

        FileName[12] = "Card/Card1";
        FileName[13] = "Card/Card1_Color";
        FileName[14] = "Card/Card2";
        FileName[15] = "Card/Card2_Color";
        FileName[16] = "Card/Card3";
        FileName[17] = "Card/Card3_Color";
        FileName[18] = "Card/Card4";
        FileName[19] = "Card/Card4_Color";
        FileName[20] = "Card/Card5";
        FileName[21] = "Card/Card5_Color";
        FileName[22] = "Card/Card6";
        FileName[23] = "Card/Card6_Color";

        for (int i = 0; i<24; ++i)
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
        ExperiencePanel.SetActive(false);
        DetailPanel.SetActive(false);
    }

    public void DisplayThingPanel()
    {
        TotalPanel.SetActive(true);
        ChoosePanel.SetActive(true);
        ThingsPanel.SetActive(true);
        ExperiencePanel.SetActive(false);
        DetailPanel.SetActive(false);

        IsExitThings[0] = Package.xiaofu;
        IsExitThings[1] = Package.chizi;
        IsExitThings[2] = Package.yueqi;
        IsExitThings[3] = Package.yinyueren;
        IsExitThings[4] = Package.xiangyantou;
        IsExitThings[5] = Package.beike;
        IsExitThings[6] = Package.haiyanglaji;
        IsExitThings[7] = Package.yunduo;
        IsExitThings[8] = Package.huaxiangji;

        for (int i = 0; i<6; ++i)
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
        TotalPanel.SetActive(true);
        ChoosePanel.SetActive(true);
        ThingsPanel.SetActive(false);
        ExperiencePanel.SetActive(true);
        DetailPanel.SetActive(false);

        for (int i = 0; i < 6; ++i)
        {

            if (IsExitCards[i] != 0)
            {
                CardImageSet[i].GetComponent<Image>().sprite = ImageSpritSet[12+2*i + 1];
            }
            else
            {
                CardImageSet[i].GetComponent<Image>().sprite = ImageSpritSet[12+2*i];
            }
        }
    }

    public void clickThingsButton0()
    {
        if(IsExitThings[0] == 0)
        {
            DetailPanel.SetActive(false);
        }
        else
        {
            DetailPanel.SetActive(true);
            DetailText.text = "普通的贝壳，拿起来轻飘飘的。\n砂砾在里面会变成珍珠。\n但也仅仅是普普通通的珍珠而已。";

        }
    }

    public void clickThingsButton1()
    {
        if (IsExitThings[1] == 0)
        {
            DetailPanel.SetActive(false);
        }
        else
        {
            DetailPanel.SetActive(true);
            DetailText.text = "用来量尺寸是否标准的尺子。\n和外表一样循规蹈矩。\n是否暗示着有标准规则的未来？";

        }
    }

    public void clickThingsButton2()
    {
        if (IsExitThings[2] == 0)
        {
            DetailPanel.SetActive(false);
        }
        else
        {
            DetailPanel.SetActive(true);
            DetailText.text = "一把精美的吉他。\n能够演奏出无限可能的音乐。\n任意风格、流派都OK。";

        }
    }

    public void clickThingsButton3()
    {
        if (IsExitThings[3] == 0)
        {
            DetailPanel.SetActive(false);
        }
        else
        {
            DetailPanel.SetActive(true);
            DetailText.text = "凑近能闻到难闻气味的海洋垃圾。\n最好不要碰到，但如果你看到这行字。\n说明前路已经开始发生改变。";

        }
    }

    public void clickThingsButton4()
    {
        if (IsExitThings[4] == 0)
        {
            DetailPanel.SetActive(false);
        }
        else
        {
            DetailPanel.SetActive(true);
            DetailText.text = "不像是应该出现在这里的东西。\n味道也并不好闻。\n一旦尝试可能会被改变命运。";

        }
    }

    public void clickThingsButton5()
    {
        if (IsExitThings[5] == 0)
        {
            DetailPanel.SetActive(false);
        }
        else
        {
            DetailPanel.SetActive(true);
            DetailText.text = "一朵会唱歌的云。\n这不荒唐——因为它也有不想被定义的梦想。\n在触碰的一瞬间，音乐的魅力在此被领悟。";

        }
    }

    public void clickExitDetailButton()
    {
        TotalPanel.SetActive(true);
        ChoosePanel.SetActive(true);
        ThingsPanel.SetActive(true);
        ExperiencePanel.SetActive(false);
        DetailPanel.SetActive(false);
    }
}
