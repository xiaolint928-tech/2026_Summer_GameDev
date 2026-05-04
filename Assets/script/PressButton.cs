using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PressButton : MonoBehaviour
{
    public float speed = 2.0f; // 点滅の速さ
    public bool isKeyPressed;
    private MaskableGraphic targetGraphic;

    void Start()
    {
        targetGraphic = GetComponent<MaskableGraphic>();
    }

    void Update()
    {
        if (targetGraphic != null)
        {
            // サイン波を使って 0.0 〜 1.0 の間をゆらゆらさせる
            // Time.time はゲーム開始からの経過時間
            float alpha = (Mathf.Sin(Time.time * speed) + 0.5f) / 2.0f;

            // 色情報を取得して、アルファ値（a）だけを書き換える
            Color color = targetGraphic.color;
            color.a = alpha;
            targetGraphic.color = color;
        }
        isKeyPressed = Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame;
        if (isKeyPressed==true)
        {
            Debug.Log("いずれかのキーが押されました。");
        }
    }
}