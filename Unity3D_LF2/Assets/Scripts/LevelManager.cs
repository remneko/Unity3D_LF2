using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("生成得物品"), Tooltip("另外一個腳本")]
    public GameObject equipment ;
    [Header("生成得位置")]
    public Transform bagPlace ;
    [Header("全部裝備的圖片")]
    public Sprite[] totalItemSprite ;

    [Header("頭bool")]
    public bool head = false;
    [Header("手bool")]
    public bool hand = false;
    [Header("腳bool")]
    public bool foot = false;

    private Item item;
    private Bag bag;


    private void Start()
    {
        item = FindObjectOfType<Item>();
        bag = FindObjectOfType<Bag>();


        for (int i = 0; i < 20; i++)
        {
            int r = Random.Range(0, totalItemSprite.Length);
            Sprite s = totalItemSprite[r];
            item.icon = s;
            item.count = 1;


            // Bag unit = Instantiate<Bag>(bag, bagPlace);
            // unit.Refresh();
        }
        // Test();
    }
    /*
    public void Test()
    {
        for (int i = 0; i < 20; i++)
        {
            Item item = new Item();
            int r = Random.Range(0, totalItemSprite.Length);
            Sprite s = totalItemSprite[r];
            item.icon = s;
            item.count = 1;
            item.ItemTag = r;

            Bag unit = Instantiate<Bag>(bag, bagPlace);
            unit.Refresh();
        }
    }
    

    /// <summary>
    /// 道具分類
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int SortItem(object a, object b)
    {
        Item i1 = a as item;
        Item i2 = b as item;

        if (i1.ItemTag > i2.ItemTag)
        {
            return 1;
        }
        if (i1.ItemTag < i2.ItemTag)
        {
            return -1;
        }
        else
        {
            return 0;
        }
    }
    */

    /// <summary>
    /// 點擊
    /// </summary>
    public void OnClick()
    {
        bag.OnEquip();
        if (head)
        {
            bag.Refresh();
        }
        else if (hand)
        {
            bag.Refresh();
        }
        else if (foot)
        {
            bag.Refresh();
        }
    }

    /// <summary>
    /// 點頭
    /// </summary>
    public void OnClickHead()
    {
        head = true;
        hand = false;
        foot = false;
    }

    /// <summary>
    /// 點手
    /// </summary>
    public void OnClickHand()
    {
        head = false;
        hand = true;
        foot = false;
    }

    /// <summary>
    /// 點腳
    /// </summary>
    public void OnClickFoot()
    {
        head = false;
        hand = false;
        foot = true;
    }
}