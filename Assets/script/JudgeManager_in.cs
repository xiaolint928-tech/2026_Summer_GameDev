using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class JudgeManager_in : MonoBehaviour
{
    public Collider2D ColliderIn_;
    [SerializeField] private GameObject cpsl;
    [SerializeField] private float reTime = 0.01f;
    public bool HitFlgIn = false;
    public bool MissFlg = false;
    public JudgeManager_out hitflgout;
    [SerializeField] private NotesManager notesmanager;
    public Coroutine judgementCoroutine_in;

    private void Start()
    {
        if (hitflgout == null)
        {
            hitflgout = GetComponent<JudgeManager_out>();
        }
        if (notesmanager == null)
        {
            notesmanager = GetComponent<NotesManager>();
        }
    }
    //private Coroutine judgementCoroutine;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (judgementCoroutine_in == null)
        //{
        //    judgementCoroutine_in = 
                StartCoroutine(FineJudgment_in(collision));
        //}
    }
    public IEnumerator FineJudgment_in(Collider2D collisions)
    {

        if (ColliderIn_ == null || collisions == null) 
        {
            judgementCoroutine_in = null;
            yield break; 
        }

        if (ColliderIn_.IsTouching(collisions))
        {
            while (collisions != null && ColliderIn_.IsTouching(collisions))
            {
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    HitFlgIn = true;
                    judgementCoroutine_in = null;
                    //Debug.Log("Collider   In collision");
                    yield break;
                }
                yield return null;
            }

            if (hitflgout != null)
            {
                if (hitflgout.HitFlgOut != true && HitFlgIn != true)
                {
                    MissFlg = true;
                    //Debug.Log("miss
                    judgementCoroutine_in = null;
                    yield break;
                }
            }
        }

        HitFlgIn = false;
        hitflgout.HitFlgOut = false;
        MissFlg = false;
        judgementCoroutine_in = null;
        yield return new WaitForSeconds(reTime);
        //yield break;
    }
}
