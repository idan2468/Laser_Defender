using UnityEngine;
public class GameSession : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] int score = 0;
    void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    private void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }
    public int getScore()
    {
        return score;
    }
    public void resetGame()
    {
        this.score = 0;
    }

}
