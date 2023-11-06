using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float respawnTime = 3.0f;
    private float timer = 0.0f;
    public GameObject prefabBomb;
    public static bool gameOver1 = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > respawnTime)
        {
            timer = 0.0f;
            CreateNewBomb(gameOver1);
        }
    }

    private void CreateNewBomb(bool isGame)
    {
        if (isGame)
        {
            Vector3 randPosition = Random.onUnitSphere * 0.55f;
            GameObject bomb = Instantiate(prefabBomb, randPosition, Quaternion.identity);

            // Calculate the rotation to make the bomb stand up properly
            Vector3 upDirection = randPosition.normalized;
            bomb.transform.rotation = Quaternion.FromToRotation(Vector3.up, upDirection);

            bomb.transform.parent = GameObject.Find("Bombs").transform; // set the parent to the 'Bombs' GameObject
        }
    }
}
