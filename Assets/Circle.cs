using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    // 円の半径を指定します。
    [SerializeField]
    private float radius = 1;
    // 円の分割数を指定します。
    [SerializeField]
    private int segments = 4;

    void Awake()
    {
        var mesh = new Mesh();
        mesh.name = "Circle";
        // 各頂点の位置座標を計算
        List<Vector3> vertices = new List<Vector3>();
        // 円周
        for (int segment = 0; segment < segments; segment++) {
            // 角度（Θ）
            var angle = (2 * Mathf.PI / segments) * segment;
            // 円の方程式を利用して頂点位置を計算
            // x = 半径 × sin(Θ)
            // y = 半径 × cos(Θ)
            vertices.Add(new Vector3(
                radius * Mathf.Sin(angle),
                radius * Mathf.Cos(angle),
                0));
        }
        // メッシュに頂点の位置座標を設定
        mesh.SetVertices(vertices);

        // 各頂点の法線ベクトルを計算
        List<Vector3> normals = new List<Vector3>();
        for (int segment = 0; segment < segments; segment++) {
            normals.Add(new Vector3(0, 0, -1).normalized);
        }
        // メッシュに頂点の法線ベクトルを設定
        mesh.SetNormals(normals);

        // インデックス配列を設定
        List<int> indices = new List<int>();
        // 三角形の分だけループ処理
        for (int segment = 0; segment < segments - 2; segment++) {
            indices.Add(0); // 0番頂点(P0)で始めるのは固定
            indices.Add((segment + 1) % segments);
            indices.Add((segment + 2) % segments);
        }
        // メッシュに三角形リストを設定
        mesh.SetTriangles(indices, 0);

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
