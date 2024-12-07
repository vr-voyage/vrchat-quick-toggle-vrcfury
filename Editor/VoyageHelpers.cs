#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using com.vrcfury.api;

public class VoyageAvatarEditorHelpers
{

    public static void AddVRCFuryToggleTo(GameObject go)
    {
        if (go == null) return;


        var toggle = FuryComponents.CreateToggle(go);
        toggle.GetActions().AddTurnOn(go);
        toggle.SetMenuPath($"Toggles/{go.name}");
        if (go.activeInHierarchy)
        {
            toggle.SetDefaultOn();
        }
    }

    [MenuItem("GameObject/Voyage/Individual Toggle (VRC Fury)")]
    public static void ToggleThroughMenuVRC(MenuCommand menuCommand)
    {
        if (menuCommand.context != Selection.activeObject) return;

        var selectedGameObjects = Selection.gameObjects;
        if (selectedGameObjects == null || selectedGameObjects.Length == 0)
        {
            return;
        }

        foreach (GameObject go in selectedGameObjects)
        {
            AddVRCFuryToggleTo(go);
        }
    }

    
}
#endif