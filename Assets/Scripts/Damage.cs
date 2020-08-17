using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField]float damageRandomFactor = 0.1f;

    // Start is called before the first frame update
    [SerializeField] float damage = 50f;
    public float getDamage() 
    {
        int damageFactor = (int)(damage * damageRandomFactor);
        int damageWithRandom = Random.Range((int)damage - damageFactor, (int)damage + damageFactor);
        return damageWithRandom; 
    }
    public void hit()
    {
        Destroy(gameObject);
    }
}
