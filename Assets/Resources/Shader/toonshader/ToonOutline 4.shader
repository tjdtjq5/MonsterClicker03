Shader "Onoty3D/Toon/Lit Cutout Outline" {
	Properties {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {}
		[Enum(OFF,0,FRONT,1,BACK,2)] _CullMode("Cull Mode", int) = 2 //OFF/FRONT/BACK
		_Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline width", Range(.00001, 0.03)) = .005
		_CutoffOutline("Outline Alpha Cutoff", Range(0,1)) = 0.5
		_OutlineZOffset("Outline Z Offset", Range(-1,1)) = 0.001

	}

	SubShader {
		Tags{ "RenderType" = "Opaque" }
		UsePass "Onoty3D/Toon/Lit Cutout/FORWARD"
		UsePass "Onoty3D/Toon/Basic Cutout Outline/OUTLINE"
	} 
	
	Fallback "Onoty3D/Toon/Lit Cutout"
}