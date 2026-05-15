using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NotesManager : MonoBehaviour
{
    [Header("▼ここにプロジェクトビューから敵データをアタッチ")]
    [SerializeField] private EnemyPatternData currentEnemyData;

    [Header("演出・生成用の参照")]
    [SerializeField] private Transform enemySpawnPoint;
    [SerializeField] private Text enemyNameText;

    private int currentHp;

    void Start()
    {
        if(currentEnemyData != null)
        {
            InitializeEnemy();
        }
    }

    void InitializeEnemy()//アタッチされた敵データから、多種多様な設定を自動展開する
    {
        //1. 名前の反映
        if (enemyNameText != null) enemyNameText.text = currentEnemyData.enemyName;

        //2. HPの初期化
        currentHp = currentEnemyData.maxHp;

        //3. 敵プレハブの自動生成
        if(currentEnemyData.enemyPrefab != null)
        {
            Instantiate(currentEnemyData.enemyPrefab, enemySpawnPoint.position, Quaternion.identity);
        }

        //4. 出現音の再生
        if(currentEnemyData.spawnSound != null)
        {
            AudioSource.PlayClipAtPoint(currentEnemyData.spawnSound, Camera.main.transform.position);
        }
        Debug.Log($"敵「{currentEnemyData.enemyName}」出現");
    }

    //判定スクリプトなどからスコアを取得する際に使う関数
    public int GetCurrentEnemyScore()
    {
        return currentEnemyData.baseScorePerHit;
    }
}
