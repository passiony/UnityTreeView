using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class TrainPanel : MonoBehaviour
{
    public ScrollRect m_ScrollView;
    public TextAsset m_ExamTextAsset;
    public GameObject m_QuestionPrefab;
    public Button m_SubmitBtn;
    public Button m_QuitBtn;

    private List<QuestionForm> m_List;

    void Awake()
    {
        m_List = new List<QuestionForm>();
        m_QuestionPrefab.SetActive(false);

        m_SubmitBtn.onClick.AddListener(this.OnSubmitClick);
        m_QuitBtn.onClick.AddListener(this.OnQuitClick);
    }

    private void OnQuitClick()
    {
        gameObject.SetActive(false);
    }

    public void OnEnable()
    {
        ClearAll();
        
        var json = m_ExamTextAsset.text;
        var examData = JsonConvert.DeserializeObject<ExamData[]>(json);
        foreach (var dtData in examData)
        {
            var question = GameObject.Instantiate(m_QuestionPrefab, m_ScrollView.content);
            var form = question.GetComponent<QuestionForm>();
            form.gameObject.SetActive(true);
            form.InitData(dtData);

            m_List.Add(form);
        }
        
    }

    private void ClearAll()
    {
        foreach (var form in m_List)
        {
            Destroy(form.gameObject);
        }
        m_List.Clear();
    }

    
    private void OnSubmitClick()
    {
        foreach (var form in m_List)
        {
            form.OnSubmit();
        }
         LayoutRebuilder.ForceRebuildLayoutImmediate(m_ScrollView.content);
    }

}