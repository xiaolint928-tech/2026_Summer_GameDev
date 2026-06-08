using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class JudgeManager_out : MonoBehaviour
{
    public Collider2D ColliderOut_;
    [SerializeField] private GameObject cpsl;
    [SerializeField] private float reTime = 0.01f;
    public         bool HitFlgOut = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FineJudgment_out(collision));
    }
    public IEnumerator FineJudgment_out(Collider2D collisions)
    {
        if (ColliderOut_ == null || collisions == null) yield break;
        //if (Keyboard.current.enterKey.isPressed)
        //{
        if (ColliderOut_.IsTouching(collisions))
                {
                    while (collisions != null && ColliderOut_.IsTouching(collisions))
                    {
                        if (Keyboard.current.enterKey.wasPressedThisFrame)
                        {
                            HitFlgOut = true;
                            Debug.Log("Collider   Out collision");
                            yield break;
                        }
                        if (collisions == null)
                        {
                            Debug.Log("Collider   Out collision is null");
                            yield break;
                        }
                        yield return new WaitForSeconds(reTime);
                    }
                }
                yield return new WaitForSeconds(reTime);
            //}

            HitFlgOut = false;
        }
}
