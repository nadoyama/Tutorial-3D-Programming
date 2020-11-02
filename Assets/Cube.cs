using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    void Awake()
    {
        var mesh = new Mesh();
        mesh.name = "Cube";
        // 各頂点の位置座標を計算
        List<Vector3> vertices = new List<Vector3>();
        // Front
        vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
        vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
        vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
        vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
        // Back
        vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
        vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
        vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
        vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
        // Right
        vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
        vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
        vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
        vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
        // Left
        vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
        vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
        vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
        vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
        // Top
        vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
        vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
        vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
        vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
        // Bottom
        vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
        vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
        vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
        vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
        // メッシュに頂点の位置座標を設定
        mesh.SetVertices(vertices);

        // 各頂点の法線ベクトルを計算
        List<Vector3> normals = new List<Vector3>();
        // Front
        normals.Add(new Vector3(0, 0, 1).normalized);
        normals.Add(new Vector3(0, 0, 1).normalized);
        normals.Add(new Vector3(0, 0, 1).normalized);
        normals.Add(new Vector3(0, 0, 1).normalized);
        // Back
        normals.Add(new Vector3(0, 0, -1).normalized);
        normals.Add(new Vector3(0, 0, -1).normalized);
        normals.Add(new Vector3(0, 0, -1).normalized);
        normals.Add(new Vector3(0, 0, -1).normalized);
        // Right
        normals.Add(new Vector3(1, 0, 0).normalized);
        normals.Add(new Vector3(1, 0, 0).normalized);
        normals.Add(new Vector3(1, 0, 0).normalized);
        normals.Add(new Vector3(1, 0, 0).normalized);
        // Left
        normals.Add(new Vector3(-1, 0, 0).normalized);
        normals.Add(new Vector3(-1, 0, 0).normalized);
        normals.Add(new Vector3(-1, 0, 0).normalized);
        normals.Add(new Vector3(-1, 0, 0).normalized);
        // Top
        normals.Add(new Vector3(0, 1, 0).normalized);
        normals.Add(new Vector3(0, 1, 0).normalized);
        normals.Add(new Vector3(0, 1, 0).normalized);
        normals.Add(new Vector3(0, 1, 0).normalized);
        // Bottom
        normals.Add(new Vector3(0, -1, 0).normalized);
        normals.Add(new Vector3(0, -1, 0).normalized);
        normals.Add(new Vector3(0, -1, 0).normalized);
        normals.Add(new Vector3(0, -1, 0).normalized);
        // メッシュに頂点の法線ベクトルを設定
        mesh.SetNormals(normals);

        // インデックス配列を設定
        List<int> indices = new List<int>();
        // Back
        indices.Add(0);
        indices.Add(1);
        indices.Add(2);
        indices.Add(3);
        indices.Add(2);
        indices.Add(1);
        // Front
        indices.Add(4);
        indices.Add(5);
        indices.Add(6);
        indices.Add(7);
        indices.Add(6);
        indices.Add(5);
        // Right
        indices.Add(8);
        indices.Add(9);
        indices.Add(10);
        indices.Add(11);
        indices.Add(10);
        indices.Add(9);
        // Left
        indices.Add(12);
        indices.Add(13);
        indices.Add(14);
        indices.Add(15);
        indices.Add(14);
        indices.Add(13);
        // Top
        indices.Add(16);
        indices.Add(17);
        indices.Add(18);
        indices.Add(19);
        indices.Add(18);
        indices.Add(17);
        // Bottom
        indices.Add(20);
        indices.Add(21);
        indices.Add(22);
        indices.Add(23);
        indices.Add(22);
        indices.Add(21);
        // メッシュに三角形リストを設定
        mesh.SetTriangles(indices, 0);

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
