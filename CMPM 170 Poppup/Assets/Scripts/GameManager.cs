using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] popups;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnPopup());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnPopup() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            GameObject popup = Instantiate(popups[Random.Range(0, popups.Length)]);
            
            // spawn a popup at a random position
            popup.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 0);

            
            popup.SetActive(true);

        }
    }
}
