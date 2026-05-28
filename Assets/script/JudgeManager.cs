using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class JudgeManager : MonoBehaviour
{
    public Collider2D ColliderOut_;
    public Collider2D ColliderIn_;
    [SerializeField] private GameObject cpsl;
    //Collider2D cpslCollider;
    //private void Start()
    //{
    //    cpslCollider = cpsl.GetComponent<CapsuleCollider2D>();
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(FineJudgment());
        IEnumerator FineJudgment()
        {
            if (ColliderOut_.IsTouching(collision))
            {
                Debug.Log("外側のコライダーに入った");
                while (ColliderOut_.IsTouching(collision))
                {
                    if (Keyboard.current.enterKey.wasPressedThisFrame)
                    {
                        Debug.Log("Enterキーが押された。-ColliderOut_");
                        yield return new WaitForSeconds(0.01f);
                    }
                }
            }
            if (ColliderIn_.IsTouching(collision))
            {
                while (ColliderIn_.IsTouching(collision))
                {
                    if (Keyboard.current.enterKey.wasPressedThisFrame)
                    {
                        Debug.Log("Enterキーが押された。-ColliderIn_");
                        yield return new WaitForSeconds(0.01f);
                    }
                }
            }
            else
            {
                Debug.Log("miss");
            }

        }
    }
}
