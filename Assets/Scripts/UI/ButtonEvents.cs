using UnityEngine;
using UnityEngine.UI;

public class ButtonEvents : MonoBehaviour
{  
    [SerializeField] Image image;
    [SerializeField] Image image2;
    [SerializeField] Color color;

    [SerializeField] GameObject onPointerEnter;
    [SerializeField] GameObject onPointerExit;
    
    /*public void OnPointerEnter()
    {
        image.color = color;
        image2.color = color;
    }

    public void OnPointerExit()
    {
        image.color = new Color(1, 1, 1);
        image2.color = new Color(1, 1, 1);
    }*/

    public void OnPointerEnter()
    {
        onPointerEnter.SetActive(true);
        onPointerExit.SetActive(false);
    }

    public void OnPointerExit()
    {
        onPointerEnter.SetActive(false);
        onPointerExit.SetActive(true);
    }
}
