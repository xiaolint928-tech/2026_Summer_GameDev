using UnityEngine;
using UnityEngine.UI; // UI操作に必要
using System.Collections;

public class BlinkText : MonoBehaviour
{
    public float interval = 0.5f;
    private MaskableGraphic targetGraphic; // TextやImageの親クラス

    void Start()
    {
        // Textコンポーネントを取得
        targetGraphic = GetComponent<MaskableGraphic>();

        if (targetGraphic != null)
        {
            StartCoroutine(Blink());
        }
    }

    IEnumerator Blink()
    {
        while (true)
        {
            // 有効・無効を切り替えて点滅
            targetGraphic.enabled = !targetGraphic.enabled;
            yield return new WaitForSeconds(interval);
        }
    }
}