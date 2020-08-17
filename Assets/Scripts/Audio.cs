using UnityEngine;

public class Audio : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioClip deathPlayerAudio;
    [SerializeField] AudioClip deathEnemyAudio;
    [SerializeField] AudioClip enemyShotAudio;
    [SerializeField] float volume = 0.2f;
    [SerializeField] float deathVolume = 1f;

    public void playenemyShotAudio()
    {
        AudioSource.PlayClipAtPoint(enemyShotAudio, Camera.main.transform.position, volume);
    }
    public void playdeathPlayerAudio()
    {
        AudioSource.PlayClipAtPoint(deathPlayerAudio, Camera.main.transform.position, deathVolume);
    }
    public void playdeathEnemyAudio()
    {
        AudioSource.PlayClipAtPoint(deathEnemyAudio, Camera.main.transform.position, volume);
    }
}
