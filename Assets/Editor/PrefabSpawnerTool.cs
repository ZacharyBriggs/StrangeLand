using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PrefabSpawnerTool : EditorWindow
{
    private List<PrefabButton> _prefabButtons = new List<PrefabButton>();

    [MenuItem("Tools/SpawnerTool")]
    public static void Init()
    {
        var window = CreateInstance<PrefabSpawnerTool>();
        window.Show();
    }

    public void CreateButton()
    {
        _prefabButtons.Add(new PrefabButton());
    }

    public void DeleteButtons()
    {
        foreach (var button in _prefabButtons)
        {
            DestroyImmediate(button.SpawnedPrefab);
            DestroyImmediate(button.Prefab);
        }

        _prefabButtons = new List<PrefabButton>();
    }

    private void OnGUI()
    {
        foreach (var button in _prefabButtons)
        {
            button.Draw();
            button.PollEvents();
        }

        Repaint();
        switch (Event.current.type)
        {
            case EventType.MouseDown:
                if (Event.current.button == 1)
                {
                    var gm = new GenericMenu();
                    gm.AddItem(new GUIContent("Create Prefab"), false, CreateButton);
                    gm.AddItem(new GUIContent("Delete Buttons"), false, DeleteButtons);
                    gm.ShowAsContext();
                }

                break;
        }
    }

    public class PrefabButton
    {
        public Rect ButtonRect = new Rect(75, 75, 150, 150);
        public bool IsSelected;
        public Object Prefab;
        public Object SpawnedPrefab;

        public void Draw()
        {
            var contentRect = new Rect(ButtonRect);
            GUI.Box(ButtonRect, "Prefab Spawner");
            var spawnPos = new Vector2(contentRect.position.x, contentRect.position.y);
            GUILayout.BeginArea(contentRect);
            Prefab = EditorGUILayout.ObjectField(Prefab, typeof(GameObject), false);
            DestroyImmediate(SpawnedPrefab);
            SpawnedPrefab = Instantiate(Prefab, spawnPos, Quaternion.identity) as GameObject;
            GUILayout.TextField(contentRect.position.ToString());
            GUILayout.Toggle(IsSelected, "isSelected");
            GUILayout.EndArea();
        }

        public void PollEvents()
        {
            switch (Event.current.type)
            {
                case EventType.MouseDown:
                    if (Event.current.button == 0 && ButtonRect.Contains(Event.current.mousePosition))
                    {
                        IsSelected = true;
                        GUI.changed = true;
                    }
                    else
                    {
                        IsSelected = false;
                        GUI.changed = true;
                    }

                    break;
                case EventType.MouseDrag:
                    if (Event.current.button == 0)
                        if (IsSelected)
                        {
                            ButtonRect.position += Event.current.delta;
                            Event.current.Use();
                        }

                    break;
            }
        }
    }
}
