using System;
using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using static PlayerManager;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public EnemyInformation data_;
    private NotesManager notesManager;
    public EnemyInformation Data => data_;
    public enum EnemyState
    {
        Stay,
        Attack
    }
    public EnemyState Estate = EnemyState.Stay;//ステータス
    protected Animator animetor;//Animator
    protected int maxHP_;
    protected int currentHP_;
    protected int maxSTR_;
    protected int currentSTR_;
    protected float maxDIF_;
    protected float currentDIF_;
    protected Transform enemyPos_mob;
    protected Transform enemyPos_boss;
    protected float EnemyNotesInfo;
    protected float timingData_;
    protected GameObject enemyObject_mob;
    protected GameObject enemyObject_boss;
    protected GameObject PlayerObject;
    [SerializeField] private PlayerManager targetPlayer;
    /*やることリスト
     どちらが攻撃(Attack or Stay)〇
     (敵がAttackならば)ScriptableObjectから読み込んだデータを用いて〇
    ノーツを生成する,移動からの削除まで(NotesManager,EnemyBase)
    心臓の判定操作〇
    判定からのダメージ計算　
    伝達(JudgeManager)
    ステータス管理→HPなど(EnemyBase,PlayerManager)
    アニメーション・表示・非表示
    宝箱(報酬)
     */

    protected virtual void Start()
    {
        // 1. V-Syncによる自動固定を無効化する
        QualitySettings.vSyncCount = 0;

        // 2. 目標フレームレートを「60」に固定する（144などに変更も可能）
        Application.targetFrameRate = 60;

        notesManager = FindAnyObjectByType<NotesManager>();
        if (notesManager == null)
        {
            Debug.LogError("シーン内に NotesManager が見つかりません。");
        }
        if (GameObject.FindWithTag("Enemy-mob")) {
            enemyObject_mob = GameObject.FindWithTag("Enemy-mob");
            enemyPos_mob = enemyObject_mob.transform;//一応敵の一取得
        }
        else if (GameObject.FindWithTag("Enemy-boss"))
        {
            enemyObject_boss = GameObject.FindWithTag("Enemy-boss");
            enemyPos_boss = enemyObject_boss.transform;//一応敵の一取得
        }
        if (GameObject.FindWithTag("Player"))
        {
            PlayerObject = GameObject.FindWithTag("Player");
            targetPlayer = PlayerObject.GetComponent<PlayerManager>();
        }
        currentHP_ = data_.EnemyHP;
        maxHP_ = currentHP_;
        Debug.Log(currentHP_);
        currentSTR_ = data_.EnemySTR;
        maxSTR_ = currentSTR_;
        Debug.Log(currentSTR_);
        currentDIF_ = data_.EnemyDIF;
        maxDIF_ = currentDIF_;
        Debug.Log(currentDIF_);
        if (targetPlayer != null)
        {
            if (targetPlayer.Pstate == PlayerManager.PlayerState.Stay)
            {
                Debug.Log(targetPlayer.Pstate);
            }
            else
            {
                Debug.Log("プレイヤーはAttackになっている。");
            }
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        if (targetPlayer.Pstate == PlayerManager.PlayerState.Attack)
        {
            Estate = EnemyState.Stay;
        }
    }
}
