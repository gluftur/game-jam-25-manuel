using TMPro;
using UnityEngine;

public class UVLetters : MonoBehaviour
{
    [SerializeField]
    TextMeshPro text;
    void OnTriggerEnter(Collider other)
    {
        text.enabled = true;
    }
    void OnTriggerExit(Collider other)
    {
        text.enabled = false;
    }
}
