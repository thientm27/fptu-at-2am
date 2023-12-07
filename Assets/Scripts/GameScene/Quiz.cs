using OpenCover.Framework.Model;
using System.Collections;using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quiz : MonoBehaviour {
    [System.Serializable]
    private class Question {
        public string Title;
        public string Subject;
        public string OptionA;
        public string OptionB;
        public string OptionC;
        public string OptionD;
        public string CorrectAnswer;
    }

    [System.Serializable]
    private class Questions {
        public Question[] arrQuestions;
    }

    public TextAsset quizJSON;

    public Text questionText;
    public Button optionAButton;
    public Button optionBButton;
    public Button optionCButton;
    public Button optionDButton;

    public jumpscareTrig jumpscareTrig;
    public string scene;
    public GameObject tele1, tele2, tele3;
    
    [SerializeField] public GameObject player;

    private string correctAnswer; // Đáp án đúng

    private Questions myQuestions;
    private Question[] questionsPRN;
    private Question[] questionsSWD;
    private Question[] questionsEXE;
    private Question[] questionsPRU;
    private Question[] questionsPRM;

    private void Awake() {
        // Awake is called even if the script is disabled. 
        // Tải câu hỏi và đáp án lên UI
        myQuestions = JSONReader.GetQuestion(quizJSON);

        questionsPRN = myQuestions.arrQuestions.Where(x => x.Subject.Equals("PRN")).ToArray();
        questionsSWD = myQuestions.arrQuestions.Where(x => x.Subject.Equals("SWD")).ToArray();
        questionsEXE = myQuestions.arrQuestions.Where(x => x.Subject.Equals("EXE")).ToArray();
        questionsPRU = myQuestions.arrQuestions.Where(x => x.Subject.Equals("PRU")).ToArray();
        questionsPRM = myQuestions.arrQuestions.Where(x => x.Subject.Equals("PRM")).ToArray();
    }

    public void Start() {
    }

    private static class JSONReader {
        public static Questions GetQuestion(TextAsset quizJSON) {
            Questions questions = JsonUtility.FromJson<Questions>(quizJSON.text);
            return questions;
        }
    }

    public void LoadQuestion(string subjectName) {
        Question randomQuestion = null;
        int randomIndex;
        switch (subjectName) {
            case "PRN":
                randomIndex = Random.Range(0, questionsPRN.Length);
                randomQuestion = questionsPRN[randomIndex];
                //randomIndex = Random.Range(0, myQuestions.arrQuestions.Length);
                //randomQuestion = myQuestions.arrQuestions[randomIndex];
                break;
            case "EXE":
                randomIndex = Random.Range(0, questionsEXE.Length);
                randomQuestion = questionsEXE[randomIndex];
                break;
            case "PRM":
                randomIndex = Random.Range(0, questionsPRM.Length);
                randomQuestion = questionsPRM[randomIndex];
                break;
            case "PRU":
                randomIndex = Random.Range(0, questionsPRU.Length);
                randomQuestion = questionsPRU[randomIndex];
                break;
            case "SWD":
                randomIndex = Random.Range(0, questionsSWD.Length);
                randomQuestion = questionsSWD[randomIndex];
                break;
            default:
                return;
        }

        // Tải câu hỏi và đáp án từ nguồn dữ liệu của bạn
        string question = $"({randomQuestion.Subject}) {randomQuestion.Title}";
        string optionA = randomQuestion.OptionA;
        string optionB = randomQuestion.OptionB;
        string optionC = randomQuestion.OptionC;
        string optionD = randomQuestion.OptionD;
        correctAnswer = randomQuestion.CorrectAnswer;

        // Hiển thị câu hỏi và các đáp án trên UI
        questionText.text = question;
        optionAButton.GetComponentInChildren<Text>().text = optionA;
        optionBButton.GetComponentInChildren<Text>().text = optionB;
        optionCButton.GetComponentInChildren<Text>().text = optionC;
        optionDButton.GetComponentInChildren<Text>().text = optionD;
    }

    public void CheckAnswer(string selectedOption) {
        if (selectedOption.ToUpper() != correctAnswer.ToUpper()) {
            Time.timeScale = 1;
            AudioListener.pause = false;
            SceneManager.LoadScene(scene);
        } else {
            PlayerTeleport();
            
            jumpscareTrig.questionobj.SetActive(false);
            jumpscareTrig.ResumeGame();
        }
    }

    private void PlayerTeleport() {
        player.SetActive(false);
        int randomIndex = Random.Range(0, 3);
        switch (randomIndex) {
            case 0:
                player.transform.position = tele1.transform.position;
                break;
            case 1:
                player.transform.position = tele2.transform.position;
                break;
            case 2:
                player.transform.position = tele3.transform.position;
                break;
            default:
                player.transform.position = tele3.transform.position;
                break;
        }
        player.SetActive(true);

    }

}
