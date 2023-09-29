using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TreeTemplete : MonoBehaviour
{
    private readonly Vector3 OpenAngle = new (0, 0, -90);
    private readonly Vector3 CloseAngle = new (0, 0, 0);
    
    private GameObject m_SubBtnPrefab;
    private Button m_Button;
    private TextMeshProUGUI m_Lable;
    private Transform m_Image;
    
    private List<SubButton> m_List = new List<SubButton>();
    private TreeData m_Data;
    private bool m_Open;

    void Awake()
    {
        m_SubBtnPrefab = transform.Find("SubButton").gameObject;
        m_Button = transform.Find("MainButton").GetComponent<Button>();
        m_Lable = m_Button.GetComponentInChildren<TextMeshProUGUI>();
        m_Image = m_Button.transform.Find("Image");

        m_Button.onClick.AddListener(OnBtnClick);
    }

    private void OnBtnClick()
    {
        m_Open = !m_Open;
        m_Image.localEulerAngles = m_Open ? OpenAngle : CloseAngle;
        foreach (var chid in m_List)
        {
            chid.gameObject.SetActive(m_Open);
        }

        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
    }

    public void InitData(TreeData data, UnityEvent<SubData> callback)
    {
        m_Data = data;
        m_Lable.text = data.Name;
        m_Open = false;

        //child
        foreach (var subData in data.Childs)
        {
            var go = GameObject.Instantiate(m_SubBtnPrefab, transform);
            var sub = go.GetComponent<SubButton>();
            sub.InitData(data.Name, subData, callback);
            go.SetActive(false);

            m_List.Add(sub);
        }

        m_SubBtnPrefab.SetActive(false);
        LayoutRebuilder.ForceRebuildLayoutImmediate(transform as RectTransform);
    }
}