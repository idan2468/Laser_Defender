using TMPro;
using UnityEngine;

public class DisplayScore : MonoBehaviour
{
    // Start is called before the first frame update
    TextMeshProUGUI scoreText;
    GameSession gameSession;
    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = gameSession.getScore().ToString();
    }
}
