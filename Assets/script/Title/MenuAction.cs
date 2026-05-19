using UnityEngine;
using UnityEngine.SceneManagement;//シーン移動に必要

public class MenuAction : MonoBehaviour
{
    //引数でシーン名を指定できるようになる
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Application.Quit();
        // Unityエディタの再生モードを停止させる（開発中の確認用）
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
