using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("武器圖片")]
    public Sprite icon ;
    [Header("武器數量")]
    public int count ;
    [Header("武器分類")]
    public int ItemTag ;
    [Header("是否裝備")]
    public bool Equip = false;
}
