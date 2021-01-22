using UnityEngine;

public class CameraControl : MonoBehaviour
{
<<<<<<< HEAD
    private Transform player;

    [Header("跟蹤速度"), Range(0, 10)]
    public float speed = 1.5f;
    [Header("上方限制")]
    public float top = -3;
    [Header("下方限制")]
    public float bottom = 5;
    [Header("左方限制")]
    public float left = -14;
    [Header("右方限制")]
    public float right = 27;

    /// <summary>
    /// 遊戲開始執行
    /// </summary>
    private void Start()
    {
        player = GameObject.Find("主角").transform;
    }

    /// <summary>
    /// 延後更新(在Update之後執行:攝影機推薦)
    /// </summary>
=======
    [Header("要跟蹤的物件")]
    public Transform target;
    [Header("跟蹤速度")]
    public float speed = 5;

    private void Track()
    {
        Vector3 posA = target.position;
        Vector3 posB = transform.position;

        posB = Vector3.Lerp(posB, posA, 0.5f * Time.deltaTime * speed);
        transform.position = posB;
    }

>>>>>>> 7ff3192d5379e7d8976115597549cb8ecd17f503
    private void LateUpdate()
    {
        Track();
    }
<<<<<<< HEAD

    /// <summary>
    /// 追蹤玩家座標方法
    /// </summary>
    private void Track()
    {
        Vector3 posplayer = player.position;
        Vector3 posCamera = transform.position;

        posplayer.x = Mathf.Clamp(posplayer.x, left, right);  // 設定左右限制
        posplayer.z = Mathf.Clamp(posplayer.z, top, bottom);  // 設定上下限制

        transform.position = Vector3.Lerp(posCamera, posplayer, speed);   // camera 往 player 前進 0.5f
    }
}

=======
}
>>>>>>> 7ff3192d5379e7d8976115597549cb8ecd17f503
