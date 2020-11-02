﻿using System.Collections.Generic;
using UnityEngine;

public class Triangle : MonoBehaviour
{
    void Awake()
    {
        var mesh = new Mesh();
        mesh.name = "Triangle";
        // 各頂点の位置座標を計算
        List<Vector3> vertices = new List<Vector3>();
        vertices.Add(new Vector3(0, 0, 0));
        vertices.Add(new Vector3(1, 1, 0));
        vertices.Add(new Vector3(1, 0, 0));
        // メッシュに頂点の位置座標を設定
        mesh.SetVertices(vertices);

        // 各頂点の法線ベクトルを計算
        List<Vector3> normals = new List<Vector3>();
        normals.Add(new Vector3(0, 0, -1).normalized);
        normals.Add(new Vector3(0, 0, -1).normalized);
        normals.Add(new Vector3(0, 0, -1).normalized);
        // メッシュに頂点の法線ベクトルを設定
        mesh.SetNormals(normals);

        // インデックス配列を設定
        List<int> indices = new List<int>();
        indices.Add(0);
        indices.Add(1);
        indices.Add(2);
        // メッシュに三角形リストを設定
        mesh.SetTriangles(indices, 0);

        GetComponent<MeshFilter>().mesh = mesh;
    }
}
