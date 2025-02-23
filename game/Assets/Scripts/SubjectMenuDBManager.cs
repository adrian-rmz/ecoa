using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System.IO;
using SimpleJSON;
using UnityEngine.SceneManagement;

public class SubjectMenuDBManager : MonoBehaviour
{
    public GameObject userObject;
    public GameObject courseObject;
    public string JSONurl = "";
    public string studentID;

    public Image Subject1;
    public Image Subject2;
    public Image Subject3;
    public Image Subject4;
    public Image Subject5;
    public Image Subject6;
    public Image Subject7;
    public Image Subject8;
    public Image Subject9;
    public Image Subject10;

    public Text Title1;
    public Text Title2;
    public Text Title3;
    public Text Title4;
    public Text Title5;
    public Text Title6;
    public Text Title7;
    public Text Title8;
    public Text Title9;
    public Text Title10;

    public Image Status1;
    public Image Status2;
    public Image Status3;
    public Image Status4;
    public Image Status5;
    public Image Status6;
    public Image Status7;
    public Image Status8;
    public Image Status9;
    public Image Status10;

    public Button flag1;
    public Button flag2;
    public Button flag3;
    public Button flag4;
    public Button flag5;
    public Button flag6;
    public Button flag7;
    public Button flag8;
    public Button flag9;
    public Button flag10;

    public string sTitle;
    public string sKind;
    public int sQAnswered;
    public int sQAmount;

    public int totalSubjects;

    public Subject[] subjects = new Subject[10];

    public Sprite completed;
    public Sprite inProgress;
    public Sprite uncompleted;
    public Sprite invalid;

    public Sprite yellow_flag;
    public Sprite blue_flag;
    public Sprite red_flag;
    public Sprite darkblue_flag;
    public Sprite lila_flag;
    public Sprite purple_flag;
    public Sprite orange_flag;
    public Sprite black_flag;
    public Sprite green_flag;
    public Sprite gray_flag;


    IEnumerator Start()
    {
        courseObject = GameObject.Find("Course");
        studentID = userObject.GetComponent<User>().ID;
        //courseObject.GetComponent<Course>().CRN;

        JSONurl = "http://localhost:8080/api/progress/student/" + studentID;
        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.useHttpContinue = false;

        yield return web.SendWebRequest();

        if (web.isNetworkError || web.isHttpError)
        {
            SceneManager.LoadScene("Error");
            Debug.Log("Error API: " + web.error);
        }
        else
        {
            Debug.Log(web.downloadHandler.text);
            JSONNode jsonReceived = SimpleJSON.JSON.Parse(web.downloadHandler.text);
            Debug.Log(jsonReceived["FORMATION_UNITS"].ToString());

            totalSubjects = jsonReceived["FORMATION_UNITS"]["progress"].Count;
            string titleReceived, kindReceived;
            int qAnsReceived, qAmoReceived, cCRNReceived;

            for (int c = 0; c < 10; c++)
            {

                titleReceived = jsonReceived["FORMATION_UNITS"]["progress"][c]["title"];
                kindReceived = jsonReceived["FORMATION_UNITS"]["progress"][c]["kind"];
                qAnsReceived = jsonReceived["FORMATION_UNITS"]["progress"][c]["questionsAnswered"];
                qAmoReceived = jsonReceived["FORMATION_UNITS"]["progress"][c]["questionAmount"];
                cCRNReceived = jsonReceived["FORMATION_UNITS"]["progress"][c]["crn"];

                if (c < totalSubjects)
                { subjects[c] = new Subject(titleReceived, kindReceived, qAnsReceived, qAmoReceived, cCRNReceived); }
                else
                { subjects[c] = new Subject("No Subject", "No kind", 0, 0, 0); }
            }
        }
        loadFlags();
    }

