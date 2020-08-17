using UnityEngine;

public class LaserDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Laser")
        Destroy(collision.gameObject);
    }
}
