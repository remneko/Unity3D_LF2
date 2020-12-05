using UnityEngine;
using UnityEngine.UI;

public class Bag : MonoBehaviour
{
    [Header("裝備圖片")]
    public Image image;
    [Header("數量")]
    public Text countText;
    [Header("是否裝備文字")]
    public Text equipText;

    private Item item;

    /// <summary>
    /// 裝備圖示更新
    /// </summary>
    public void Refresh()
    {
        image.sprite = item.icon;
        countText.text = item.count.ToString();
        equipText.text = "";
    }

    /// <summary>
    /// 裝備技能
    /// </summary>
    public void OnEquip()
    {
        item.Equip = true;
        RefreshEquip();
    }

    /// <summary>
    /// 更新裝備資訊
    /// </summary>
    public void RefreshEquip()
    {
        if (item.Equip)
        {

            equipText.text = "裝備中";
        }
        else
        {
            equipText.text = "";
        }
    }
}
