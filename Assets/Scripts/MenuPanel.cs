using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    private TreeView m_TreeView;

    [SerializeField] private GameObject m_Image;
    [SerializeField] private TextMeshProUGUI m_Title;
    [SerializeField] private TextMeshProUGUI m_Content;
    [SerializeField] private Button m_StartBtn;
    [SerializeField] private TextAsset m_JsonAsset;

    private SubData m_SubData;
    void Awake()
    {
        var json = m_JsonAsset.text;
        m_TreeView = gameObject.GetComponentInChildren<TreeView>();
        m_TreeView.InitFromJson(json);
        m_TreeView.OnSubBtnClick.AddListener(this.OnSubClick);
        m_StartBtn.onClick.AddListener(this.OnStartClick);
    }

    private void OnSubClick(SubData data)
    {
        m_SubData = data;
        m_Title.text = data.Title;
        m_Content.text = data.Content;

        var active = !string.IsNullOrEmpty(data.Content);
        m_StartBtn.gameObject.SetActive(active);
        m_Image.SetActive(active);

    }
    
    private void OnStartClick()
    {
        if(!string.IsNullOrEmpty(m_SubData.Url))
        {
            Process.Start(m_SubData.Url);
        }
    }
}