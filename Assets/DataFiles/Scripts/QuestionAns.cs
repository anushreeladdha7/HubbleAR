using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestionAns : MonoBehaviour {

    class Question
    {
        public string Quescontent { get; set; }
        public List<string> answer1 { get; set; }

        public Question(string content, List<string> answerlist)
        {
            Quescontent = content;
            answer1 = answerlist;
        }
    }

    List<Question> Questionlist = new List<Question>();
    Question currentquestion = null;
    public Text Questionreply;
    public Text post_replyA;
    public Text post_replyB;
    public Text post_replyC;
    public Text post_replyD;
    public Button reply_button1;
    public Button reply_button2;
    public Button reply_button3;
    public Button reply_button4;
    string answer;
    int right = 0;
    int wrong = 0;
    ColorBlock green = new ColorBlock();
    ColorBlock red = new ColorBlock();
    ColorBlock normal = new ColorBlock();

    public Text Finalreply;
    public GameObject MainSet;
    // Use this for initialization
    void Start ()
    {
        Questionlist.Add(new Question("Launching date of the Hubble space telescope?", new List<string> {"24 th April, 1990","20 th April, 1990", "28 th May,1991", "20 th May,1991","24 th April, 1990"}));
	Questionlist.Add(new Question("In order to create a mosaic image that depicts almost half of Andromeda, Hubble has taken nearly 7,400 exposures of this galaxy:", new List<string> {"Andromeda galaxy","Bode's Galaxy", "Centaurus A","Milky Way Galaxy","Triangulum Galaxy"}));
	Questionlist.Add(new Question("Which one of these is not an observation by Hubble telescope?", new List<string> {"Tracing Aromatic molecules in early universe", "Exploring birth of stars", "Finding Planetary Construction zones", "Uncovering IcyObjects in Kuiper belt","Finding comets"}));
	Questionlist.Add(new Question("Using gravitational microlensing, astronomers used Hubble to confirm the existence of which planet orbiting two small, faint stars in a tight orbit around each other?", new List<string> {"Jupiter","Saturn", "Mars", "Earth", "Uranus"}));

        //Questionlist.Add(new Question("", new List<string> { "", "", "", "", "" }));
        newQ();

        green = reply_button1.colors;
        red = reply_button1.colors;
        normal = reply_button1.colors;

        green.normalColor = Color.green;
        green.pressedColor = Color.green;
        green.highlightedColor = Color.green;
        green.disabledColor = Color.green;

        red.normalColor = Color.red;
        red.pressedColor = Color.red;
        red.highlightedColor = Color.red;
        red.disabledColor = Color.red;
    }

    float towait = 0;
    bool changetime = false;
    bool returntime = false;
    void Update()
    {
        towait -= Time.deltaTime;

        if (towait < 0 && changetime)
        {
            reply_button1.colors = normal;
            reply_button2.colors = normal;
            reply_button3.colors = normal;
            reply_button4.colors = normal;
            newQ();
            changetime = false;
        }

        if (towait < 0 && returntime)
        {
            SceneManager.LoadScene("Quiz");
            returntime = false;
        }
    }

        void newQ () {
        if (Questionlist.Count != 0)
        {
            currentquestion = Questionlist[(new System.Random()).Next(Questionlist.Count)];
            answer = currentquestion.answer1[0];
            Questionreply.text = currentquestion.Quescontent + " \n\n(Correct:" + right + " Incorrect:" + wrong + ")";
            var availableAnswers = currentquestion.answer1;

            List<int> notinc = new List<int>();
            var curr = Random.Range(0, 5);
            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            post_replyA.text = "" + availableAnswers[curr];

            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            post_replyB.text = "" + availableAnswers[curr];

            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            post_replyC.text = "" + availableAnswers[curr];

            while (notinc.Contains(curr))
            {
                curr = Random.Range(0, 5);
            }
            notinc.Add(curr);
            post_replyD.text = "" + availableAnswers[curr];


        }
        else
        {
            MainSet.SetActive(false);
            Finalreply.gameObject.SetActive(true);
            Finalreply.text = string.Format("Your Scorecard\n\nRight:  {0} \n Wrong:  {1}", right, wrong);
            changetime = false;
            returntime = true;
            towait = 5;
        }
    }

    void commonStuff(bool iscorrect, Button currentbutton)
    {
        Questionlist.Remove(currentquestion);

        if (iscorrect) { right++; currentbutton.colors = green; } else
        {
            wrong++; currentbutton.colors = red;
            if (post_replyA.text == answer)
            {
                reply_button1.colors = green;
            }
            else if (post_replyB.text == answer)
            {
                reply_button2.colors = green;
            }
            else if (post_replyC.text == answer)
            {
                reply_button3.colors = green;
            }
            else if (post_replyD.text == answer)
            {
                reply_button4.colors = green;
            }

        }
        towait = 1.5f;
        changetime = true;
    }

    public void answerA()
    {
        if (!changetime)
        {
            commonStuff((post_replyA.text == answer), reply_button1);
        }
    }

    public void answerB()
    {
        if (!changetime)
        {
            commonStuff((post_replyB.text == answer), reply_button2);
        }
    }

    public void answerC()
    {
        if (!changetime)
        {
            commonStuff((post_replyC.text == answer), reply_button3);
        }
    }

    public void answerD()
    {
        if (!changetime)
        {
            commonStuff((post_replyD.text == answer), reply_button4);
        }
    }


}
