using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Events;

public class TreeView : MonoBehaviour
{
    [SerializeField] private GameObject TempletePrefab;
    public UnityEvent<SubData> OnSubBtnClick;

    public void InitFromJson(string json)
    {
        var dict = JsonConvert.DeserializeObject<TreeData[]>(json);
        foreach (var data in dict)
        {
            var go = GameObject.Instantiate(TempletePrefab, TempletePrefab.transform.parent);
            go.SetActive(true);
            var templete = go.GetComponent<TreeTemplete>();
            templete.InitData(data, OnSubBtnClick);
        }
    }
}