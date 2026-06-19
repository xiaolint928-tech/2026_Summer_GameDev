using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class JudgeManager_out : MonoBehaviour
{
    public Collider2D ColliderOut_;
    [SerializeField] private GameObject cpsl;
    [SerializeField] private float reTime = 0.01f;
    public bool HitFlgOut = false;
    public Coroutine judgementCoroutine_out;
    [SerializeField] private NotesManager notesmanager;

    void Start()
    {
        if(notesmanager == null)
        {
            notesmanager = GetComponent<NotesManager>();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (judgementCoroutine_out == null)
        //{
        //    judgementCoroutine_out = 
                StartCoroutine(FineJudgment_out(collision));
        //}
    }
    public IEnumerator FineJudgment_out(Collider2D collisions)
    {
        //if (ColliderOut_ == null || collisions == null) yield break;

        if (ColliderOut_.IsTouching(collisions))
        {
            while (collisions != null && ColliderOut_.IsTouching(collisions))
            {
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    for (int i = 0; i > notesmanager.ListNum_; i++)
                    {
                        if (collisions == notesmanager.capsuleclone_l[i])
                        {
                            Destroy(notesmanager.capsuleclone_r[i]);
                        }
                    }
                    HitFlgOut = true;
                    //Debug.Log("Collider   Out collision");
                    judgementCoroutine_out = null;
                    yield break;
                }
                if (collisions == null)
                {
                    Debug.LogError("Collider   Out collision is null");
                    yield break;
                }
                yield return null;
            }
        }
        HitFlgOut = false;
        judgementCoroutine_out = null;
        yield return new WaitForSeconds(reTime);
        //yield break;
    }
}
