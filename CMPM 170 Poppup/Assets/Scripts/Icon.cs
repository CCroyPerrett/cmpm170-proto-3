using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Icon : MonoBehaviour
{
    public GameObject page;

    SpriteRenderer sr;
    Button bt;

    private bool beenClicked = false;

    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        bt = transform.Find("Canvas").Find("Button").GetComponent<Button>();
        bt.onClick.AddListener(IsCLicked);
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    void IsCLicked()
    {
        if (beenClicked) return;
        StartCoroutine(Clicked());
    }

    public IEnumerator Clicked()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.85f, 0.85f, 0.85f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        
        GameObject newPage = Instantiate(page);
        newPage.SetActive(true);
        beenClicked = true;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
