using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [Header("敵人資料")]
    public HeroData data;

    public float rangeAttack; // 攻擊距離
    public float rangeTrack;  // 追蹤距離

    private Rigidbody rig;
    private Animator ani;
    private NavMeshAgent nav;
    private player player;

    private Transform target; // 玩家位置

    private float timer; // 計時器
    private float dis;   // 怪跟人的距離

    private void Awake()
    {
        ani = GetComponent<Animator>();
        rig = GetComponent<Rigidbody>();
        nav = GetComponent<NavMeshAgent>();
        nav.speed = data.speed;

        target = GameObject.Find("主角").transform;
        player = GameObject.Find("主角").GetComponent<player>();
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// 等待
    /// </summary>
    private void Wait()
    {
        ani.SetBool("移動開關", false);
        timer += Time.deltaTime;

        if (timer >= data.attackCD)
        {
            Attack();
        }
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        dis = Vector3.Distance(target.position, transform.position);

        if (ani.GetBool("死亡開關")) return;

        if (target.position.x < transform.position.x)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        if (dis < rangeAttack)
        {
            Wait();
        }
        else if (dis < rangeTrack)
        {
            nav.SetDestination(target.position);
            ani.SetBool("移動開關", true);
        }

    }

    /// <summary>
    /// 普攻
    /// </summary>
    private void Attack()
    {
        timer = 0;
        ani.SetTrigger("攻擊開關");
    }

    /// <summary>
    /// 受傷
    /// </summary>
    private void Hit()
    {
        data.hp -= player.data.attack;
        ani.SetTrigger("被攻擊開關");
        if (data.hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        enabled = false;

        Destroy(gameObject, 1);
    }

    /// <summary>
    /// 碰撞時觸發
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "攻擊範圍")
        {
            Hit();
        }
    }
}