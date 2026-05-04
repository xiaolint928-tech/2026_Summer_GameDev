using UnityEngine;
using UnityEngine.UI;

public class TitleFeadin : MonoBehaviour
{
    public float speed = 2.0f; // フェードインの速さ
    private float alpha = 0f;
    private MaskableGraphic targetGraphic;
    void Start()
    {
        targetGraphic = GetComponent<MaskableGraphic>();
    }
    void Update()
    {
        if (targetGraphic != null)
        {
            if (alpha < 1)
            {
                alpha += Time.deltaTime * speed;
                //Debug.Log(alpha);
                // 色情報を取得して、アルファ値（a）だけを書き換える
                Color color = targetGraphic.color;
                color.a = alpha;
                targetGraphic.color = color;
            }
        }
    }
}