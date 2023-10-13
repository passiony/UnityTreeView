using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AnswerForm : MonoBehaviour
{
    public GameObject m_OptionCell1;
    public GameObject m_OptionCell2;

    private ToggleGroup m_Group;
    private List<OptionCell> m_Cells;
    private ExamData m_ExamData;

    private void Awake()
    {
        m_Group = gameObject.GetComponent<ToggleGroup>();
    }

    public void InitData(ExamData data)
    {
        this.m_ExamData = data;
        var singleOption = data.Answer.Length == 1;
        var prefab = singleOption ? m_OptionCell1 : m_OptionCell2;
        m_Cells = new List<OptionCell>();

        for (int i = 0; i < data.Menus.Length; i++)
        {
            var go = GameObject.Instantiate(prefab, transform);
            var cell = go.GetComponent<OptionCell>();
            cell.InitData(data.Menus[i], data.Images[i]);
            cell.gameObject.SetActive(true);
            if (singleOption)
            {
                cell.m_Toggle.group = m_Group;
            }

            m_Cells.Add(cell);
        }
    }

    public int[] GetResult()
    {
        var list = new List<int>();
        for (int i = 0; i < m_Cells.Count; i++)
        {
            var cell = m_Cells[i];
            if (cell.m_Toggle.isOn)
            {
                list.Add(i + 1);
            }
        }

        return list.ToArray();
    }

    public void ShowRight()
    {
        var result = GetResult();
        foreach (var id in result)
        {
            m_Cells[id - 1].ShowError();
        }
    }

    public void ShowError()
    {
        var result = GetResult();
        foreach (var id in result)
        {
            if (!m_ExamData.Answer.Contains(id))
            {
                m_Cells[id - 1].ShowError();
            }
        }
    }

    public void HilightRight(int[] indexs)
    {
        foreach (var index in indexs)
        {
            m_Cells[index - 1].m_Text.color = Color.green;
        }
    }

    public void SetInteraction(bool value)
    {
        foreach (var cell in m_Cells)
        {
            cell.m_Toggle.interactable = value;
        }
    }
}