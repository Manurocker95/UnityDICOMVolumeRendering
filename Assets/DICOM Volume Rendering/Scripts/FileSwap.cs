using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class FileSwap : MonoBehaviour
{


#if UNITY_EDITOR
    // Start is called before the first frame update
    void Start()
    {
        Parse();
    }

    public void Parse()
    {
        string path = EditorUtility.OpenFolderPanel("Select the DICOM folder", Application.dataPath, "");
        if (!string.IsNullOrEmpty(path))
        {
            string savepath = EditorUtility.OpenFolderPanel("Select the save folder", Application.dataPath, "");
            if (!string.IsNullOrEmpty(savepath))
            {
                var files = System.IO.Directory.GetFiles(path);
                foreach (var file in files)
                {
                    System.IO.File.Copy(file, savepath+"/"+System.IO.Path.GetFileName(file)+".dcm", true);
                }
                AssetDatabase.Refresh();
            }
        }
    }

#endif
}