    void loadFlags()
    {
        for (int i = 0; i < 10; i++)
        {
            switch (i)
            {
                case 0:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject1.sprite = purple_flag;
                        Title1.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status1.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status1.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status1.sprite = completed; }
                        else
                        { Status1.sprite = invalid; }

                        flag1.onClick.AddListener(flag1Clicked);
                    }
                    else
                    {
                        Subject1.sprite = gray_flag;
                        Title1.text = subjects[i].title;
                        Status1.sprite = invalid;
                    }
                    break;
                case 1:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject2.sprite = orange_flag;
                        Title2.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status2.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status2.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status2.sprite = completed; }
                        else
                        { Status2.sprite = invalid; }

                        flag2.onClick.AddListener(flag2Clicked);
                    }
                    else
                    {
                        Subject2.sprite = gray_flag;
                        Title2.text = subjects[i].title;
                        Status2.sprite = invalid;
                    }
                    break;
                case 2:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject3.sprite = blue_flag;
                        Title3.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status3.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status3.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status3.sprite = completed; }
                        else
                        { Status3.sprite = invalid; }

                        flag3.onClick.AddListener(flag3Clicked);
                    }
                    else
                    {
                        Subject3.sprite = gray_flag;
                        Title3.text = subjects[i].title;
                        Status3.sprite = invalid;
                    }
                    break;
                case 3:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject4.sprite = black_flag;
                        Title4.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status4.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status4.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status4.sprite = completed; }
                        else
                        { Status4.sprite = invalid; }

                        flag4.onClick.AddListener(flag4Clicked);
                    }
                    else
                    {
                        Subject4.sprite = gray_flag;
                        Title4.text = subjects[i].title;
                        Status4.sprite = invalid;
                    }
                    break;
                case 4:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject5.sprite = yellow_flag;
                        Title5.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status5.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status5.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status5.sprite = completed; }
                        else
                        { Status5.sprite = invalid; }

                        flag5.onClick.AddListener(flag5Clicked);
                    }
                    else
                    {
                        Subject5.sprite = gray_flag;
                        Title5.text = subjects[i].title;
                        Status5.sprite = invalid;
                    }
                    break;
                case 5:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject6.sprite = darkblue_flag;
                        Title6.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status6.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status6.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status6.sprite = completed; }
                        else
                        { Status6.sprite = invalid; }

                        flag6.onClick.AddListener(flag6Clicked);
                    }
                    else
                    {
                        Subject6.sprite = gray_flag;
                        Title6.text = subjects[i].title;
                        Status6.sprite = invalid;
                    }
                    break;
                case 6:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject7.sprite = lila_flag;
                        Title7.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status7.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status7.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status7.sprite = completed; }
                        else
                        { Status7.sprite = invalid; }

                        flag7.onClick.AddListener(flag7Clicked);
                    }
                    else
                    {
                        Subject7.sprite = gray_flag;
                        Title7.text = subjects[i].title;
                        Status7.sprite = invalid;
                    }
                    break;
                case 7:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject8.sprite = red_flag;
                        Title8.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status8.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status8.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status8.sprite = completed; }
                        else
                        { Status8.sprite = invalid; }

                        flag8.onClick.AddListener(flag8Clicked);
                    }
                    else
                    {
                        Subject8.sprite = gray_flag;
                        Title8.text = subjects[i].title;
                        Status8.sprite = invalid;
                    }
                    break;
                case 8:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject9.sprite = green_flag;
                        Title9.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status9.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status9.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status9.sprite = completed; }
                        else
                        { Status9.sprite = invalid; }

                        flag9.onClick.AddListener(flag9Clicked);
                    }
                    else
                    {
                        Subject9.sprite = gray_flag;
                        Title9.text = subjects[i].title;
                        Status9.sprite = invalid;
                    }
                    break;
                case 9:
                    if (subjects[i].title != "No Subject")
                    {
                        Subject10.sprite = purple_flag;
                        Title10.text = subjects[i].title;
                        if (subjects[i].questionsAnswered == 0)
                        { Status10.sprite = uncompleted; }
                        else if (subjects[i].questionsAnswered < subjects[i].questionsAmount)
                        { Status10.sprite = inProgress; }
                        else if (subjects[i].questionsAnswered == subjects[i].questionsAmount)
                        { Status10.sprite = completed; }
                        else
                        { Status10.sprite = invalid; }

                        flag10.onClick.AddListener(flag10Clicked);
                    }
                    else
                    {
                        Subject10.sprite = gray_flag;
                        Title10.text = subjects[i].title;
                        Status10.sprite = invalid;
                    }
                    break;
                default:
                    Debug.Log("End of questons array");
                    break;
            }
        }
    }

    void flag1Clicked() {
        if (subjects[0].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[0].CRN;
            courseObject.GetComponent<Course>().title = subjects[0].title;
            blockNumericScene(); 
        }
        else if (subjects[0].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[0].CRN;
            courseObject.GetComponent<Course>().title = subjects[0].title;
            subjectNumericScene(); 
        }
    }
    void flag2Clicked() {
        if (subjects[1].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[1].CRN;
            courseObject.GetComponent<Course>().title = subjects[1].title;
            blockNumericScene(); 
        }
        else if (subjects[1].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[1].CRN;
            courseObject.GetComponent<Course>().title = subjects[1].title;
            subjectNumericScene(); 
        }
    }
    void flag3Clicked() {
        if (subjects[2].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[2].CRN;
            courseObject.GetComponent<Course>().title = subjects[2].title;
            blockNumericScene(); 
        }
        else if (subjects[2].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[2].CRN;
            courseObject.GetComponent<Course>().title = subjects[2].title;
            subjectNumericScene(); 
        }
    }
    void flag4Clicked() {
        if (subjects[3].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[3].CRN;
            courseObject.GetComponent<Course>().title = subjects[3].title;
            blockNumericScene(); 
        }
        else if (subjects[3].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[3].CRN;
            courseObject.GetComponent<Course>().title = subjects[3].title;
            subjectNumericScene(); 
        }
    }
    void flag5Clicked() {
        if (subjects[4].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[4].CRN;
            courseObject.GetComponent<Course>().title = subjects[4].title;
            blockNumericScene(); 
        }
        else if (subjects[4].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[4].CRN;
            courseObject.GetComponent<Course>().title = subjects[4].title;
            subjectNumericScene(); 
        }
    }
    void flag6Clicked() {
        if (subjects[5].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[5].CRN;
            courseObject.GetComponent<Course>().title = subjects[5].title;
            blockNumericScene(); 
        }
        else if (subjects[5].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[5].CRN;
            courseObject.GetComponent<Course>().title = subjects[5].title;
            subjectNumericScene(); 
        }
    }
    void flag7Clicked() {
        if (subjects[6].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[6].CRN;
            courseObject.GetComponent<Course>().title = subjects[6].title;
            blockNumericScene(); 
        }
        else if (subjects[6].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[6].CRN;
            courseObject.GetComponent<Course>().title = subjects[6].title;
            subjectNumericScene(); 
        }
    }
    void flag8Clicked() {
        if (subjects[7].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[7].CRN;
            courseObject.GetComponent<Course>().title = subjects[7].title;
            blockNumericScene(); 
        }
        else if (subjects[7].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[7].CRN;
            courseObject.GetComponent<Course>().title = subjects[7].title;
            subjectNumericScene(); 
        }
    }
    void flag9Clicked() {
        if (subjects[8].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[8].CRN;
            courseObject.GetComponent<Course>().title = subjects[8].title;
            blockNumericScene(); 
        }
        else if (subjects[8].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[8].CRN;
            courseObject.GetComponent<Course>().title = subjects[8].title;
            subjectNumericScene(); 
        }
    }
    void flag10Clicked() {
        if (subjects[9].kind == "BLOCK")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[9].CRN;
            courseObject.GetComponent<Course>().title = subjects[9].title;
            blockNumericScene(); 
        }
        else if (subjects[9].kind == "COURSE")
        { 
            courseObject.GetComponent<Course>().CRN = subjects[9].CRN;
            courseObject.GetComponent<Course>().title = subjects[9].title;
            subjectNumericScene(); 
        }
    }



    void subjectNumericScene()
    {
        SceneManager.LoadScene("subject_numeric");
    }
    void blockNumericScene()
    {
        SceneManager.LoadScene("block_numeric");
    }
}
