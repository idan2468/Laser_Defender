using UnityEngine;

[CreateAssetMenu(menuName = "Laser Config")]
public class LaserConfig : ScriptableObject
{
    // Start is called before the first frame update
    [Header("Laser Position")]
    [SerializeField] Vector3 laserRotation;
    [SerializeField] GameObject laserShot = null;
    [SerializeField] float minShotCounter = 0.2f;
    [SerializeField] float maxShotCounter = 1.5f;
    [SerializeField] private float laserSpeed = -7;
    public Quaternion getLaserRotation()
    {
        return Quaternion.Euler(laserRotation);
    }
    public GameObject getLaserShot()
    {
        return laserShot;
    }
    public float getminShotCounter()
    {
        return minShotCounter;
    }
    public float getmaxShotCounter()
    {
        return maxShotCounter;
    }
    public float getlaserSpeed()
    {
        return laserSpeed;
    }


}
