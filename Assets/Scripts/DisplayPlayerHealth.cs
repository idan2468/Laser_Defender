using TMPro;
using UnityEngine;

public class DisplayPlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    Player myPlayer;
    TextMeshProUGUI healthText;
    void Start()
    {
        myPlayer = FindObjectOfType<Player>();
        healthText = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = myPlayer.getHealth().ToString();
    }
}
