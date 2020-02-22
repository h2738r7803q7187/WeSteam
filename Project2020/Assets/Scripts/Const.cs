using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const : MonoBehaviour
{
    public static float sizeX = 200;//地图横向范围
    public static float sizeZ = 100;//地图纵向范围
    public static float grid = 1;//地图各自大小

    public static float maxX = sizeX - grid / 2;
    public static float maxZ = sizeZ - grid / 2;
    public static float minX = grid / 2;
    public static float minZ = grid / 2;
    public static float startX = 0;//初始坐标X
    public static float startZ = 0;//初始坐标Z

    //资源坐标
    public static List<Vector2> resources = new List<Vector2>(){
        new Vector2(1,8),
        new Vector2(2,2),
        new Vector2(3,4),
        new Vector2(4,6),
        new Vector2(5,5),
        new Vector2(6,3),
        new Vector2(7,7),
        new Vector2(8,1)
    };
}
