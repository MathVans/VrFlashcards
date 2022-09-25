using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Webloader : MonoBehaviour
{
    // Start is called before the first frame update
    public string BundleUrl = "http://localhost/Assetbundles/Inserir_um_subtítulo.mp4";
    public string Bundlename = "Bundle Object";
    IEnumerator Start()
    {
        using (WWW web = new WWW(BundleUrl))
        {
            yield return web;

            AssetBundle assetBundle = web.assetBundle;
            if(assetBundle == null)
            {
                //Debug.LogError("Failed to download AssetBundle!!");
                yield break;

            }
            else
            {

            }



        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
