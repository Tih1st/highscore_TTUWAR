using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class startQuiz : MonoBehaviour {

    public GameObject QuizWindow;
    public Text questionText;
    public Text optA;
    public Text optB;
    public Text optC;
    public Text optD;
    public ToggleGroup QuizToggle;
    public GameObject DoneBttn;
    public GameObject SubmitBttn;
    public GameObject LearnBttn;
    public GameObject Toggles;
    public GameObject[] Lifes = new GameObject[] {};
    public AudioSource wrongAnswer;
    public AudioSource gameOver;
    public AudioSource correct;
    public AudioSource WonGame;
    public AudioSource QuizBGM;
    private int question;
    private int HowManyQuestions = 2;
    private int HowManyLifes = 3;
    private string[] correctAnswers_str;
    private Text[] TextOpt;
    public static int QuizNum;
	
	//Added a timer to quiz
	public float currCountdownValue;
	
	public IEnumerator StartCountdown(float countdownValue = 100)
	{
		currCountdownValue = countdownValue;
		while (currCountdownValue > 0)
		{
			Debug.Log("Countdown: " + currCountdownValue);
			yield return new WaitForSeconds(1.0f);
			currCountdownValue--;
		}
		if (currCountdownValue < 0)
		{
			questionText.text = "You have run out of time!";
			SubmitBttn.SetActive(false);
            Toggles.SetActive(false);
            DoneBttn.SetActive(true);
            LearnBttn.SetActive(true);
		}
	}

    // Use this for initialization
    private void Start()
    {
		//Timer Function needs to be tested
		//StartCoroutine(StartCountdown());
        TextOpt = new Text[] { optA, optB, optC, optD };
        question = 0;
    }

    // Manages the questions that will be shown
    private void loadQuestion()
    {
        switch (QuizNum)
        {
            case 1:
                {
                    correctAnswers_str = new string[] { "1", "2" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "Which is the name of the water feature located in the center of the Memorial Circle?";
                                optA.text = "A.	Preston Scott Fountain";
                                optB.text = "B.	Pfluger Fountain";
                                optC.text = "C.	Curry Holden Fountain";
                                optD.text = "D.	James Marion West, Sr. Fountain";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "In which year the Pfluger Fountain was added to the Memorial Circle?";
                                optA.text = "A.	1948";
                                optB.text = "B.	1997";
                                optC.text = "C.	2002";
                                optD.text = "D.	2014";
                                break;
                            }
                    }
                    break;
                }
            case 2:
                {
                    correctAnswers_str = new string[] { "1", "3" };
                    switch (question)
                    {
                        case 0:
                            {
                                questionText.text = "What is the name of the water feature between English/Philosophy and the College of Education?";
                                optA.text = "A.	Fountain of Knowledge";
                                optB.text = "B.	Headwaters";
                                optC.text = "C.	Education Journey";
                                optD.text = "D.	Water Play";
                                break;
                            }
                        case 1:
                            {
                                questionText.text = "What is supposed to mean the water pouring over the fountain at the Headwater?";
                                optA.text = "A.	Thirst for knowledge";
                                optB.text = "B.	Nurturing new ideas";
                                optC.text = "C.	Life’s Journey";
                                optD.text = "D.	Sounds that letters create";
                                break;
                            }
                    }
                    break;
                }
        }
    
    }
    
    // Starts quiz
    public void GoToQuiz()
    {
        QuizBGM.Play();
        loadQuestion();
        QuizWindow.SetActive(true);
    }

    // Handles the progress of the quiz
    public void submitAnswer()
    {
        if (QuizToggle.ActiveToggles().FirstOrDefault().name == correctAnswers_str[question])
        {
            Debug.Log("Correct!");
            correct.Play();
            question++;
            ScoreManager.AddScore(5);
            if (question < HowManyQuestions)
            {
                loadQuestion();
                QuizToggle.SetAllTogglesOff();
            }
            else
            {
				if (HowManyLifes == 3)
				{
					questionText.text = "All 3 lives retained! You have scored 15 bonus points";
					ScoreManager.AddScore(15);
				}
                QuizBGM.Stop();
                WonGame.Play();
                questionText.text = "Congratulations! You won the challenge...";
                SubmitBttn.SetActive(false);
                Toggles.SetActive(false);
                DoneBttn.SetActive(true);
                LearnBttn.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Incorrect!");
            HowManyLifes--;
            if (HowManyLifes > 0)
            {
                wrongAnswer.Play();
                Lifes[HowManyLifes].SetActive(false);
				ScoreManager.MinusScore(5);
            }
            else
            {
                QuizBGM.Stop();
                gameOver.Play();
                Lifes[HowManyLifes].SetActive(false); //Last life
                questionText.text = "You lost! Try again...";
                SubmitBttn.SetActive(false);
                Toggles.SetActive(false);
                DoneBttn.SetActive(true);
                LearnBttn.SetActive(true);
            }
        }
    }
}