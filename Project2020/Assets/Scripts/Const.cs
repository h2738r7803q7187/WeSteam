using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Const : MonoBehaviour
{
    public static int sizeX = 100;
    public static int sizeZ = 100;
    public static int grid = 10;

    public static int maxX = sizeX - grid / 2;
    public static int maxZ = sizeZ - grid / 2;
    public static int minX = grid / 2;
    public static int minZ = grid / 2;
}
