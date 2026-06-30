using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Player_about/PlayerInfo")]

//[System.Serializable]
//public class ItemParam
//{
//    public int id;
//    public string itemName;
//    public int price;
//}

public class PlayerInfomation : ScriptableObject
{
    public int PlayerID;
    //“G‚Ì–¼‘O
    public string PlayerName = "–¼–³‚µ‚ÌƒvƒŒƒCƒ„[";

    //“G‚ÌHP
    public int PlayerHP;

    //“G‚ÌUŒ‚—Í
    public int PLayerSTR;

    //“G‚Ì–hŒä—Í(0%`100%¨0.0`1.0)
    public float PlayerDIF;

    public List<SkillsCategory> skills = new List<SkillsCategory>();

}
