using TMPro;
using UnityEngine;

public class obj : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public AudioSource clickSound;
    public GameObject win;

    private void Start()
    {
        score = 0;
    }
    void OnMouseDown()
    {
        score++;

        scoreText.text = "Score: " + score;

        if (clickSound != null)
        {
            clickSound.Play();
        }
        if(score==19)
        {
            win.SetActive(true);
        }

        gameObject.SetActive(false);

    }


}
