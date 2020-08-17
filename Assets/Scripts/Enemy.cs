using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy States")]
    [SerializeField] int score;
    [SerializeField] float health = 100f;
    [Header("Shot Settings")]
    float shotCounter;
    [SerializeField] LaserConfig myLaserConfig = null;
    [Header("Explosion")]
    private const float TIME_OF_EXPLOSION = 1f;
    [SerializeField] ParticleSystem explosion = null;
    [Header("Other")]
    [SerializeField] GameObject damagePopup;
    private const float paddingForPopup = 1.5f;
    Audio audioHandler;
    GameSession myGameSession;
    void Start()
    {
        shotCounter = UnityEngine.Random.Range(myLaserConfig.getminShotCounter(), myLaserConfig.getmaxShotCounter());
        FindObjectOfType<EnemySpawner>().addEnemy();
        audioHandler = FindObjectOfType<Audio>();
        myGameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        shotCountDownHandler();
    }

    private void shotCountDownHandler()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0)
        {
            fire();
            shotCounter = UnityEngine.Random.Range(myLaserConfig.getminShotCounter(), myLaserConfig.getmaxShotCounter());
        }
    }

    private void fire()
    {
        var newLaser = Instantiate(myLaserConfig.getLaserShot(), gameObject.transform.position, myLaserConfig.getLaserRotation());
        audioHandler.playenemyShotAudio();
        newLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, myLaserConfig.getlaserSpeed());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            die();
            return;
        }
        var damage = collision.GetComponent<Damage>();
        if (!damage) { return; }
        hitHandle(damage);
    }

    private void hitHandle(Damage damage)
    {
        health -= damage.getDamage();
        showDamagePopUp(damage.getDamage());
        damage.hit();
        if (health <= 0)
        {
            die();
        }
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

    private void die()
    {
        myGameSession.addScore(this.score);
        FindObjectOfType<EnemySpawner>().removeEnemy();
        Destroy(gameObject);
        var newExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(newExplosion.gameObject, TIME_OF_EXPLOSION);
        audioHandler.playdeathEnemyAudio();
    }
}
