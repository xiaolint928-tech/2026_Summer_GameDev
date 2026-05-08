using UnityEngine;
using UnityEngine.EventSystems;

public class MenuController : MonoBehaviour
{
    public GameObject firstButton; // GameStartボタンをアタッチ

    void OnEnable()
    {
        // メニューが表示されたときに最初のボタンを選択状態にする
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}