using UnityEditor;
using UnityEngine;

namespace Asteroids__Atari_.Scripts.Editor
{
    public sealed class StdSceneFoldersCreator
    {
        public static readonly string[] Folders = { "Common", "Enviroment", "Scene", "Camera", "Characters", "UI", "Other" };
#if UNITY_EDITOR
        [MenuItem("Tools/ Create Standard Folders")]
        public static void CreateStdFolders()
        {
            foreach (var f in Folders)
            {
                GameObject go = GameObject.Find(f);
                if (!go)
                {
                    Debug.Log($"Create STD Folder ===> {f}");
                    go = new GameObject(f);
                }
            }
        }
#endif
    }
}