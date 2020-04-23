Shader "Onoty3D/Toon/Basic Cutout Outline" {
	Properties{
		_Color("Main Color", Color) = (.5,.5,.5,1)
		_MainTex("Base (RGB)", 2D) = "white" { }
		_ToonShade("ToonShader Cubemap(RGB)", CUBE) = "" { }
		_Cutoff("Alpha Cutoff", Range(0,1)) = 0.5
		_OutlineColor("Outline Color", Color) = (0,0,0,1)
		_Outline("Outline width", Range(.00001, 0.03)) = .005
		_CutoffOutline("Outline Alpha Cutoff", Range(0,1)) = 0.5
		_OutlineZOffset("Outline Z Offset", Range(-1,1)) = 0.001
	}

	CGINCLUDE
#include "UnityCG.cginc"

	struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
		float2 texcoord : TEXCOORD0;
	};

	struct v2f {
		float4 pos : SV_POSITION;
		UNITY_FOG_COORDS(0)
		fixed4 color : COLOR;
		float2 texcoord : TEXCOORD0;
	};

	uniform float4 _Color;
	uniform float _Outline;
	uniform float4 _OutlineColor;
	sampler2D _MainTex;
	float4 _MainTex_ST;
	fixed _Cutoff;
	fixed _CutoffOutline;
	fixed _OutlineZOffset;

	v2f vert(appdata v) {
		v2f o;
		o.pos = UnityObjectToClipPos(v.vertex);

		float3 norm = normalize(mul((float3x3)UNITY_MATRIX_IT_MV, v.normal));
		float2 offset = TransformViewToProjection(norm.xy);

		o.pos.xy += offset * o.pos.z * _Outline;
		o.pos.z += _OutlineZOffset;
		o.color = _OutlineColor;
		UNITY_TRANSFER_FOG(o, o.pos);
		o.texcoord = TRANSFORM_TEX(v.texcoord, _MainTex);
		return o;
	}
	ENDCG

	SubShader{
		Tags{ "RenderType" = "Opaque" }
		UsePass "Onoty3D/Toon/Basic Cutout/BASE"
		Pass{
			Name "OUTLINE"
			Tags{ "LightMode" = "Always" }
			Cull Off
			ZWrite On
			ColorMask RGB
			Blend SrcAlpha OneMinusSrcAlpha

			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
#pragma multi_compile_fog
			fixed4 frag(v2f i) : SV_Target
			{
				UNITY_APPLY_FOG(i.fogCoord, i.color);
				float4 col = _Color * tex2D(_MainTex, i.texcoord);
				clip(col.a - _CutoffOutline);
				return i.color;
			}
			ENDCG
		}
	}

	Fallback "Onoty3D/Toon/Basic Cutout"
}