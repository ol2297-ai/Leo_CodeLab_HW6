using UnityEngine;
using TMPro;

public class manager : MonoBehaviour
{
    public int questionCounter;
    public string Quest1;
    public string Quest2;
    public TMP_Text QuestText;

    public string[] questions;

    public string[] AA;
    public string[] BA;
    public string[] CA;
    public string[] DA;

    public TMP_Text AText;
    public TMP_Text BText;
    public TMP_Text CText;
    public TMP_Text DText;

    public int Ascore;
    public int Bscore;
    public int Cscore;
    public int Dscore;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Ascore = 0;
        Bscore = 0;
        Cscore = 0;
        Dscore = 0;
        QuestText.text = questions[0];
        AText.text = AA[0];
        BText.text = BA[0];
        CText.text = CA[0];
        DText.text = DA[0];

    }

    // Update is called once per frame
    void Update()
    {
        /*if (questionCounter==0)
        {
            QuestText.text = questions[0];
        }
        if (questionCounter==1)
        {
            QuestText.text = questions[1];
        }*/

       
    }


    public void ansered(int P)
    {
        if (P == 0)
        {
            Ascore++;
        }
        if (P == 1)
        {
            Bscore++;
        }
        if (P == 2)
        {
            Cscore++;
        }
        if (P == 3)
        {
            Dscore++;
        }
        if (questionCounter<questions.Length-1)
        {
            questionCounter++;
            QuestText.text = questions[questionCounter];
            AText.text = AA[questionCounter];
            BText.text = BA[questionCounter];
            CText.text = CA[questionCounter];
            DText.text = DA[questionCounter];
        }
        else
        {
            CCC();
        }
       


    }

    void CCC()
    {
        if(Ascore ==2)
        {
            QuestText.text = "1";
        }
        if (Bscore == 2)
        {
            QuestText.text = "2";
        }
        if (Cscore == 2)
        {
            QuestText.text = "3";
        }
        if (Dscore == 2)
        {
            QuestText.text = "4";
        }
        else
        {
            QuestText.text = "QQQ";
        }

    }
}
