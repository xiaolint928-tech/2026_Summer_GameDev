using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    private int maxHP_;//max
    private int currentHP_;
    private int maxSP_;//max
    private int currentSP_;
    private int maxSTR_;//max
    private int currentSTR_;
    private int maxDIF_;//max
    private int currentDIF_;

    bool targetflg_;

    public GameObject enemyObj;

    GameObject enemyObject_mob;
    GameObject enemyObject_boss;
    public enum PlayerState
    {
        Stay,
        Attack
    }
    public PlayerState Pstate = PlayerState.Attack;

    protected Animator animator;

    [SerializeField] private EnemyBase targetEnemy;

    void Start()
    {
        EnemyFind_Func();
    }

    void Update()
    {
        EnemyFind_Func();
        if (targetflg_ == true && targetEnemy.Estate == EnemyBase.EnemyState.Attack)
        {
            Pstate = PlayerState.Stay;//敵ステータスがAttackならばこちらのScriptをStayにする。
            //Debug.Log("プレイヤーのステータス: Attack -> Stay  _PlayerManager");
        }
        //else　if(targetflg_ == false)
        //{
        //    Debug.Log("targetflg_がfalse  _PlayerManager");
        //}
        //else
        //{
        //    Debug.Log("プレイヤーのステータス: Attack  _PlayerManager");
        //}
        bool isKeyPressed = Keyboard.current != null && Keyboard.current.nKey.wasPressedThisFrame;
        if (isKeyPressed)
        {
            Instantiate(enemyObj);
        }
    }

    private void EnemyFind_Func()
    {
        if (GameObject.FindWithTag("Enemy-mob"))
        {
            enemyObject_mob = GameObject.FindWithTag("Enemy-mob");
            targetEnemy = enemyObject_mob.GetComponent<EnemyBase>();
        }
        else if (GameObject.FindWithTag("Enemy-boss"))
        {
            enemyObject_boss = GameObject.FindWithTag("Enemy-boss");
            targetEnemy = enemyObject_boss.GetComponent<EnemyBase>();
        }
        //else
        //{
        //    Debug.Log("mobのタグが一つも見つからない  _PlayerManager");
        //}

        if (targetEnemy != null)
        {
            targetflg_ = true;
            //if (targetEnemy.Estate == EnemyBase.EnemyState.Stay)
            //{
            //    Debug.Log("敵のステータス: Stay  _PlayerManager");
            //}
            //else
            //{
            //    Debug.Log("敵のステータス:Attack  _PlayerManager");
            //}
        }
        else
        {
            targetflg_ = false;
        }
    }
}
