using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject thing;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector3 spawnPoint = new Vector3(Random.Range(-10f, 10f), .5f, Random.Range(-10, 10));

        Instantiate(thing, spawnPoint, Quaternion.identity);
    }
}
