using UnityEngine;

public class RagdollController : MonoBehaviour
{
    public GameObject Prefab;

    public GameObject DoRagdoll()
    {
        var root = this.transform;
        var go = GameObject.Instantiate(this.Prefab);
        go.transform.SetParent(root.parent);
        go.gameObject.name = root.gameObject.name;

        foreach (var goTrans in go.GetComponentsInChildren<Transform>())
        {
            var ch = root.FindDeep(goTrans.name);
            if (ch != null)
            {
                CopyTransform(ch, goTrans.transform);
            }
        }

        GameObject.Destroy(this.gameObject);
        return go;
    }

    void CopyTransform(Transform src, Transform dst)
    {
        dst.localPosition = src.localPosition;
        dst.localRotation = src.localRotation;
        dst.localScale = src.localScale;
    }
}

public static class TransformDeepChildExtension
{
    public static Transform FindDeep(this Transform aParent, string aName)
    {
        if (aParent.name == aName)
        {
            return aParent;
        }

        foreach (Transform child in aParent)
        {
            var result = child.FindDeep(aName);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}