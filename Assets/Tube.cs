using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    // チューブの高さを指定します。
    [SerializeField]
    float height = 2;
    // 円周の半径を指定します。
    [SerializeField]
    float radius = 1;
    // 円周の分割数を指定します。
    [SerializeField]
    int divideCount = 16;

    void Awake()
    {
        var mesh = new Mesh();
        mesh.name = "Tube";

        var vertices = new List<Vector3>(); // 各頂点の位置座標
        var normals = new List<Vector3>();  // 各頂点の法線ベクトル
        var uvs = new List<Vector2>();      // 各頂点のUV座標
        for (int index = 0; index <= divideCount; index++)
        {
            var angle = index * 2 * Mathf.PI / divideCount;
            // 法線ベクトルを計算
            var normal = new Vector3(-radius * Mathf.Sin(angle), -radius * Mathf.Cos(angle), 0);
            normal.Normalize();
            // 奥
            vertices.Add(new Vector3(radius * Mathf.Sin(angle), radius * Mathf.Cos(angle), height / 2));
            normals.Add(normal);
            uvs.Add(new Vector2(index / (float)divideCount, 0));
            // 手前
            vertices.Add(new Vector3(radius * Mathf.Sin(angle), radius * Mathf.Cos(angle), -height / 2));
            normals.Add(normal);
            uvs.Add(new Vector2(index / (float)divideCount, 1));
        }
        // メッシュに頂点の位置座標を設定
        mesh.SetVertices(vertices);
        // メッシュに頂点の法線ベクトルを設定
        mesh.SetNormals(normals);
        // メッシュに頂点のUV座標を設定
        mesh.SetUVs(0, uvs);

        // インデックス配列を設定
        List<int> indices = new List<int>();
        for (int index = 0; index < divideCount; index++)
        {
            indices.Add(2 * index);
            indices.Add(2 * index + 1);
            indices.Add(2 * (index + 1));

            indices.Add((2 * (index + 1) + 1));
            indices.Add(2 * (index + 1));
            indices.Add((2 * index + 1));
        }
        // メッシュに三角形リストを設定
        mesh.SetTriangles(indices, 0);

        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, -Time.time);
    }
}
