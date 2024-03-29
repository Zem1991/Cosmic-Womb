﻿Shader "Custom/Green Mask"
{
	Properties
	{
		_MainTex ("Base (RGB)", 2D) = "black" {}
	}

	SubShader
	{
		Pass
		{
			ZTest Always Cull Off ZWrite Off
			Fog { Mode off }

			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform float _Brightness;

			fixed4 frag (v2f_img i) : COLOR
			{
				return float4(0, 1, 0, 0);

				//float4 mainColor = tex2D(_MainTex, i.uv);
				//float3 greyScale = float3(0, 1, 0);
				////float3 greyScale = dot(mainColor.rgb, float3(0, 1, 0));
				//mainColor.rgb = greyScale;
				//return mainColor;

				//float4 mainColor = tex2D(_MainTex, i.uv);
				//float3 greyScale = dot(mainColor.rgb, float3(0.3, 0.59, 0.11)) * _Brightness;
				//mainColor.rgb = greyScale;
				//return mainColor;
			}
			ENDCG
		}
	}

	Fallback off
}