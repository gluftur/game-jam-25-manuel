using UnityEngine;
using UnityEngine.UI;

public class BackgroundSelector : MonoBehaviour
{
    public static BackgroundSelector Instance;

    [SerializeField]
    Sprite blurryImage, sharpImage;

    [SerializeField]
    SpriteRenderer image;


    public void SetImage(bool useSharpImage)
    {
        if (useSharpImage)
        {
            image.sprite = sharpImage;
        }
        else
        {
            image.sprite = blurryImage;
        }

    }
}
