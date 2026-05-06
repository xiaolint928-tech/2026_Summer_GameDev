using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class TitleFeadin : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(5, 0, 0);
    public float speed = 2.0f; // フェードインの速さ
    public float smoothness = 0.1f;
    private float alpha = 0f;
    private bool isKeyPressed;
    private MaskableGraphic targetGraphic;
    GameObject TitleHDA;
    void Start()
    {
        targetGraphic = GetComponent<MaskableGraphic>();
        TitleHDA = GameObject.FindGameObjectWithTag("TitleImage(HeartDrumAttack)");
    }
    void Update()
    {
        if (targetGraphic != null)
        {
            Feedin();
        }
        isKeyPressed = Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame;
        if (isKeyPressed == true)
        {
            Feedout();
            //TitleHDA.transform.position = Vector3.Lerp(transform.position, targetPosition, smoothness);
            Debug.Log("いずれかのキーが押されました。(TitleFeedin)");
            Debug.Log(alpha);
        }
    }
    void Feedin()
    {
        if (alpha < 1)
        {
            alpha += Time.deltaTime * speed;
            //Debug.Log(alpha);
            // 色情報を取得して、アルファ値（a）だけを書き換える
            Color color = targetGraphic.color;
            color.a = alpha;
            targetGraphic.color = color;
        }
    }
    void Feedout()
    {
        if (alpha > 0)
        {
            alpha -= Time.deltaTime * speed;
            //Debug.Log(alpha);
            // 色情報を取得して、アルファ値（a）だけを書き換える
            Color color = targetGraphic.color;
            color.a = alpha;
            targetGraphic.color = color;
        }
    }
}