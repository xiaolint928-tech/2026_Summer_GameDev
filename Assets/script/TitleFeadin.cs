using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class TitleFeadin : MonoBehaviour
{
    public Vector3 targetPosition = new Vector3(950, 750, 0);//(+960,+540,)
    //public float speed = 2.0f; // フェードインの速さ
    public float smoothness = 0.001f;
    public float alphaSpeedFI = 0.01f, alphaSpeedFO = 0.01f;
    private bool FIflag = false, FOflag = false;
    private float alpha = 0f;
    private bool isKeyPressed;
    private MaskableGraphic targetGraphic;
    GameObject TitleHDA;
    void Start()
    {
        targetGraphic = GetComponent<MaskableGraphic>();
        TitleHDA = GameObject.FindGameObjectWithTag("TitleImage(HeartDrumAttack)");
        if (targetGraphic != null)
        {
            StartCoroutine(Feedin());
        }
    }
    void Update()
    {
        isKeyPressed = Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame;
        if (isKeyPressed == true)
        {
            StopAllCoroutines();
            StartCoroutine(HandleSequence());
            Debug.Log("いずれかのキーが押されました。(TitleFeedin)");
            Debug.Log(alpha);
        }
    }
    IEnumerator Feedin()
    {
        while (alpha < 1 && FIflag == false)
        {
            alpha += alphaSpeedFI;
            //Debug.Log(alpha);
            // 色情報を取得して、アルファ値（a）だけを書き換える
            Color color = targetGraphic.color;
            color.a = alpha;
            targetGraphic.color = color;
            yield return null;
        }
        FIflag = true;
    }
    IEnumerator Feedout()
    {
        while (alpha > 0 && FOflag == false)
        {
            alpha -= alphaSpeedFO;
            //Debug.Log(alpha);
            // 色情報を取得して、アルファ値（a）だけを書き換える
            Color color = targetGraphic.color;
            color.a = alpha;
            targetGraphic.color = color;
            yield return null;
        }
        FOflag = true;
    }
    IEnumerator HandleSequence()
    {
        yield return StartCoroutine(Feedout());
        RectTransform rect = GetComponent<RectTransform>();
        rect.anchoredPosition = new Vector2(-14, 269);
        FIflag = false;
        StartCoroutine(Feedin());
    }
}