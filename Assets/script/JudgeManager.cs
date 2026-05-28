using UnityEngine;

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
        if (ColliderOut_.IsTouching(collision))
        {
            Debug.Log("外側のコライダーに入った");
        }
        else if (ColliderIn_.IsTouching(collision))
        {
            Debug.Log("内側のコライダーに入った");
        }
        else
        {
            Debug.Log("どちらのコライダーにも入っていない");
        }
    }
}
