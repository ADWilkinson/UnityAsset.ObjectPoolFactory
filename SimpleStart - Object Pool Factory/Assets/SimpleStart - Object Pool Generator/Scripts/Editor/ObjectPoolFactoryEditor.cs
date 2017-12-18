using UnityEditor;
using UnityEngine;

/*
    Asset Title: SimpleStart - Object Pool Generator
    Version: Version: 1.0
    Author: Andrew Wilkinson
    
    Description: A simple solution for generating a custom object pooling object that will handle any amount of unique 
    objects you choose to pool. You can set how much of each object you want to have pooled in the scene and by using tags
    the pool allows runtime methods to retrieve specific objects needed from the pool and if there are none left, generate additional 
    objects if you choose to enable dynamic growth. These are the features in version 1.0, I would like to extend this to allow custom
    quantity of each individual unique object pooled rather then a blanket number for each object. Please leave feedback or suggestions 
    of what you would like me to add or imnprove on and i'll get straight back to you. 
*/ 

namespace Editor
{
    [CustomEditor(typeof(ObjectPoolFactory))]
    [CanEditMultipleObjects]
    public class ObjectPoolFactoryEditor : UnityEditor.Editor
    {
        public ObjectPoolFactory PoolFactory;

        private void OnEnable()
        {
            PoolFactory = (ObjectPoolFactory) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Object To Pool", GUILayout.Width(175));
            PoolFactory.ObjectToAdd =
                (GameObject) EditorGUILayout.ObjectField(PoolFactory.ObjectToAdd, typeof(GameObject), true);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            if (GUILayout.Button("Add Unique Object"))
            {
                PoolFactory.AddObjectToBePooled(PoolFactory.ObjectToAdd);
            }

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Object Pooler Name: ", GUILayout.Width(175));
            PoolFactory.PoolName = GUILayout.TextArea(PoolFactory.PoolName);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            PoolFactory.PoolQuantity = EditorGUILayout.IntField("# Of Each Object To Pool:", PoolFactory.PoolQuantity);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            PoolFactory.EnableGrowth = EditorGUILayout.Toggle("Enable Dynamic Pool Growth: ", PoolFactory.EnableGrowth);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            if (GUILayout.Button("Generate Pooling Object"))
            {
                PoolFactory.GeneratePoolingObject();
            }

            EditorGUILayout.Space();

            if (GUILayout.Button("Clear All"))
            {
                PoolFactory.ClearAllOptions();
            }
            
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }
    }
}