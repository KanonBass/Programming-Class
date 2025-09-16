using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PickupCoin : MonoBehaviour
{
    private List<GameObject> coins = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided");

        if (other.gameObject.CompareTag("Coin"))
        {
            if (coins.Count > 0)
            {
                Debug.Log("High Count");

                other.gameObject.transform.position = coins.Last().transform.position + new Vector3(0, 1, 0);
            }
            else
            {
                Debug.Log("Low Count");
                other.gameObject.transform.position = transform.position + new Vector3(0, 1, 0);
            }

            other.gameObject.transform.SetParent(gameObject.transform);

            

            coins.Add(other.gameObject);
        }
    }
}
