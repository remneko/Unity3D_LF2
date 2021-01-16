using UnityEngine;
using UnityEngine.UI;

// : 父類別 - 繼承
// 繼承：擁有父類別所有成員

public class HeroPlayer : HeroBase
{
    // 四顆招式按鈕
    private Button btnSkill1;
    private Button btnSkill2;
    private Button btnSkill3;
    private Button btnSkill4;

    private Image[] imgSkills = new Image[4];
    private Image[] imgSkillsCD = new Image[4];
    private Text[] textSkills = new Text[4];

    private Transform target;

    private Joystick joystick;

    private Transform camRoot;

    [Header("移動距離"), Range(0, 10)]
    public float moveDistance;

    // override 複寫 - 可以複寫父類別包含 virtual 的成員
    protected override void Awake()
    {
        base.Awake();

        target = GameObject.Find("目標物件").transform;

        joystick = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();

        camRoot = GameObject.Find("攝影機根物件").transform;

        SetSkillUI();
    }

    protected override void Update()
    {
        base.Update();
        MoveControl();
        UpdateSkillCD();
    }

    private void MoveControl()
    {
        float v = joystick.Vertical;
        float h = joystick.Horizontal;

        target.position = transform.position + camRoot.forward * v * moveDistance / 2 + camRoot.right * h * moveDistance / 2;

        Move(target);
    }

    /// <summary>
    /// 設定四個技能按鈕
    /// </summary>
    private void SetSkillUI()
    {
        // 取得四顆招式按鈕
        btnSkill1 = GameObject.Find("技能 1").GetComponent<Button>();
        btnSkill2 = GameObject.Find("技能 2").GetComponent<Button>();
        btnSkill3 = GameObject.Find("技能 3").GetComponent<Button>();
        btnSkill4 = GameObject.Find("技能 4").GetComponent<Button>();
        // 按鈕 點擊後執行 (方法)
        btnSkill1.onClick.AddListener(Skill1);
        btnSkill2.onClick.AddListener(Skill2);
        btnSkill3.onClick.AddListener(Skill3);
        btnSkill4.onClick.AddListener(Skill4);

        for (int i = 0; i < 4; i++)
        {
            imgSkills[i] = GameObject.Find("技能圖片 " + (i + 1)).GetComponent<Image>();
            imgSkillsCD[i] = GameObject.Find("技能冷卻圖片 " + (i + 1)).GetComponent<Image>();
            textSkills[i] = GameObject.Find("技能冷卻 " + (i + 1)).GetComponent<Text>();
            // 更新技能圖片與冷卻時間
            imgSkills[i].sprite = data.skills[i].image;
            textSkills[i].text = "";
        }
    }

    private void UpdateSkillCD()
    {
        for (int i = 0; i < 4; i++)
        {
            if (skillStart[i])
            {
                textSkills[i].text = (data.skills[i].cd - skillTimer[i]).ToString("F0");

                imgSkillsCD[i].fillAmount = (data.skills[i].cd - skillTimer[i]) / data.skills[i].cd;
            }
            else
            {
                textSkills[i].text = "";
                imgSkillsCD[i].fillAmount = 0;
            }
        }
    }
}
