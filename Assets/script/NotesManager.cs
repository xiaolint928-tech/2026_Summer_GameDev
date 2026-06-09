using UnityEngine;
using System.Collections;
using NUnit.Framework;
using System.Collections.Generic;

public class NotesManager : MonoBehaviour
{
    public GameObject CapsuleObject;
    public GameObject CapsuleObject_JudgeNull;
    private GameObject FindEnemy;
    private int ListNum_;
    private EnemyInformation enemyData;
    [SerializeField] private float reTime = 0.01f;
    [SerializeField] private float NotesSpeedGain = 0.1f;
    [SerializeField] private float speed_ = 5.0f;
    [SerializeField] private float gain_ = 0.1f;
    public Transform NotesTargetPos;
    public Transform NotesTargetPos2;
    private JudgeManager_in judgeManagerIn;
    private JudgeManager_out judgeManagerOut;
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
        List<GameObject> capsuleclone_l = new List<GameObject>();
        List<GameObject> capsuleclone_r = new List<GameObject>();
        // データが正常に読み込めていない場合は生成処理を行わない
        if (enemyData == null || ListNum_ == 0)
        {
            Debug.LogError("ノーツデータが読み込まれていないため、生成を開始できません。");
            yield break;
        }
        Vector3 spawnPosition_l = new Vector3(-9.16f, -3.52f, -0.02f);
        Vector3 spawnPosition_r = new Vector3(9.16f, -3.52f, -0.02f);
        for (int i = 0; i < ListNum_; i++)
        {
            float TimingData_ = enemyData.categories[0].patterns[0].notes[i].timing;
            //ノーツ生成
            yield return new WaitForSeconds(TimingData_);
            capsuleclone_l.Add(Instantiate(CapsuleObject, spawnPosition_l, Quaternion.identity));
            StartCoroutine(routine_l(i));
            capsuleclone_r.Add(Instantiate(CapsuleObject_JudgeNull, spawnPosition_r, Quaternion.identity));
            StartCoroutine(routine_r(i));
        }
        IEnumerator routine_l(int i)
        {
            //while (capsuleclone_l[i].transform.position.x <= 0.00)
            //{
            //capsuleclone_l[i].transform.position = Vector3.Lerp(capsuleclone_l[i].transform.position, NotesTargetPos.position, Time.deltaTime * speed_);
            //    yield return new WaitForSeconds(reTime);
            //}
            //    Destroy(capsuleclone_l[i]);
            while (capsuleclone_l[i].transform.position.x < 0.01)
            {
                capsuleclone_l[i].transform.position += new Vector3(NotesSpeedGain, 0, 0) * Time.deltaTime * gain_;
            yield return new WaitForSeconds(reTime);
            }
            //StopCoroutine(judgeManagerIn.FineJudgment_in(null));
            //StopCoroutine(judgeManagerOut.FineJudgment_out(null));
            Destroy(capsuleclone_l[i]);
        }
        IEnumerator routine_r(int i)
        {
            //while (capsuleclone_r[i].transform.position.x >= 0.00)
            //{
            //capsuleclone_r[i].transform.position = Vector3.Lerp(capsuleclone_r[i].transform.position, NotesTargetPos2.position, Time.deltaTime * speed_);
            //    yield return new WaitForSeconds(reTime);
            //}
            //    Destroy(capsuleclone_r[i]);
            while (capsuleclone_r[i].transform.position.x > -0.01)
            {
                capsuleclone_r[i].transform.position += new Vector3(-NotesSpeedGain, 0, 0)*Time.deltaTime * gain_;
            yield return new WaitForSeconds(reTime);
            }
            Destroy(capsuleclone_r[i]);
        }
    }
}
