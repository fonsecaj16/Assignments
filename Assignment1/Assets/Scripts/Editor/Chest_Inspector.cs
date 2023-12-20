using UnityEditor;
using UnityEngine;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

[CustomEditor(typeof(Chest))]
public class Chest_Inspector : Editor
{
    public VisualTreeAsset m_InspectorXML;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (ShouldDisplay())
        {
            EditorGUILayout.HelpBox("Error: The sum of probabilities is not 100%", MessageType.Error);
        }
    }

    private bool ShouldDisplay()
    {
        Chest chest = (Chest)target;

        float sum = 0;
        foreach (Item item in chest.itemList)
        {
            sum += item.probability;
        }
        
        return sum != 100;
    }
}
