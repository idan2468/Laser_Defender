using TMPro;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    [SerializeField] float DISAPPEAR_SPEED = 0.7f;
    [SerializeField] float SCALE_SPEED = 1f;
    private float flySpeedY = 1f;
    private float flySpeedX;

    // Start is called before the first frame update
    TextMeshPro myTextComp;
    private float rotationSpeed = 10f;
    private float damage = 0f;
    [SerializeField]private float minFlySpeedY;
    [SerializeField] private float maxFlySpeedY;
    [SerializeField] private float minFlySpeedX = -1;
    [SerializeField] private float maxFlySpeedX = 1;

    void Start()
    {
        myTextComp = gameObject.GetComponent<TextMeshPro>();
        rotationSpeed = Random.Range(0, 100) < 50 ? rotationSpeed * -1 : rotationSpeed;
        flySpeedY = Random.Range(minFlySpeedY, maxFlySpeedY);
        flySpeedX = Random.Range(minFlySpeedX ,maxFlySpeedX);

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(flySpeedX, flySpeedY) * Time.deltaTime;
        myTextComp.alpha -= DISAPPEAR_SPEED * Time.deltaTime;
        if(myTextComp.alpha > .5f)
        {
            gameObject.transform.localScale += Vector3.one * SCALE_SPEED * Time.deltaTime;
        }
        else
        {
            gameObject.transform.localScale -= Vector3.one * 1f * Time.deltaTime;
        }
        gameObject.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        if (myTextComp.alpha <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void setDamage(float damage)
    {
        gameObject.GetComponent<TextMeshPro>().SetText(damage.ToString());
    }
}
