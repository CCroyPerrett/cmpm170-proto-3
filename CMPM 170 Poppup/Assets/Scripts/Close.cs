using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Close : MonoBehaviour
{
    public GameObject parent;
    Button bt;

    // Start is called before the first frame update
    void Start()
    {
        bt = gameObject.GetComponent<Button>();
        bt.onClick.AddListener(CloseParent);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CloseParent()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
        Destroy(parent.gameObject);
    }
}
