using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Poppup : MonoBehaviour
{
    public SpriteRenderer border;

    public Button close;
    public Button ad;
    public Button drag;

    public GameObject[] newads;
    public AudioSource clicksound;
    public bool vibrate; public float vibratespeed;

    float time; float vtime = 0; 
    [HideInInspector] public float adsize = 1;
    bool dosound; 
    
    // Start is called before the first frame update
    void Start()
    {
        //ad = transform.Find("Ad").gameObject.GetComponent<Button>();
        //close = transform.Find("Close").gameObject.GetComponent<Button>();
        //clicksound = ad.gameObject.GetComponent<AudioSource>();

        close.onClick.AddListener(Close);
        ad.onClick.AddListener(DoAd);

        clicksound = gameObject.GetComponent<AudioSource>(); dosound = true;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        border.color = new Color(Mathf.PingPong(Time.time, 1), 
        Mathf.PingPong(Time.time * 0.8f, 1), Mathf.PingPong(Time.time * 0.6f, 1)); ;
        
        if(time < 0.75)
        {
            transform.localScale = new Vector3(time, time, time) * 3;
            time += Time.deltaTime * adsize;
        }
        if(time > 0.5 && dosound)
        {
            dosound = false;
            ad.gameObject.GetComponent<AudioSource>().Play();
        }

        if (vibrate)
        {
            vtime += Time.deltaTime;
            if(vtime > 0.5)
            {
                int xdir = Mathf.RoundToInt(Random.Range(-1, 2)); 
                int ydir = Mathf.RoundToInt(Random.Range(-1, 2));
                transform.Translate(new Vector2(vibratespeed * xdir, vibratespeed * ydir));
                if(transform.position.x < -6.4f) { transform.position = new Vector2(-6.4f, transform.position.y); }
                if (transform.position.x > 6.4f) { transform.position = new Vector2(6.4f, transform.position.y); }
                if (transform.position.y < -3.02f) { transform.position = new Vector2(transform.position.x, -3.02f); }
                if (transform.position.y > 3.37f) { transform.position = new Vector2(transform.position.x, 3.37f); }
                vtime = 0;
            }
        }

    }

   void Close()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
        Destroy(this.gameObject);
    }

    void DoAd()
    {
        StartCoroutine(TriggerAd());
    }
   

    private IEnumerator TriggerAd()
    {
        Debug.Log("ad triggered!");
        clicksound.Play();
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0.85f,0.85f,0.85f);
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        for(int i = 0; i < 1 + Random.Range(0,2); i++)
        {
            yield return new WaitForSeconds(0.2f);
            GameObject newad = Instantiate(newads[Mathf.FloorToInt(Random.Range(0,newads.Length))]);
            newad.transform.position = new Vector3(Random.Range(-6.4f, 6.4f), Random.Range(3.37f, -3.02f), 0);
            yield return new WaitForSeconds(0.2f);
        }
    }
}
