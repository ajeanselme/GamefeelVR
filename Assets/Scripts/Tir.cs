using System.Collections;
using UnityEngine;

public class Tir : MonoBehaviour
{
    public float speed = 100.0f;
    public float disappearTime = 1.0f;

    [Header("_________DEBUG_______")]
    [SerializeField] private float disappearTimer = 0.0f;

    private void OnEnable()
    {
        // Add VFX + SFX here
    }

    private void OnDisable()
    {
        // Reset the missile to initial value
        disappearTimer = 0.0f;
    }

    void Update()
    {
        //le missile qui avance
        transform.position += Vector3.up * speed * Time.deltaTime;

        //le missile qui disparait un moment apr�s
        disappearTimer += Time.deltaTime;
        if(disappearTimer > disappearTime)
        {
            //gameObject.SetActive(false);
            Deactivate();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Alien")
        {
            Debug.Log("Tir trigger on Alien");
            Deactivate();
        }
    }

    public void Activate(Vector3 position)
    {
        transform.position = position;
        gameObject.SetActive(true);
    }
    
    private void Deactivate()
    {
        StartCoroutine(OnDeactivate());
    }

    IEnumerator OnDeactivate()
    {
        // Begin here any VFX & SFX & Feel

        //while(true)
        //{
        //    // Add here conditions to break loop
        //    //if()
        //    //{
        //    //    break;
        //    //}
            
        //    yield return null;
        //}
        yield return null;
        gameObject.SetActive(false);
    }
}
