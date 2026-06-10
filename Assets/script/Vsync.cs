using UnityEngine;

public class Vsync : MonoBehaviour
{
    void Start()
    {
        // 1. V-Syncによる自動固定を無効化する
        QualitySettings.vSyncCount = 0;

        // 2. 目標フレームレートを「60」に固定する（144などに変更も可能）
        Application.targetFrameRate = 60;
    }
}
