using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class MapInit : MonoBehaviour
{
    public HexagonMesh grid;
    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random(1);
        for (int i = -20; i < 20; i++)
        {
            for (int j = -20; j < 20; j++)
            {
                if (random.Next(0, 3) < 1)
                {
                    HexagonGrid H = Instantiate(grid.gameObject).GetComponent<HexagonGrid>();
                    H.x = i;
                    H.y = j;
                }
            }
        }
    }
}
