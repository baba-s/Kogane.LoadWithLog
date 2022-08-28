# Kogane Load With Log

Resources.Load や AssetDatabase.LoadAssetAtPath に失敗したらログ出力する拡張メソッド

## 使用例

```csharp
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
    private static void RuntimeInitializeOnLoadMethod()
    {
        ResourcesWithLog.OnFailureLoad = ( path, type ) =>
            Debug.LogError( $"{path} に紐づく {type.Name} の Resources.Load に失敗しました" );
    }

    private void Awake()
    {
        var sprite = ResourcesWithLog.Load<Sprite>( "" );
    }
}
```

```csharp
using Kogane;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public static class Example
{
    static Example()
    {
        AssetDatabaseWithLog.OnFailureLoadAssetAtPath = ( assetPath, type ) =>
            Debug.LogError( $"{assetPath} に紐づく {type.Name} の AssetDatabase.LoadAssetAtPath に失敗しました" );
    }

    [MenuItem( "Tools/Hoge" )]
    private static void Hoge()
    {
        var sprite = AssetDatabaseWithLog.LoadAssetAtPath<Sprite>( "" );
    }
}
```