using UnityEngine;
using System.Collections;
using UnityEngine.UI; // UIを操作する設定

public class StageUIController : MonoBehaviour
{
    // インスペクターで表示用のUIオブジェクト（画像やTextなど）を登録する
    [SerializeField] private GameObject stageDisplayObject;
    [SerializeField] private Text stageText; // テキストで「STAGE 1」と書き換える場合

    void Start()
    {
        // 1. GameManagerから現在のステージ数を取得して文字を書き換える
        if (GameManager.Instance != null)
        {
            stageText.text = "STAGE " + GameManager.Instance.currentStage;
        }

        // 2. コルーチン（時間差処理）を呼び出して、画像を少し後に消す
        StartCoroutine(HideStageDisplay());
    }

    private IEnumerator HideStageDisplay()
    {
        // UIを表示する
        stageDisplayObject.SetActive(true);

        // 2秒間待つ
        yield return new WaitForSeconds(2.0f);

        // UIを非表示にする
        stageDisplayObject.SetActive(false);
    }
}