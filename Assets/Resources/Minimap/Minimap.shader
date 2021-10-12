﻿Shader "Custom/Minimap"
{
    Properties
    {
        _CameraTex ("Camera Texture", 2D) = "white" {}
        _MinimapTex ("Minimap Texture", 2D) = "white" {}
    }
    SubShader
    {
        Tags
        {
            "Queue" = "Transparent+1"
		}

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            sampler2D _CameraTex;
            sampler2D _MinimapTex;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_CameraTex, i.uv) + tex2D(_MinimapTex, i.uv);
                col.a = min(col.a, 1);
                return fixed4(0, 0, 0, col.a);

                //fixed4 col = tex2D(_CameraTex, i.uv) + tex2D(_MinimapTex, i.uv);
                ////if red = 1 and blue = 1, then alpha is 0
                ////if red = 1 and blue = 0, then alpha is 0.5
                ////if red = 0 and blue = 0, then alpha is 1
                //col.a = 2.0f - (col.r * 1.5f) - (col.b * 0.5f);
                //return fixed4(0, 0, 0, col.a);
            }
            ENDCG
        }
    }
}