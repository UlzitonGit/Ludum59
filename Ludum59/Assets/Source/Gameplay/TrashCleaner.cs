using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TrashCleaner : MonoBehaviour
{
 

    public void ClearTrash()
    {
        var foundTrash = FindObjectsOfType<MonoBehaviour>().OfType<IClearable>();
        foreach (IClearable trash in foundTrash)
        {
            trash.ClearTrash();
        }
    }
}
