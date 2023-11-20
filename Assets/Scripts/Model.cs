using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Model
{
    internal List<Vector3Int> faces;
    List<Vector3Int> texture_index_list; //3 coords for triangle on texture
    internal List<Vector3> vertices;
    List<Vector2> texture_coordinates; //u and v Coords
    List<Vector3> normals;
    public Model()
    {
        vertices = new List<Vector3>();
        addVertices();

        faces = new List<Vector3Int>();
        addFaces();

    }
    private void addVertices()
    {
        vertices.Add(new Vector3(-4, 6, -1)); // 0
        vertices.Add(new Vector3(2, 6, -1)); // 1
        vertices.Add(new Vector3(4, 4, -1)); // 2
        vertices.Add(new Vector3(4, -4, -1)); // 3
        vertices.Add(new Vector3(2, -6, -1)); // 4
        vertices.Add(new Vector3(-4, -6, -1)); // 5
        vertices.Add(new Vector3(-2, 4, -1)); // 6
        vertices.Add(new Vector3(2, 4, -1)); // 7
        vertices.Add(new Vector3(-2, -4, -1)); // 8
        vertices.Add(new Vector3(2, -4, -1)); // 9

        // Back Vertices

        vertices.Add(new Vector3(-4, 6, 1)); // 10
        vertices.Add(new Vector3(2, 6, 1)); // 11
        vertices.Add(new Vector3(4, 4, 1)); // 12
        vertices.Add(new Vector3(4, -4, 1)); // 13
        vertices.Add(new Vector3(2, -6, 1)); // 14
        vertices.Add(new Vector3(-4, -6, 1)); // 15
        vertices.Add(new Vector3(2, 4, 1)); // 16
        vertices.Add(new Vector3(-2, 4, 1)); // 17
        vertices.Add(new Vector3(2, -4, 1)); // 18
        vertices.Add(new Vector3(-2, -4, 1)); // 19




    }

private void addFaces()
{

    // Front Faces
    faces.Add(new Vector3Int(0, 6, 1)); // 1
    faces.Add(new Vector3Int(1, 6, 7)); // 2
    faces.Add(new Vector3Int(1, 4, 3)); // 3
    faces.Add(new Vector3Int(1, 3, 2)); // 4
    faces.Add(new Vector3Int(9, 5, 4)); // 7
    faces.Add(new Vector3Int(9, 8, 5)); // 8
    faces.Add(new Vector3Int(5, 8, 0)); // 9
    faces.Add(new Vector3Int(0, 8, 6)); // 10

    // Sides

    faces.Add(new Vector3Int(2, 3, 12)); // 5
    faces.Add(new Vector3Int(12, 3, 13)); // 6
    faces.Add(new Vector3Int(10, 15, 5)); // 10
    faces.Add(new Vector3Int(0, 10, 5)); // 17

    faces.Add(new Vector3Int(8, 19, 6)); // 12
    faces.Add(new Vector3Int(6, 19, 17)); // 13
    faces.Add(new Vector3Int(7, 16, 9)); // 14
    faces.Add(new Vector3Int(9, 16, 18)); // 15

    faces.Add(new Vector3Int(0, 1, 10)); // 16
    faces.Add(new Vector3Int(0, 15, 5)); // 17

    faces.Add(new Vector3Int(17, 16, 6)); // 18
    faces.Add(new Vector3Int(16, 7, 6)); // 19

        faces.Add(new Vector3Int(19, 8, 18)); // 19
        faces.Add(new Vector3Int(18, 8, 9)); // 19
        faces.Add(new Vector3Int(12, 11, 1)); // 19
        faces.Add(new Vector3Int(1, 2, 12)); // 19
        faces.Add(new Vector3Int(14, 13, 3)); // 19
        faces.Add(new Vector3Int(3, 4, 14)); // 19
        faces.Add(new Vector3Int(0, 1, 10)); // 19
        faces.Add(new Vector3Int(0, 15, 5)); // 19
        faces.Add(new Vector3Int(1, 11, 10)); // 19
        faces.Add(new Vector3Int(4, 15, 14)); // 19
        faces.Add(new Vector3Int(5, 15, 4)); // 19
        faces.Add(new Vector3Int(10, 17, 15)); // 19
        faces.Add(new Vector3Int(11, 12, 13)); // 19
        faces.Add(new Vector3Int(17, 11, 16)); // 19
        faces.Add(new Vector3Int(17, 19, 15)); // 19

        // Back Faces

        faces.Add(new Vector3Int(10, 11, 17)); // 11
    faces.Add(new Vector3Int(15, 19, 18)); // 11
    faces.Add(new Vector3Int(15, 18, 14)); // 11
    faces.Add(new Vector3Int(11, 13, 14)); // 11
    
}

    public GameObject CreateUnityGameObject()
    {
        Mesh mesh = new Mesh();
        GameObject newGO = new GameObject();

        MeshFilter mesh_filter = newGO.AddComponent<MeshFilter>();
        MeshRenderer mesh_renderer = newGO.AddComponent<MeshRenderer>();

        List<Vector3> coords = new List<Vector3>();
        List<int> dummy_indices = new List<int>();
        /*List<Vector2> text_coords = new List<Vector2>();
        List<Vector3> normals = new List<Vector3>();*/

        for (int i = 0; i < faces.Count; i++)
        {
            //Vector3 normal_for_face = normals[i];

            //normal_for_face = new Vector3(normal_for_face.x, normal_for_face.y, -normal_for_face.z);

            coords.Add(vertices[faces[i].x]); dummy_indices.Add(i * 3); //text_coords.Add(texture_coordinates[texture_index_list[i].x]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].y]); dummy_indices.Add(i * 3 + 2); //text_coords.Add(texture_coordinates[texture_index_list[i].y]); normalz.Add(normal_for_face);

            coords.Add(vertices[faces[i].z]); dummy_indices.Add(i * 3 + 1); //text_coords.Add(texture_coordinates[texture_index_list[i].z]); normalz.Add(normal_for_face);
        }

        mesh.vertices = coords.ToArray();
        mesh.triangles = dummy_indices.ToArray();
        /*mesh.uv = text_coords.ToArray();
        mesh.normals = normalz.ToArray();*/
        mesh_filter.mesh = mesh;

        return newGO;
    }

}
