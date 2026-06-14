using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class JudgeManager_in : MonoBehaviour
{
    public Collider2D ColliderIn_;
    [SerializeField] private GameObject cpsl;
    [SerializeField] private float reTime = 0.01f;
    public bool HitFlgIn = false;
    public JudgeManager_out hitflgout;   

    private void Start()
    {
        if (hitflgout == null)
        {
            hitflgout = GetComponent<JudgeManager_out>();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FineJudgment_in(collision));
    }
    public IEnumerator FineJudgment_in(Collider2D collisions)
    {
        if (ColliderIn_ == null || collisions == null) yield break;

        if (ColliderIn_.IsTouching(collisions))
        {
            while (collisions != null && ColliderIn_.IsTouching(collisions))
            {
                if (Keyboard.current.enterKey.wasPressedThisFrame)
                {
                    HitFlgIn = true;
                    Debug.Log("Collider   In collision");
                    yield break;
                }
                yield return new WaitForSeconds(reTime);
            }

            if (hitflgout != null)
            {
                if (hitflgout.HitFlgOut != true && HitFlgIn != true)
                {
                    Debug.Log("miss");
                    yield break;
                }
            }
        }

        HitFlgIn = false;
        hitflgout.HitFlgOut = false;

        yield return new WaitForSeconds(reTime);
    }
}
