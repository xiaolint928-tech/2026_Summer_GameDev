using UnityEngine;
using UnityEngine.InputSystem;

public class PPB_soundshot : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip soundEffect;
    private bool isKeyPressed;
    void Start()
    {
        
    }

    void Update()
    {
        isKeyPressed = Keyboard.current != null && Keyboard.current.anyKey.wasPressedThisFrame;
        if (isKeyPressed==true)
        {
            audioSource.PlayOneShot(soundEffect);
        }
    }
}
