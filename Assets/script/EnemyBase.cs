using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public EnemyInformation data_;
     public enum EnemyState
    {
        Stay,
        Attack
    }
    public EnemyState state = EnemyState.Stay;//ステータス
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
    protected float timeData_;
    /*やることリスト
     どちらが攻撃(Attack or Stay)
     (敵がAttackならば)ScriptableObjectから読み込んだデータを用いて
    ノーツを生成する(EnemyBase)
    心臓の判定操作、判定からのダメージ計算、伝達(JudgeManager)
    ステータス管理→HPなど(EnemyBase,PlayerManager)
    アニメーション・表示・非表示
    宝箱(報酬)
     */

    protected virtual void Start()
    {
        GameObject enemyObject_mob = GameObject.FindWithTag("Enemy-mob");
        GameObject enemyObject_boss = GameObject.FindWithTag("Enemy-boss");
        if (enemyObject_mob == null)
        {
            Debug.Log("enemyObject_mobが入っていない");
        }
        enemyPos_mob = enemyObject_mob.transform;//一応敵の一取得
        enemyPos_boss = enemyObject_boss.transform;//一応敵の一取得
        currentHP_ = data_.EnemyHP;
        maxHP_ = currentHP_;
        Debug.Log(currentHP_);
        currentSTR_ = data_.EnemySTR;
        maxSTR_ = currentSTR_;
        Debug.Log(currentSTR_);
        currentDIF_ = data_.EnemyDIF;
        maxDIF_ = currentDIF_;
        Debug.Log(currentDIF_);
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }
}
