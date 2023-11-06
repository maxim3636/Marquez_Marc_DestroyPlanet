using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Auto_Destroy : MonoBehaviour
{
    public float timeToDestroy = 0.5f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         timer += Time.deltaTime;
        if (timer > timeToDestroy)
        {
            timer = 0.0f;
            Destroy(gameObject);
        }
    }
}
