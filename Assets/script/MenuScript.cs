using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    private bool isKeyPressed;
    public float alphaSpeedFI = 0.01f, alphaSpeedFO = 0.01f;
    private bool FIflag = false, FOflag = false;
    private float alpha = 0f;
    private MaskableGraphic targetGraphic;
    void Start()
    {
        targetGraphic = GetComponent<MaskableGraphic>();
        Color color = targetGraphic.color;
        color.a = 0;
        targetGraphic.color = color;
        this.gameObject.SetActive(false);
    }
    void Update()
    {
        //isKeyPressed = Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame;
        //if (isKeyPressed == true)
        //{
            StartCoroutine(Feedin());
    //}

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
    IEnumerator DDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
    }
}
