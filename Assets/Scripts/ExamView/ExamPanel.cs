using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

public class ExamPanel : MonoBehaviour
{
    public ScrollRect m_ScrollView;
    public TextAsset m_ExamTextAsset;
    public GameObject m_QuestionPrefab;
    public Button m_SubmitBtn;
    public Button m_NextBtn;

    private List<QuestionForm> m_List;
    private int m_Index = 0;

    void Awake()
    {
        m_List = new List<QuestionForm>();
        m_QuestionPrefab.SetActive(false);

        m_NextBtn.onClick.AddListener(this.OnNextClick);
        m_SubmitBtn.onClick.AddListener(this.OnSubmitClick);
    }

    public void OnEnable()
    {
        ClearAll();
        
        m_Index = 0;
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

        ShowForm(m_Index);
    }

    private void ClearAll()
    {
        foreach (var form in m_List)
        {
            Destroy(form.gameObject);
        }
        m_List.Clear();
    }

    void ShowForm(int index)
    {
        foreach (var form in m_List)
        {
            form.gameObject.SetActive(false);
        }
        m_List[index].gameObject.SetActive(true);
    }
    
    private void OnSubmitClick()
    {
         m_List[m_Index].OnSubmit();
         LayoutRebuilder.ForceRebuildLayoutImmediate(m_ScrollView.content);
    }

    private void OnNextClick()
    {
        m_Index++;
        if (m_Index >= m_List.Count)
        {
            m_Index = 0;
        }
        ShowForm(m_Index);
        LayoutRebuilder.ForceRebuildLayoutImmediate(m_ScrollView.content);
    }
}