using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    // 円柱の高さを指定します。
    [SerializeField]
    private float height = 1;
    // 円の半径を指定します。
    [SerializeField]
    private float radius = 1;
    // 円の分割数を指定します。
    [SerializeField]
    private int segments = 4;

    void Awake()
    {
        var mesh = new Mesh();
        mesh.name = "Cylinder";
        // 各頂点の位置座標を計算
        List<Vector3> vertices = new List<Vector3>();
        // 側面の頂点
        for (int segment = 0; segment < segments; segment++) {
            // 角度（Θ）
            var angle = (2 * Mathf.PI / segments) * segment;
            // 円の方程式を利用してtop側、bottom側の順番に頂点を追加
            vertices.Add(new Vector3(radius * Mathf.Sin(angle), height, radius * Mathf.Cos(angle)));
            vertices.Add(new Vector3(radius * Mathf.Sin(angle), -height, radius * Mathf.Cos(angle)));
        }
        // top面の頂点の開始位置を保存
        var topVertexOffset = vertices.Count;
        // top面の頂点
        for (int segment = 0; segment < segments; segment++) {
            // 角度（Θ）
            var angle = (2 * Mathf.PI / segments) * segment;
            // 円の方程式を利用してtop側、bottom側の順番に頂点を追加
            vertices.Add(new Vector3(radius * Mathf.Sin(angle), height, radius * Mathf.Cos(angle)));
        }
        // bottom面の頂点の開始位置を保存
        var bottomVertexOffset = vertices.Count;
        // bottom面の頂点
        for (int segment = 0; segment < segments; segment++) {
            // 角度（Θ）
            var angle = (2 * Mathf.PI / segments) * segment;
            // 円の方程式を利用してtop側、bottom側の順番に頂点を追加
            vertices.Add(new Vector3(radius * Mathf.Sin(angle), -height, radius * Mathf.Cos(angle)));
        }
        // メッシュに頂点の位置座標を設定
        mesh.SetVertices(vertices);

        // 各頂点の法線ベクトルを計算
        List<Vector3> normals = new List<Vector3>();
        // 側面の法線ベクトル
        for (int segment = 0; segment < segments; segment++) {
            // 角度（Θ）
            var angle = (2 * Mathf.PI / segments) * segment;
            // 法線ベクトル
            var normal = new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
            normal.Normalize();
            // topとbottom側それぞれに追加
            normals.Add(normal);
            normals.Add(normal);
        }
        // top面の法線ベクトル
        for (int segment = 0; segment < segments; segment++) {
            // 角度（Θ）
            var angle = (2 * Mathf.PI / segments) * segment;
            // 法線ベクトルを追加
            normals.Add(new Vector3(0, 1, 0));
        }
        // bottom面の法線ベクトル
        for (int segment = 0; segment < segments; segment++) {
            // 角度（Θ）
            var angle = (2 * Mathf.PI / segments) * segment;
            // 法線ベクトルを追加
            normals.Add(new Vector3(0, -1, 0));
        }

        // メッシュに頂点の法線ベクトルを設定
        mesh.SetNormals(normals);

        // インデックス配列を設定
        List<int> indices = new List<int>();
        // 側面の分だけループ処理
        for (int segment = 0; segment < segments; segment++) {
            indices.Add((0 + 2 * segment) % (2 * segments));
            indices.Add((1 + 2 * segment) % (2 * segments));
            indices.Add((2 + 2 * segment) % (2 * segments));
            indices.Add((3 + 2 * segment) % (2 * segments));
            indices.Add((2 + 2 * segment) % (2 * segments));
            indices.Add((1 + 2 * segment) % (2 * segments));
        }
        // top面の分だけループ処理
        for (int segment = 0; segment < segments - 2; segment++) {
            indices.Add(0 + topVertexOffset); // 0番頂点(P0)で始めるのは固定
            indices.Add((segment + 1) % segments + topVertexOffset);
            indices.Add((segment + 2) % segments + topVertexOffset);
        }
        // bottom面の分だけループ処理
        for (int segment = 0; segment < segments - 2; segment++) {
            indices.Add(0 + bottomVertexOffset); // 0番頂点(P0)で始めるのは固定
            indices.Add((segment + 2) % segments + bottomVertexOffset);
            indices.Add((segment + 1) % segments + bottomVertexOffset);
        }
        // メッシュに三角形リストを設定
        mesh.SetTriangles(indices, 0);

        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1), 10 * Time.deltaTime);
    }
}
