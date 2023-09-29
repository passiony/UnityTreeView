using System.Diagnostics;
using TMPro;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
    private TreeView m_TreeView;

    [SerializeField] private TextMeshProUGUI m_Title;
    [SerializeField] private TextMeshProUGUI m_Content;
    [SerializeField] private TextAsset m_JsonAsset;

    void Awake()
    {
        var json = m_JsonAsset.text;
        m_TreeView = gameObject.GetComponentInChildren<TreeView>();
        m_TreeView.InitFromJson(json);
        m_TreeView.OnSubBtnClick.AddListener(this.OnSubClick);
    }

    private void OnSubClick(SubData data)
    {
        m_Title.text = data.Title;
        m_Content.text = data.Content;

        Process.Start(data.Url);
    }
}