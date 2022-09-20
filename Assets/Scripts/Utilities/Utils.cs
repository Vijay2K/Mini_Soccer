using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utils
{
    public static IEnumerator PopupAnim(GameObject obj, float animSpeed)
    {
        float lerp = 0;
        obj.transform.localScale = Vector3.zero;

        do
        {
            lerp += Time.deltaTime * animSpeed;
            obj.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, lerp);
            yield return null;
        } while (lerp < 1);
    }

    public static IEnumerator PopdownAnim(GameObject obj, float animSpeed)
    {
        float lerp = 0;
        obj.transform.localScale = Vector3.one;
        
        do
        {
            lerp += Time.deltaTime * animSpeed;
            obj.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.zero, lerp);
            yield return null;
        } while (lerp < 1);
    }
}
