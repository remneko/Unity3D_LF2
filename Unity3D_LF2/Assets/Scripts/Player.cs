using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [Header("角色資料")]
    public HeroData data;

    private Rigidbody rig;
    private Animator ani;
    private Joystick joystick;
<<<<<<< HEAD
    private Button normalAttack; // 普攻按鈕

    /*
    protected float[] skillTimer = new float[6];
    protected bool[] skillStart = new bool[6];
    */

    private void Awake()
=======

    protected float[] skillTimer = new float[6];
    protected bool[] skillStart = new bool[6];

    protected virtual void Awake()
>>>>>>> 7ff3192d5379e7d8976115597549cb8ecd17f503
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        joystick = GameObject.Find("虛擬搖桿").GetComponent<Joystick>();
<<<<<<< HEAD

        SetSkillUI();
    }

    private void Update()
    {
        //TimerControl();
        Move();
    }

    /*
    /// <summary>
    /// 技能冷卻
    /// </summary>
    private void TimerControl()
    {
        for (int i = 0; i < 6; i++)
        {
            if (skillStart[i])
            {
                skillTimer[i] += Time.deltaTime;

                // 如果 計時器 >= 冷卻時間 就 歸零並且設定為 尚未開始
                if (skillTimer[i] >= data.skills[i].cd)
                {
                    skillTimer[i] = 0;
                    skillStart[i] = false;
                }
            }
        }
    }
    */

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = joystick.Vertical;    // 垂直
        float h = joystick.Horizontal;  // 水平

        rig.velocity = new Vector3(h * data.speed, rig.velocity.y, v * data.speed);

        ani.SetBool("跑步開關", v != 0 || h != 0);

        if (h > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    /// <summary>
    /// 普攻
    /// </summary>
    private void Attack()
    {
        ani.SetTrigger("攻擊開關");
    }

    /// <summary>
    /// 與 UI同步
    /// </summary>
    private void SetSkillUI()
    {
        normalAttack = GameObject.Find("普攻按鈕").GetComponent<Button>();
        normalAttack.onClick.AddListener(Attack);
=======
    }

    protected virtual void Update()
    {
        TimerControl();
        Move();
    }

    /// <summary>
    /// 技能冷卻
    /// </summary>
    private void TimerControl()
    {
        for (int i = 0; i < 6; i++)
        {
            if (skillStart[i])
            {
                skillTimer[i] += Time.deltaTime;

                // 如果 計時器 >= 冷卻時間 就 歸零並且設定為 尚未開始
                if (skillTimer[i] >= data.skills[i].cd)
                {
                    skillTimer[i] = 0;
                    skillStart[i] = false;
                }
            }
        }
>>>>>>> 7ff3192d5379e7d8976115597549cb8ecd17f503
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = joystick.Vertical;    // 垂直
        float h = joystick.Horizontal;  // 水平

        //rig.velocity = new Vector3(h * data.speed, rig.velocity.y);
        rig.velocity = new Vector3(v * data.speed, rig.velocity.z);

        ani.SetBool("跑步開關", v != 0 || h != 0);

        if (h > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if (h < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }


}
