using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Enemy_about",menuName = "EnemyInfo")]

[System.Serializable]
public class ItemParam
{
    public int id;
    public string itemName;
    public int price;
}

public class EnemyInformation : MonoBehaviour
{
    //“G‚Ì–¼‘O
    public string EnemyName = "–¼–³‚µ‚Ì“G";

    //“G‚ÌHP
    public int EnemyHP;

    //“G‚ÌUŒ‚—Í
    public int EnemySTR;

    //“G‚Ì–hŒä—Í(0%`100%¨0.0`1.0)
    public float EnemyDIF;

    //ƒm[ƒc‚Ì—ˆ‚éƒ^ƒCƒ~ƒ“ƒO‚Ìí—Ş‚Ì”
    public List<ItemParam> itemLists = new List<ItemParam>();

    //ƒm[ƒc‚Ì—ˆ‚éŠÔŠu

}
