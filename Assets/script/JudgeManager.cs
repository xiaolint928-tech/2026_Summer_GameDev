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
            if (ColliderOut_.IsTouching(collision))
            {
                while (ColliderOut_.IsTouching(collision))
                {
                    if (Keyboard.current.enterKey.wasPressedThisFrame)
                    {
                        Debug.Log("Enterキーが押された。-ColliderOut_"); 
                        yield break;
                    }
                    yield return new WaitForSeconds(reTime);
                }
            }
            if (ColliderIn_.IsTouching(collision))
            {
                while (ColliderIn_.IsTouching(collision))
                {
                    if (Keyboard.current.enterKey.wasPressedThisFrame)
                    {
                        Debug.Log("Enterキーが押された。-ColliderIn_");
                        yield break;
                    }
                    yield return new WaitForSeconds(reTime);
                }
            }
            else
            {
                Debug.Log("miss");
                yield break;
            }

        }
    }
}
