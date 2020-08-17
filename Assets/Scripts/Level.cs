using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    const int START_MENU_SCENE_INDEX = 0;
    const int GAME_SCREEN_SCENE_INDEX = 1;
    const int GAME_OVER_SCENE_INDEX = 2;
    [SerializeField] float loadDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void loadStartMenuScene()
    {
        SceneManager.LoadScene(START_MENU_SCENE_INDEX);
    }
    public void loadGameOverScene()
    {
        StartCoroutine(loadWithDelay(GAME_OVER_SCENE_INDEX));
    }

    IEnumerator loadWithDelay(int sceneIndex)
    {
        yield return new WaitForSeconds(loadDelay);
        SceneManager.LoadScene(sceneIndex);
    }

    public void loadGameScreenScene()
    {
        SceneManager.LoadScene(GAME_SCREEN_SCENE_INDEX);
        FindObjectOfType<GameSession>().resetGame();
    }
}
