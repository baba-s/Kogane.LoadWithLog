using System;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Kogane
{
    public static class AssetDatabaseWithLog
    {
        public delegate void OnFailureLoadAssetAtPathDelegate( string assetPath, Type type );

        public static OnFailureLoadAssetAtPathDelegate OnFailureLoadAssetAtPath { get; set; } =
            ( assetPath, type ) => Debug.LogError( $"{assetPath} に紐づく {type.Name} の AssetDatabase.LoadAssetAtPath に失敗しました" );

        public static T LoadAssetAtPath<T>( string assetPath ) where T : Object
        {
            var result = AssetDatabase.LoadAssetAtPath<T>( assetPath );

            if ( result == null )
            {
                OnFailureLoadAssetAtPath?.Invoke( assetPath, typeof( T ) );
            }

            return result;
        }
    }
}