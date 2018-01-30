using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Water : MonoBehaviour {
    [Header("Rất quan trọng")]
    [Tooltip("Càng nhiều càng đẹp nhưng sẽ càng lag, nên để là 5")]
    public int NodeKCount;
    //Our physics arrays
    float[] xpositions;
    float[] ypositions;
    float[] velocities;
    float[] accelerations;

    //Our meshes and colliders
    GameObject[] meshobjects;
    GameObject[] colliders;
    Mesh[] meshes;
    [Header("Particle nước bắn lên")]
    public GameObject splash;
    private Vector2 normalSize;
    [Header("Material của nước")]
    public Material mat;
    [Header("Càng cao thì lực tương tác của vật thể và nước sẽ càng nhỏ")]
    [Tooltip("Rất quan trọng, nên để là 30")]
    public float decreaseMass;
    //The GameObject we're using for a mesh
    public GameObject watermesh;

    //All our constants
    const float springconstant = 0.02f;
    const float damping = 0.04f;
    const float spread = 0.05f;
    const float z = -1f;

    //The properties of our water
    float baseheight;
    float left;
    float bottom;
    [Header("độ biến thiên của mặt nước khi độ cao của sóng thay đổi")]
    public float SurfaceLevelCoefficient;
    [Header ("Lực nâng của nước")]
    public float WaterDensity;
    [Tooltip("Số lần chạy của các hàm set vị trí trong fixed update , lưu ý là càng lớn thì sóng sẽ chuyển động càng mượt nhưng càng lag")]
    public int RunCount;
    void Start()
    {
        SpawnWater(-10,20,0,-10);
    }

    public void Splash(float xpos, float velocity)
    {
        //If the position is within the bounds of the water:
        if (xpos >= xpositions[0] && xpos <= xpositions[xpositions.Length-1])
        {
            //Offset the x position to be the distance from the left side
            xpos -= xpositions[0];

            //Find which spring we're touching
            int index = Mathf.RoundToInt((xpositions.Length-1)*(xpos / (xpositions[xpositions.Length-1] - xpositions[0])));

            //Add the velocity of the falling object to the spring
            velocities[index] += velocity;

            //Set the lifetime of the particle system.
            float lifetime = 0.93f + Mathf.Abs(velocity)*0.07f;
            if (splash == null) {
                return;
            }
            //Set the splash to be between two values in Shuriken by setting it twice.
            splash.GetComponent<ParticleSystem>().startSpeed = 8+2*Mathf.Pow(Mathf.Abs(velocity),0.5f);
            splash.GetComponent<ParticleSystem>().startSpeed = 9 + 2 * Mathf.Pow(Mathf.Abs(velocity), 0.5f);
            splash.GetComponent<ParticleSystem>().startLifetime = lifetime;

            //Set the correct position of the particle system.
            Vector3 position = new Vector3(xpositions[index],ypositions[index]-0.35f,5);

            //This line aims the splash towards the middle. Only use for small bodies of water:
            Quaternion rotation = Quaternion.LookRotation(new Vector3(xpositions[Mathf.FloorToInt(xpositions.Length / 2)], baseheight + 8, 5) - position);
            
            //Create the splash and tell it to destroy itself.
            GameObject splish = Instantiate(splash,position,rotation) as GameObject;
            Destroy(splish, lifetime+0.3f);
        }
    }

    public void SpawnWater(float Left, float Width, float Top, float Bottom)
    {
        //Bonus exercise: Add a box collider to the water that will allow things to float in it.
        gameObject.AddComponent<BoxCollider2D>();
        gameObject.GetComponent<BoxCollider2D>().offset = new Vector2(Left + Width / 2, (Top + Bottom) / 2);
        gameObject.GetComponent<BoxCollider2D>().size = new Vector2(Width, Top - Bottom);
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

        //Calculating the number of edges and nodes we have
        int edgecount = Mathf.RoundToInt(Width) * NodeKCount;
        int nodecount = edgecount + 1;
        
        //Declare our physics arrays
        xpositions = new float[nodecount];
        ypositions = new float[nodecount];
        velocities = new float[nodecount];
        accelerations = new float[nodecount];
        
        //Declare our mesh arrays
        meshobjects = new GameObject[edgecount];
        meshes = new Mesh[edgecount];
        colliders = new GameObject[edgecount];

        //Set our variables
        baseheight = Top;
        bottom = Bottom;
        left = Left;

        //For each node, set the line renderer and our physics arrays
        for (int i = 0; i < nodecount; i++)
        {
            ypositions[i] = Top;
            xpositions[i] = Left + Width * i / edgecount;
            // Body.SetPosition(i, new Vector3(xpositions[i], Top, z));
            accelerations[i] = 0;
            velocities[i] = 0;
        }
        normalSize = new Vector2(xpositions[0], Top);
        //Setting the meshes now:
        for (int i = 0; i < edgecount; i++)
        {
            //Make the mesh
            meshes[i] = new Mesh();

            //Create the corners of the mesh
            Vector3[] Vertices = new Vector3[4];
            Vertices[0] = new Vector3(xpositions[i], ypositions[i], z);
            Vertices[1] = new Vector3(xpositions[i + 1], ypositions[i + 1], z);
            Vertices[2] = new Vector3(xpositions[i], bottom, z);
            Vertices[3] = new Vector3(xpositions[i+1], bottom, z);

            //Set the UVs of the texture
            Vector2[] UVs = new Vector2[4];
            UVs[0] = new Vector2(0, 1);
            UVs[1] = new Vector2(1, 1);
            UVs[2] = new Vector2(0, 0);
            UVs[3] = new Vector2(1, 0);

            //Set where the triangles should be.
            int[] tris = new int[6] { 0, 1, 3, 3, 2, 0};

            //Add all this data to the mesh.
            meshes[i].vertices = Vertices;
            meshes[i].uv = UVs;
            meshes[i].triangles = tris;

            //Create a holder for the mesh, set it to be the manager's child
            meshobjects[i] = Instantiate(watermesh,Vector3.zero,Quaternion.identity) as GameObject;
            meshobjects[i].GetComponent<MeshFilter>().mesh = meshes[i];
            BoxCollider2D box2d = meshobjects[i].AddComponent<BoxCollider2D>();
            box2d.isTrigger = true;
            box2d.usedByEffector = true;
            BuoyancyEffector2D bouyancy = meshobjects[i].AddComponent<BuoyancyEffector2D>();
            bouyancy.density = WaterDensity;
            bouyancy.surfaceLevel = 1f;
            meshobjects[i].transform.parent = transform;

            //Create our colliders, set them be our child
            colliders[i] = new GameObject();
            colliders[i].name = "Trigger";
            BoxCollider2D trigger = colliders[i].AddComponent<BoxCollider2D>();
            colliders[i].layer = 18; // Monster
            trigger.size = new Vector2(1, 0.5f);
            trigger.offset = new Vector2(0, 0.25f);
            colliders[i].transform.parent = transform;

            //Set the position and scale to the correct dimensions
            colliders[i].transform.position = new Vector3(Left + Width * (i + 0.5f) / edgecount, Top - 0.5f, 0);
            colliders[i].transform.localScale = new Vector3(Width / edgecount, 1, 1);

            //Add a WaterDetector and make sure they're triggers
            colliders[i].GetComponent<BoxCollider2D>().isTrigger = true;
            colliders[i].AddComponent<WaterDetector>();

        }
    }

    //Same as the code from in the meshes before, set the new mesh positions
    void UpdateMeshes()
    {
        for (int i = 0; i < meshes.Length; i++)
        {
            Vector3[] Vertices = new Vector3[4];
            Vertices[0] = new Vector3(xpositions[i], ypositions[i], z);
            Vertices[1] = new Vector3(xpositions[i+1], ypositions[i+1], z);
            Vertices[2] = new Vector3(xpositions[i], bottom, z);
            Vertices[3] = new Vector3(xpositions[i+1], bottom, z);
            meshes[i].vertices = Vertices;
            meshobjects[i].GetComponent<BuoyancyEffector2D>().surfaceLevel = normalSize.y + ((ypositions[i]) - normalSize.y) * SurfaceLevelCoefficient;
        }
    }

    void FixedUpdate()
    {
        //Here we use the Euler method to handle all the physics of our springs:
        for (int i = 0; i < xpositions.Length ; i++)
        {
            float force = (springconstant * (ypositions[i] - baseheight) + velocities[i]*damping);
            accelerations[i] = (-force);
            ypositions[i] += velocities[i];
            velocities[i] += accelerations[i];
        }   

        //Now we store the difference in heights:
        float[] leftDeltas = new float[xpositions.Length];
        float[] rightDeltas = new float[xpositions.Length];

        // sẽ dĩ chạy nhiều lần là để cho nó được mượt hơn, nếu như với tốc độ của fixed update thì vẫn chưa đủ mượt
        for (int j = 0; j < RunCount; j++)
        {
            for (int i = 0; i < xpositions.Length; i++)
            {
                //We check the heights of the nearby nodes, adjust velocities accordingly, record the height differences
                if (i > 0)
                {
                    leftDeltas[i] = spread * (ypositions[i] - ypositions[i-1]);
                    velocities[i - 1] += leftDeltas[i];
                }
                if (i < xpositions.Length - 1)
                {
                    rightDeltas[i] = spread * (ypositions[i] - ypositions[i + 1]);
                    velocities[i + 1] += rightDeltas[i];
                }
            }

            // lưu lại các thay đổi về vị trí của mesh
            for (int i = 0; i < xpositions.Length; i++)
            {
                if (i > 0)
                    ypositions[i-1] += leftDeltas[i];
                if (i < xpositions.Length - 1)
                    ypositions[i + 1] += rightDeltas[i];
            }
        }
        // update lại vị trí của các mesh
        UpdateMeshes();
	}
}