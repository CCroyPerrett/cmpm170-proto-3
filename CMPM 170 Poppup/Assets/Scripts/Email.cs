using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Email : MonoBehaviour
{
    SpriteRenderer sr;
    Button openButton;
    public Button closeButton;
    public Button sendButton;
    public GameObject page;
    public Text text;

    private bool beenClicked = false;
    private string defaultEmail = "Type Anything...";
    private string currentEmail = "";
    private string endEmail = "Subject: Follow-Up on Project Update\n\nHello,\n\nI am writing to follow up on the project update that was due last week. I have not received the update yet. Please let me know when I can expect to receive it.";
    private int emailIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
        openButton = transform.Find("Canvas").Find("Button").GetComponent<Button>();
        openButton.onClick.AddListener(IsClicked);
        closeButton.onClick.AddListener(closePopup);
        sendButton.onClick.AddListener(sendEmail);
        StartCoroutine(NotClicked());
    }

    // Update is called once per frame
    void Update()
    {
        if (beenClicked)
        {
            if (Input.anyKeyDown && !(Input.GetMouseButtonDown(0) 
            || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)) && emailIndex < endEmail.Length)
            {
                currentEmail += endEmail[emailIndex];
                emailIndex += 1;
            }

            if (emailIndex == 0) text.text = defaultEmail;
            else text.text = currentEmail;
        }
    }

    void sendEmail()
    {
        if (currentEmail.Length != endEmail.Length) return;

        GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("Win");
    }

    void closePopup()
    {
        GameObject.Find("GameManager").GetComponent<AudioSource>().Play();
        
        page.SetActive(false);
        beenClicked = false;
        currentEmail = "";
        emailIndex = 0;
    }

    void IsClicked()
    {
        StartCoroutine(Clicked());
    }

    public IEnumerator Clicked()
    {
        sr.color = new Color(0.85f, 0.85f, 0.85f);
        yield return new WaitForSeconds(0.2f);
        sr.color = Color.white;
        
        page.SetActive(true);
        beenClicked = true;
        
        gameObject.GetComponent<AudioSource>().Play();
    }

    public IEnumerator NotClicked() 
    {
        while(!beenClicked)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
