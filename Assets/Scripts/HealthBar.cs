using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private const float OFFSET_FILL_BAR = 0.1f;
    Image myImage;
    // Start is called before the first frame update
    private void Start()
    {
        myImage = gameObject.GetComponent<Image>();
        myImage.fillAmount = 1f;
    }
    public void setHealthBar(float health)
    {
        myImage.fillAmount = health + OFFSET_FILL_BAR >= 1 ? health : health + OFFSET_FILL_BAR;
    }
}
