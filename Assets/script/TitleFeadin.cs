using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class TitleFeadin : MonoBehaviour
{
    //public Vector3 targetPosition = new Vector3(950, 750, 0);//(+960,+540,)
    //public float speed = 2.0f; // フェードインの速さ
    public float alphaSpeedFI = 0.01f, alphaSpeedFO = 0.01f;
    public float Vec2_x = -14f, Vec2_y = 213;
    private bool FIflag = false, FOflag = false;
    private float alpha = 0f;
    private bool isKeyPressed;
    private MaskableGraphic targetGraphic;
    public GameObject[] UIs;
    public float delaySeconds = 0.5f;
    void Start()
    {
        targetGraphic = GetComponent<MaskableGraphic>();
        //TitleHDA = GameObject.FindGameObjectWithTag("TitleImage(HeartDrumAttack)");
        //ui = GameObject.FindGameObjectsWithTag("Menu-UI");//←のタグを全て取得
        if (targetGraphic != null)
        {
            StartCoroutine(Feedin());
        }
    }
    void Update()
    {
        isKeyPressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        if (isKeyPressed == true)
        {
            StopAllCoroutines();
            StartCoroutine(HandleSequence());
            //for (int i = 0; i < 4; i++)
            //{
            //    UIs[i].gameObject.SetActive(true);
                StartCoroutine(ShowUIsRoutine());
            //}
        }
    }
    IEnumerator Feedin()
    {
        while (alpha < 1 && FIflag == false)
        {
            alpha += alphaSpeedFI;
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
        rect.anchoredPosition = new Vector2(Vec2_x, Vec2_y);
        FIflag = false;
        StartCoroutine(Feedin());

    }
    IEnumerator ShowUIsRoutine()
    {
        // 配列の中身を一つずつ取り出す
        foreach (GameObject ui in UIs)
        {
            if (ui != null)
            {
                ui.SetActive(true); // UIを表示
                                    // ここで音を鳴らす処理を入れると、表示に合わせて音が鳴ります

                yield return new WaitForSeconds(delaySeconds); // 指定した秒数だけ待つ
            }
        }
    }
}