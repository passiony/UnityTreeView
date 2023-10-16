using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModePanel : MonoBehaviour
{
    public Button m_StudyMenu;
    public Button m_TrainMenu;
    public Button m_ExamMenu;

    public Button m_ScoreBtn;
    public Button m_StatisBtn;
    public Button m_QuitBtn;

    public GameObject StudyPanel;
    public GameObject TrainPanel;
    public GameObject ExamPanel;

    public GameObject ScorePanel;
    public GameObject StatisPanel;

    void Start()
    {
        m_StudyMenu.onClick.AddListener(() => { StudyPanel.SetActive(true); });
        m_TrainMenu.onClick.AddListener(() => { TrainPanel.SetActive(true); });
        m_ExamMenu.onClick.AddListener(() => { ExamPanel.SetActive(true); });
        
        m_ScoreBtn.onClick.AddListener(() => { ScorePanel.SetActive(true); });
        m_StatisBtn.onClick.AddListener(() => { StatisPanel.SetActive(true); });
        m_QuitBtn.onClick.AddListener(() => { Application.Quit(); });
    }
}