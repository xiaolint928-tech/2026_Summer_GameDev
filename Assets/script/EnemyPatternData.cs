using System.Collections.Generic;
using UnityEngine;

// 敵の種類を定義する列挙型
public enum Enemy_ { Normal, Speed, Boss, Defense }

[CreateAssetMenu(fileName = "NewEnemyData", menuName = "RhythmGame/DetailedEnemyData")]
public class EnemyPatternData : ScriptableObject
{
    [Header("--- 基本情報 ---")]
    public string enemyName = "名無しの敵";
    public Enemy_ enemyType;
    public int maxHp = 100;

    [Header("--- ビジュアル・演出 ---")]
    public Sprite enemyIcon;          // UI表示用の画像
    public GameObject enemyPrefab;    // 3Dモデルや演出用エフェクト
    public AudioClip spawnSound;       // 出現時のSE

    [Header("--- リズムゲーム設定 ---")]
    public float notesSpeed = 5.0f;    // この敵が投げるノーツの速度
    public int baseScorePerHit = 100; // ノーツ1個あたりの基礎得点

    [Header("ノーツ到達タイミング（ゲーム開始からの秒数リスト）")]
    public List<float> notesTimings = new List<float>();
}