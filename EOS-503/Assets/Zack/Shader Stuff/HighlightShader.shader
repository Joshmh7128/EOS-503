﻿Shader "Hidden/HighlightShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_AddTex("Added Texture", 2D) = "white" {}
		_Multiplier ("Lighting Multiplier", float) = 10
    }
    SubShader
    {
        // No culling or depth
        Cull Off ZWrite Off ZTest Always

        Pass
        {
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

            sampler2D _MainTex;
			sampler2D _AddTex;
			float _Multiplier;

            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 addCol = tex2D(_AddTex, i.uv);

				fixed4 changeCol = fixed4(col.r * addCol.r, col.g * addCol.g, col.b * addCol.b, 1);

				col += changeCol * _Multiplier;
                return col;
            }
            ENDCG
        }
    }
}
