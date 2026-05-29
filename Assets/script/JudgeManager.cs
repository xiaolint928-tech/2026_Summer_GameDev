using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class JudgeManager : MonoBehaviour
{
    public Collider2D ColliderOut_;
    public Collider2D ColliderIn_;
    [SerializeField] private GameObject cpsl;
    [SerializeField] private float reTime = 0.01f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FineJudgment());
        IEnumerator FineJudgment()
        {
            bool HitFlgOut = false;
            bool HitFlgIn = false;
            //if (Keyboard.current.enterKey.isPressed)
            //{
                if (ColliderOut_.IsTouching(collision))
                {
                    while (ColliderOut_.IsTouching(collision))
                    {
                        if (Keyboard.current.enterKey.wasPressedThisFrame)
                        {
                HitFlgOut = true;
                            Debug.Log("Collider   Out collision");
                            yield break;
                        }
                        yield return new WaitForSeconds(reTime);
                    }
                }
                else if (ColliderIn_.IsTouching(collision))
                {
                    while (ColliderIn_.IsTouching(collision))
                    {
                        if (Keyboard.current.enterKey.wasPressedThisFrame)
                        {
                    HitFlgIn = true;
                            Debug.Log("Collider   In collision");
                            yield break;
                        }
                        yield return new WaitForSeconds(reTime);
                    }
                }
                yield return new WaitForSeconds(reTime);
            //}

            if(HitFlgOut != true && HitFlgIn != true)
            {
                Debug.Log("miss");
                yield break;
            }
        }
    }
}
