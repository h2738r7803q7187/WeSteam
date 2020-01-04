using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public Button BuildingBtn;
    public Button BuildingBack;
    
    public Transform BuildingUI;
    public Transform BuildingContent;
    public BuildingItem BuildingItem;
    // Start is called before the first frame update
    void Start()
    {
        BuildingBtn.onClick.AddListener(ShowBuildingUI);
        BuildingBack.onClick.AddListener(HideBuildingUI);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowBuildingUI()
    {
        BuildingUI.gameObject.SetActive(true);
        for (int i = 0; i < 10; i++)
        {
            Transform t = Instantiate(BuildingItem.transform, BuildingContent);
            t.gameObject.SetActive(true);
            t.GetComponent<BuildingItem>().Init(i);
        }
    }

    void HideBuildingUI()
    {
        BuildingUI.gameObject.SetActive(false);
        Tools.ClearChildren(BuildingContent);
    }


}
