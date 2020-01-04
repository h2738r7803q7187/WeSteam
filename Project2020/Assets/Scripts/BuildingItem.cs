using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingItem : MonoBehaviour
{
    int id = 0;
    public void Init(int id)
    {
        this.id = id;
    }

    private void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(delegate ()
        {
            Controler.BuildingID = id;
            Debug.Log(id);
        });
    }
}
