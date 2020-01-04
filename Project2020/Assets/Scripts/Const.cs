using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const : MonoBehaviour
{
    public static float sizeX = 200;
    public static float sizeZ = 100;
    public static float grid = 1;

    public static float maxX = sizeX - grid / 2;
    public static float maxZ = sizeZ - grid / 2;
    public static float minX = grid / 2;
    public static float minZ = grid / 2;
    public static float startX = 0;
    public static float startZ = 0;
}
