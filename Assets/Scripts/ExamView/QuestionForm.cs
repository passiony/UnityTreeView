using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestionForm : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI ruleTitle;
    public TextMeshProUGUI content;
    public AnswerForm answer;
    public TextMeshProUGUI rules;
    private ExamData m_ExamData;

    public void InitData(ExamData data)
    {
        this.m_ExamData = data;
        title.text = data.Title;
        ruleTitle.text = data.RuleTitle;
        content.text = data.Content;
        answer.InitData(data);
        rules.text = data.Rules;

        ShowRule(false);
    }

    public void OnSubmit()
    {
        var result = CheckResult();
        answer.HilightRight(m_ExamData.Answer);
        ShowRule(true);

        if (result)
        {
            answer.ShowRight();
        }
        else
        {
            answer.ShowError();
        }

        answer.SetInteraction(false);
    }

    public bool CheckResult()
    {
        var result = answer.GetResult();
        if (result.Length != m_ExamData.Answer.Length)
        {
            return false;
        }

        for (int i = 0; i < result.Length; i++)
        {
            if (result[i] != m_ExamData.Answer[i])
            {
                return false;
            }
        }

        return true;
    }

    void ShowRule(bool value)
    {
        ruleTitle.gameObject.SetActive(value);
        rules.gameObject.SetActive(value);
    }
}