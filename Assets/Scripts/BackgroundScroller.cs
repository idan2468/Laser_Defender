using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float backgroundScrollSpeed = 2f;
    Material backGround;
    Vector2 offset;
    void Start()
    {
        backGround = GetComponent<Renderer>().material;
        offset = new Vector2(0, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        backGround.mainTextureOffset += Time.deltaTime * offset;
    }
}
