﻿using UnityEngine;

public class HeroBase : MonoBehaviour
{
    [Header("角色資料")]
    public HeroData data;

    /// <summary>
    /// 動畫控制器
    /// </summary>
    private Animator ani;
    private Rigidbody rig;
    /// <summary>
    /// 技能計時器：累加時間用
    /// </summary>
    protected float[] skillTimer = new float[4];
    /// <summary>
    /// 技能是否開始
    /// </summary>
    protected bool[] skillStart = new bool[4];

    // protected 保護 - 允許子類別存取
    // virtual 虛擬 - 允許子類別複寫
    protected virtual void Awake()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        TimerControl();
    }

    private void TimerControl()
    {
        for (int i = 0; i < 4; i++)
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

    public void Move(Transform target)
    {
        Vector3 pos = rig.position;

        rig.MovePosition(target.position);

        transform.LookAt(target);

        ani.SetBool("跑步開關", rig.position != pos);
    }

    public void Skill1()
    {
        // 如果 技能已經開始 就跳出
        if (skillStart[0]) return;
        ani.SetTrigger("第一招");
        skillStart[0] = true;
    }

    public void Skill2()
    {
        if (skillStart[1]) return;
        ani.SetTrigger("第二招");
        skillStart[1] = true;
    }

    public void Skill3()
    {
        if (skillStart[2]) return;
        ani.SetTrigger("第三招");
        skillStart[2] = true;
    }

    public void Skill4()
    {
        if (skillStart[3]) return;
        ani.SetTrigger("大絕");
        skillStart[3] = true;
    }
}
