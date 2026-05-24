using UnityEngine;
using System.Collections;

public class NotesManager : MonoBehaviour
{
    public GameObject CapsuleObject;
    private GameObject FindEnemy;
    private GameObject capsuleclone_l;
    private GameObject capsuleclone_r;
    private int ListNum_;
    private EnemyInformation enemyData;
    [SerializeField] private float reTime = 0.01f;
    [SerializeField] private float NotesSpeedGain = 0.01f;
    void Start()
    {
        if (GameObject.FindWithTag("Enemy-mob"))
        {
            FindEnemy = GameObject.FindWithTag("Enemy-mob");
        }
        else if (GameObject.FindWithTag("Enemy-boss"))
        {
            FindEnemy = GameObject.FindWithTag("Enemy-boss");
        }
        else
        {
            Debug.LogWarning("敵オブジェクト（Enemy-mob / Enemy-boss）が見つかりません。");
            return;
        }
        if (FindEnemy.TryGetComponent<EnemyBase>(out EnemyBase enemy))
        {
            enemyData = enemy.data_;
            //Debug.Log($"検知したオブジェクトのデータ: {enemyData.EnemyName}");
            if (enemyData != null && enemyData.categories.Count > 0 &&
                enemyData.categories[0].patterns.Count > 0 &&
                enemyData.categories[0].patterns[0].notes.Count > 0)
            {
                float FirstTiming = enemyData.categories[0].patterns[0].notes[0].timing;
                Debug.Log("最初のノーツのタイミング" + FirstTiming);
                ListNum_ = enemyData.categories[0].patterns[0].notes.Count;
                //Debug.Log(ListNum_);
            }
            else
            {
                Debug.LogError("EnemyInformationのデータ構造が空、または不正です。");
            }
        }
    }
    public IEnumerator CapsuleInst()
    {
        // データが正常に読み込めていない場合は生成処理を行わない
        if (enemyData == null || ListNum_ == 0)
        {
            Debug.LogError("ノーツデータが読み込まれていないため、生成を開始できません。");
            yield break;
        }
        Vector3 spawnPosition_l = new Vector3(-9.16f, -3.52f, -0.02f);
        Vector3 spawnPosition_r = new Vector3(9.08f, -3.52f, -0.02f);
        for (int i = 0; i < ListNum_; i++)
        {
            float TimingData_ = enemyData.categories[0].patterns[0].notes[i].timing;
            //ノーツ生成
            capsuleclone_l = Instantiate(CapsuleObject, spawnPosition_l, Quaternion.identity);
            StartCoroutine(routine_l());
            capsuleclone_r = Instantiate(CapsuleObject, spawnPosition_r, Quaternion.identity);
            StartCoroutine(routine_r());
            yield return new WaitForSeconds(TimingData_);
        }
    }
    private IEnumerator routine_l()
    {
        Vector3 spawnPosition_l = new Vector3(-9.16f, -3.52f, -0.02f);
        while (spawnPosition_l.x < 0.00)
        {
            spawnPosition_l.x += NotesSpeedGain;
            //transform.position = spawnPosition_l;
            yield return new WaitForSeconds(reTime);
        }
        Destroy(capsuleclone_l);
    }
    private IEnumerator routine_r()
    {
        Vector3 spawnPosition_r = new Vector3(9.08f, -3.52f, -0.02f);
        while (spawnPosition_r.x > 0.00)
        {
            spawnPosition_r.x -= NotesSpeedGain * Time.deltaTime;
            //transform.position = spawnPosition_r;
            yield return new WaitForSeconds(reTime);
        }
        Destroy(capsuleclone_r);
    }
}
