Shader "Custom/UnlitGrid"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Stamina("Stamina", Float) = 1.0
	}
	SubShader
	{
		Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
		LOD 100

		ZWrite On
		Blend SrcAlpha OneMinusSrcAlpha

		// Tags { "RenderType"="Opaque" }
		// LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _Stamina;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				// o.vertex.y += 0.1 * sin( 1000.0 * o.vertex.x + 500.0 * _Time.x);
				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				UNITY_TRANSFER_FOG(o,o.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				col.xyz = 0.0;
				// col.xy = frac(8.0 * i.uv);
				// col.xyz = 0.0;
				// // i.uv.y = i.uv.y + 0.125 * sin(floor(fmod(10.0 * i.uv.x, 2.0 )) + 250.0 * _Time.x);
				i.uv.y = i.uv.y + 0.125 * sin(10.0 * i.uv.x + 250.0 * _Time.x);
				col.x = frac(4.0 * i.uv).y * pow(2.0 * i.uv.y, 0.2);
				// // o.vertex.y -= 0.1 * sin(1000.0 * o.vertex.x + 500.0 * _Time.x);
				col.x *= i.uv.x;
				col.a = lerp(0.0, 1.0, step(length(col.rgb), _Stamina));
				// apply fog
				UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
