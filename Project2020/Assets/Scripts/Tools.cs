using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tools : MonoBehaviour
{
    //UI操作
    public static void ClearChildren(Transform t)
    {
        for(int i = 0; i < t.childCount; i++)
        {
            Destroy(t.GetChild(i).gameObject);
        }
    }

    public static void SetImage(Image image,string path)
    {
        Sprite sprite = Resources.Load<Sprite>(path);
        if (sprite == null)
        {
            Debug.Log("图片不存在" + path);
        }
        else
        {
            image.sprite = sprite;
        }
    }

    public static void SetImage(GameObject go, string path)
    {
        Image image = go.GetComponent<Image>();
        if (image == null)
        {
            image = go.AddComponent<Image>();
        }
        SetImage(image, path);
    }

    public static void SetImage(Transform transform, string path)
    {
        SetImage(transform.gameObject, path);
    }

    public static void SetImage3D(MeshRenderer mr, string path)
    {
        Texture texture = Resources.Load<Texture>(path);
        if (texture == null)
        {
            Debug.Log("图片不存在" + path);
        }
        else
        {
            mr.material.mainTexture = texture;
        }
    }

    public static void SetImage3D(GameObject gameObject, string path)
    {
        MeshRenderer mr = gameObject.GetComponent<MeshRenderer>();
        if (mr == null)
        {
            mr = gameObject.AddComponent<MeshRenderer>();
        }
        SetImage3D(mr, path);
    }

    public static void SetImage3D(Transform transform, string path)
    {
        SetImage3D(transform.gameObject, path);
    }
}
