//
// 	ExtrasToolbar.cs
//
// 	Copyright (c) 2011 ByDesign Games SARL
// 	Joe Schultz <support@bydesigngames.com>
//
//  Usage: 	Place in any Editor sub-folder, then click on the menu entry Window -> Extras or press CMD+SHIFT+T
//  Hint: 	Fits great docked below your Inspector view! :)


using UnityEngine;
using UnityEditor;

class ExtrasToolbar : EditorWindow {
	
	bool createAsChild;

	[MenuItem ("Window/Extras #%t")]
	static void Init () 
	{
		ExtrasToolbar window = (ExtrasToolbar)EditorWindow.GetWindow (typeof (ExtrasToolbar), false, "Extras");
		window.Show();
		window.Start();
	}

	void Start ()
	{
		createAsChild = EditorPrefs.GetBool ("BDG_ExtrasToolbar_createAsChild", false);
	}

	void OnGUI () 
	{

		GUIStyle someGUIStyle = GUI.skin.GetStyle("minibutton");
		// update style to fit minimum editor window width
		someGUIStyle.padding = new RectOffset(1,1,0,0);
		someGUIStyle.overflow = new RectOffset(0,0,2,4);
		// someGUIStyle.fixedWidth = 0;
		someGUIStyle.fixedHeight = 20f;
		someGUIStyle.imagePosition = ImagePosition.ImageAbove;

		// project settings
//		Texture2D someGuiContent;
		GUIContent someGuiContent = new GUIContent();

		someGuiContent.tooltip = someGuiContent.text = "Render & Project Settings";
//		someGuiContent.image = EditorGUIUtility.Load("/d_unityeditor.projectwindow.png") as Texture2D;
		GUILayout.Label (someGuiContent, EditorStyles.boldLabel);
		GUILayout.Space(4f);

		GUILayout.BeginHorizontal ();

			someGuiContent.text = "";

			someGuiContent.tooltip = "Render Settings";
			someGuiContent.image = EditorGUIUtility.Load("icons/d_unityeditor.sceneview.png") as Texture2D;
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Render Settings");
			}

			someGuiContent.tooltip = "Input";
			someGuiContent.image = EditorGUIUtility.Load("icons/d_movetool.png") as Texture2D;
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Input");
			}

			someGuiContent.tooltip = "Tags";
			someGuiContent.image = EditorGUIUtility.Load("icons/d_unityeditor.hierarchywindow.png") as Texture2D;
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Tags");
			}

			someGuiContent.tooltip = "NavMeshLayers";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/meshrenderer icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(MeshRenderer)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/NavMeshLayers");
			}

			someGuiContent.tooltip = "Audio";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_AudioClip Icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(AudioClip)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Audio");
			}

			someGuiContent.tooltip = "Time";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_animation icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(Animation)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Time");
			}

			someGuiContent.tooltip = "Player";
			someGuiContent.image = EditorGUIUtility.Load("icons/d_unityeditor.gameview.png") as Texture2D;
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Player");
			}

			someGuiContent.tooltip = "Physics";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_PhysicMaterial Icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(PhysicMaterial)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Physics");
			}

			someGuiContent.tooltip = "Quality";
			someGuiContent.image = EditorGUIUtility.Load("icons/d_viewtoolorbit.png") as Texture2D;
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Quality");
			}

			someGuiContent.tooltip = "Network";
			someGuiContent.image = EditorGUIUtility.Load("icons/d_unityeditor.serverview.png") as Texture2D;
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Network");
			}

			someGuiContent.tooltip = "Editor";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_GUISkin Icon.png") as Texture2D;
			someGuiContent.text = "";
#else
			someGuiContent.text = "Editor";
			someGuiContent.image = null;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Editor");
			}		
		
			someGuiContent.tooltip = "Script Execution Order";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_script icon.png") as Texture2D;
			someGuiContent.text = "";
#else
			someGuiContent.text = "Order";
			someGuiContent.image = null;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				EditorApplication.ExecuteMenuItem("Edit/Project Settings/Script Execution Order");
			}		
		
		EditorGUILayout.EndHorizontal ();

		// scene settings & creation
		someGuiContent.tooltip = someGuiContent.text = "Create New";
		someGuiContent.image = null;
