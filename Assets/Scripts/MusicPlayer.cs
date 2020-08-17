using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        setUpSingletonPattern();
    }

    private void setUpSingletonPattern()
    {
        var musicPlayers = FindObjectsOfType<MusicPlayer>();
        if (musicPlayers.Length != 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
