using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingItem : MonoBehaviour
{
    public static List<string> path = new List<string>() {
        "Textures/Entity/crude-oil",
        "Textures/Entity/hr-lamp",
        "Textures/Entity/hr-reactor",
        "Textures/Entity/hr-roboport-base",
        "Textures/Entity/hr-small-electric-pole",
        "Textures/Entity/hr-solar-panel",
        "Textures/Entity/hr-steel-chest",
        "Textures/Entity/hr-steel-furnace",
        "Textures/Entity/hr-wooden-chest",
        "Textures/Entity/market"
    };

    int id = 0;
    public void Init(int id)
    {
        this.id = id;
        Tools.SetImage(gameObject, path[id]);
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
