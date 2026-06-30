using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    // 現在のステージ番号（最初は1）
    public int currentStage = 1;

    void Awake()
    {
        // シーン遷移してもこのオブジェクトを破壊しない仕組み（シングルトン）
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 次のステージへ進む関数
    public void NextStage()
    {
        currentStage++;
        // 同じゲームメインのシーンを再読み込み（または次のシーンをロード）
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}