//		someGuiContent.image = EditorGUIUtility.Load("icons/d_unityeditor.sceneview.png") as Texture2D;
		GUILayout.Label (someGuiContent, EditorStyles.boldLabel);
		GUILayout.Space(4);

		EditorGUILayout.BeginHorizontal ();
		
			someGuiContent.text = "";

			someGuiContent.tooltip = "Particle System";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_particlerenderer icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(ParticleSystem)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Particle System" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = new GameObject ("Particle System");
					someGo.transform.parent = Selection.activeTransform;
					someGo.transform.localPosition = Vector3.zero;
					someGo.transform.localEulerAngles = new Vector3 ( -90f, 0f, 0f );
					someGo.AddComponent <ParticleSystem>();
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Particle System");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Particle System");
			}

			someGuiContent.tooltip = "Camera";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_camera icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(Camera)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Camera" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = new GameObject ("Camera");
					someGo.transform.parent = Selection.activeTransform;
					someGo.transform.localPosition = Vector3.zero;
					someGo.AddComponent <Camera>();
//					someGo.AddComponent <FlareLayer>();
					someGo.AddComponent <GUILayer>();
					someGo.AddComponent <AudioListener>();
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Camera");
#endif
					Selection.activeGameObject = someGo;
					Debug.LogWarning ( "Unity doesn't allow adding the Flare Layer component manually, so if you need Flare Layer support on your new camera, then first deselect 'Create as child' before creating your camera in Extras Toolbar!" );
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Camera");
			}
		
			someGuiContent.tooltip = "GUI Text";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.ObjectContent(null, typeof(GUIText)).image as Texture2D;
			someGuiContent.text = "GUIText";
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(GUIText)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				if ( createAsChild )
					Debug.LogWarning ( "GUIElement objects (like GUI Text & GUI Texture) exist in Screen Coordinates, so it is easier to leave them unparented!!" );
				EditorApplication.ExecuteMenuItem("GameObject/Create Other/GUI Text");
			}

			someGuiContent.tooltip = "GUI Texture";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.ObjectContent(null, typeof(GUITexture)).image as Texture2D;
			someGuiContent.text = "GUITexture";
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(GUITexture)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
				if ( createAsChild )
					Debug.LogWarning ( "GUIElement objects (like GUI Text & GUI Texture) exist in Screen Coordinates, so it is easier to leave them unparented!!" );
				EditorApplication.ExecuteMenuItem("GameObject/Create Other/GUI Texture");
			}

			someGuiContent.tooltip = "3D Text";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.ObjectContent(null, typeof(TextMesh)).image as Texture2D;
			someGuiContent.text = "3DText";
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(TextMesh)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create 3D Text" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = new GameObject ("New Text");
					someGo.transform.parent = Selection.activeTransform;
					someGo.transform.localPosition = Vector3.zero;
					TextMesh someTextMesh = someGo.AddComponent <TextMesh>();
					someTextMesh.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
					someTextMesh.text = "Hello World";
					someGo.AddComponent <MeshRenderer>();
					someGo.renderer .material = someTextMesh.font.material;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create 3D Text");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/3D Text");
			}

			someGuiContent.tooltip = "Directional Light";
			someGuiContent.text = "Dir";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_light icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(Light)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Directional Light" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = new GameObject ("Directional light");
					someGo.transform.parent = Selection.activeTransform;
					someGo.transform.localPosition = Vector3.zero;
					someGo.transform.localEulerAngles = new Vector3 ( 50f, -30f, 0f );
					Light someLight = someGo.AddComponent <Light>();
					someLight.type = LightType.Directional;
					someLight.intensity = 0.5f;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Directional Light");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Directional Light");
			}
		
			someGuiContent.tooltip = "Point Light";
			someGuiContent.text = "Point";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_light icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(Light)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Point Light" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = new GameObject ("Point light");
					someGo.transform.parent = Selection.activeTransform;
					someGo.transform.localPosition = Vector3.zero;
					Light someLight = someGo.AddComponent <Light>();
					someLight.type = LightType.Point;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Point Light");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Point Light");
			}
		
			someGuiContent.tooltip = "Spot Light";
			someGuiContent.text = "Spot";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_light icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(Light)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Spotlight" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = new GameObject ("Spotlight");
					someGo.transform.parent = Selection.activeTransform;
					someGo.transform.localPosition = Vector3.zero;
					someGo.transform.localEulerAngles = new Vector3 ( 90, 0, 0f );
					Light someLight = someGo.AddComponent <Light>();
					someLight.type = LightType.Spot;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
				Undo.RegisterCreatedObjectUndo (someGo, "Create Spotlight");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Spotlight");
			}
		
			someGuiContent.tooltip = "Area Light";
			someGuiContent.text = "Area";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_light icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(Light)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Area Light" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = new GameObject ("Area Light");
					someGo.transform.parent = Selection.activeTransform;
					someGo.transform.localPosition = Vector3.zero;
					someGo.transform.localEulerAngles = new Vector3 ( 90, 0, 0f );
					Light someLight = someGo.AddComponent <Light>();
					someLight.type = LightType.Area;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
				Undo.RegisterCreatedObjectUndo (someGo, "Create Area Light");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Area Light");
			}
		
		GUILayout.EndHorizontal ();
		
		GUILayout.Space (4);

		GUILayout.BeginHorizontal ();

			someGuiContent.text = "";

			someGuiContent.tooltip = "Cube";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_boxcollider icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(BoxCollider)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Cube" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = GameObject.CreatePrimitive (PrimitiveType.Cube);
					someGo.transform.parent = Selection.activeTransform;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
				Undo.RegisterCreatedObjectUndo (someGo, "Create Cube");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Cube");
			}

			someGuiContent.tooltip = "Sphere";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_spherecollider icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(SphereCollider)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Sphere" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = GameObject.CreatePrimitive (PrimitiveType.Sphere);
					someGo.transform.parent = Selection.activeTransform;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Sphere");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Sphere");
			}

			someGuiContent.tooltip = "Capsule";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_capsulecollider icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(CapsuleCollider)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Capsule" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = GameObject.CreatePrimitive (PrimitiveType.Capsule);
					someGo.transform.parent = Selection.activeTransform;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Capsule");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Capsule");
			}

			someGuiContent.tooltip = "Cylinder";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_prematcylinder.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(CapsuleCollider)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Cylinder" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = GameObject.CreatePrimitive (PrimitiveType.Cylinder);
					someGo.transform.parent = Selection.activeTransform;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Cylinder");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Cylinder");
			}
		
			someGuiContent.tooltip = "Plane";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/d_meshcollider icon.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(MeshCollider)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Plane" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					GameObject someGo = GameObject.CreatePrimitive (PrimitiveType.Plane);
					someGo.transform.parent = Selection.activeTransform;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Plane");
