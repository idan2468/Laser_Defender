using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 10f;
    private float xMax, xMin, yMax, yMin;
    [SerializeField] private float padding = 5f;
    [SerializeField] float health = 100f;
    [Header("Laser Shot Settings")]
    [SerializeField] float laserFireDelay = 1f;
    [SerializeField] GameObject laserShot = null;
    [SerializeField] private Vector3 paddingLaserShot;
    [SerializeField] float laserSpeed = 10f;
    [Header("Other")]
    [SerializeField] GameObject damagePopup;
    private const float paddingForPopup = 1.5f;
    Coroutine fireCorutineHandler;
    Audio audioHandler;

    // Start is called before the first frame update
    void Start()
    {
        calculateBounderis();
        audioHandler = FindObjectOfType<Audio>();
    }

    private void calculateBounderis()
    {
        var maxVector = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        var minVector = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        xMin = minVector.x + padding;
        yMin = minVector.y + padding;
        xMax = maxVector.x - padding;
        yMax = maxVector.y - padding;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
        fireLaser();
    }

    private void fireLaser()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fireCorutineHandler = StartCoroutine(fireCourutine());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(fireCorutineHandler);
        }
    }

    private void movePlayer()
    {
        var newPosX = gameObject.transform.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var newPosY = gameObject.transform.position.y + Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        newPosX = Mathf.Clamp(newPosX, xMin, xMax);
        newPosY = Mathf.Clamp(newPosY, yMin, yMax);
        gameObject.transform.position = new Vector3(newPosX, newPosY, gameObject.transform.position.z);
    }
    IEnumerator fireCourutine()
    {
        while (true)
        {
            GameObject myShot = Instantiate(laserShot, gameObject.transform.position + paddingLaserShot, Quaternion.identity) as GameObject;
            myShot.GetComponent<Rigidbody2D>().velocity = new Vector2(0, laserSpeed);
            yield return new WaitForSeconds(laserFireDelay);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var damage = collision.GetComponent<Damage>();
        if (!damage) { return; }
        handleHit(damage);
    }

    private void handleHit(Damage damage)
    {   var currDamage = damage.getDamage();
        this.health -= currDamage;
        FindObjectOfType<HealthBar>().setHealthBar(this.health/100f);
        showDamagePopUp(currDamage);
        damage.hit();
        if (this.health <= 0)
        {
            this.health = 0;
            audioHandler.playdeathPlayerAudio();
            Destroy(gameObject);
            FindObjectOfType<Level>().loadGameOverScene();
        }
    }
    public float getHealth()
    {
        return health;
    }
    private void showDamagePopUp(float damage)
    {
        var damagePopUpObj = Instantiate(damagePopup, gameObject.transform.position + new Vector3(0, paddingForPopup, 0), Quaternion.identity);
        if (damagePopUpObj)
        {
            var newDamagePopUp = damagePopUpObj.GetComponent<DamagePopUp>();
            newDamagePopUp.setDamage(damage);
        }
    }
}
