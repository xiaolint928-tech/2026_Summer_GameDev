using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{

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
        if (targetEnemy != null)
        {
            if (targetEnemy.Estate == EnemyBase.EnemyState.Stay)
            {
                Debug.Log(targetEnemy.Estate);
            }
            else
            {
                Debug.Log("敵が見つからない。またはEnemyBaseのスクリプトがついていない。");
            }
        }
    }

    void Update()
    {
        if (targetEnemy.Estate == EnemyBase.EnemyState.Attack)
        {
            Pstate = PlayerState.Stay;
        }

    }
}