#endif
					Selection.activeGameObject = someGo;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Plane");
			}

			someGuiContent.tooltip = "Cloth";
			someGuiContent.text = "Cloth";
#if UNITY_3_5
			someGuiContent.image = EditorGUIUtility.Load("icons/clothinspector.viewvalue.png") as Texture2D;
#else
			someGuiContent.image = AssetPreview.GetMiniTypeThumbnail(typeof(Cloth)) as Texture2D;
#endif
			if ( GUILayout.Button( someGuiContent, someGUIStyle, GUILayout.MinWidth(24) ) ) {
#if UNITY_3_5 || UNITY_4_0 || UNITY_4_1 || UNITY_4_2
				Undo.RegisterSceneUndo ( "Create Cloth" );
#endif
				if ( createAsChild && Selection.activeTransform ) {
					Transform pre = Selection.activeTransform;
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Cloth");
					Cloth someGo = FindObjectOfType(typeof(Cloth)) as Cloth;
					someGo.transform.parent = pre;
#if UNITY_4_3 || UNITY_4_4 || UNITY_4_5 || UNITY_4_6 || UNITY_4_7 || UNITY_4_8 || UNITY_4_9 || UNITY_5
					Undo.RegisterCreatedObjectUndo (someGo, "Create Cloth");
#endif
					Selection.activeGameObject = someGo.gameObject;
				}
				else
					EditorApplication.ExecuteMenuItem("GameObject/Create Other/Cloth");
			}
		
		GUILayout.EndHorizontal ();

		GUILayout.Space(4f);

		GUILayout.BeginHorizontal ();
			
			createAsChild = GUILayout.Toggle (createAsChild, "Create as child");

			if ( createAsChild != EditorPrefs.GetBool ("BDG_ExtrasToolbar_createAsChild", false) )
				EditorPrefs.SetBool ("BDG_ExtrasToolbar_createAsChild", createAsChild);
				
		GUILayout.EndHorizontal ();

	}
	
	
}
