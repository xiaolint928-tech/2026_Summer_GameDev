using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private EnemyInformation data_;
    public enum EnemyState
    {
        Stay,
        Attack
    }
    public EnemyState state = EnemyState.Stay;//ステータス
    protected Animator animetor;//Animator
    protected int maxHP;
    public int currentHP_;
    protected int maxSTR_;
    public int currentSTR_;
    protected float maxDIF_;
    public float currentDIF_;
    protected Transform enemyPos_;
    public float EnemyNotesInfo;
    protected float timeData_;
    
    protected virtual void Start()
    {
        GameObject enemyObject = GameObject.FindWithTag("Enemy");
        if (enemyObject == null)
        {
            Debug.Log("enemyObjectが入っていない");
        }
        enemyPos_ = enemyObject.transform;//一応敵の一取得
        currentHP_ = data_.EnemyHP;
    }

    // Update is called once per frame
    void Update()
    {

        currentHP_ = data_.EnemyHP;
    }
}
