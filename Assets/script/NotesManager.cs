using UnityEngine;

public class NotesManager : MonoBehaviour
{
    public GameObject CapsuleObject;

    public void CapsuleInst(Vector2 position)
    {
        //ÉmÅ[Écê∂ê¨
        Instantiate(CapsuleObject, position, Quaternion.identity);

    }
}
