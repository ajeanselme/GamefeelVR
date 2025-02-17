using UnityEngine;

public class MissilePool : MonoBehaviour
{
    public int nbMissiles = 1;
    public float missileSpeed = 10f;
    public GameObject missilePrefab;

    [Header("_____DEBUG_____")]
    public Tir[] missiles;

    private void Awake()
    {
        missiles = new Tir[nbMissiles];
        
        // Instantiate Missiles for object pooling optimization
        for (int i = 0; i < nbMissiles; i++)
        {
            //GameObject newMissile = Instantiate(missilePrefab, transform.position, transform.rotation);
            GameObject newMissile = Instantiate(missilePrefab, transform);
            Tir tir = newMissile.GetComponent<Tir>();
            tir.speed = missileSpeed;
            missiles[i] = tir;
            newMissile.transform.SetParent(null);
            newMissile.SetActive(false);
        }
    }

    public bool Shoot()
    {
        foreach(Tir tir in missiles)
        {
            // si le missile est d�ja activ�, skip le
            if(tir.isActiveAndEnabled)
            {
                continue;
            }

            // sinon active le et tir 1 fois
            tir.Activate(transform.position);
            return true;
        }

        return false;
    }
}
