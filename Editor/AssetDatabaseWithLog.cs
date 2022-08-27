using UnityEditor;
using UnityEngine;

namespace Kogane
{
    public static class AssetDatabaseWithLog
    {
        public static T LoadAssetAtPath<T>( string assetPath ) where T : Object
        {
            var result = AssetDatabase.LoadAssetAtPath<T>( assetPath );

            if ( result == null )
            {
                Debug.LogWarning( $"{assetPath} に紐づく {typeof( T ).Name} の AssetDatabase.LoadAssetAtPath に失敗しました" );
            }

            return result;
        }
    }
}