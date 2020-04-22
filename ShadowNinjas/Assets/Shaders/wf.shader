Shader "Custom/wf"
{
    Properties
    {
	_Color("Color", Color) = (1, 1, 1, 1)
	_Wireframe("Wireframe thickness", Range(0.0, 0.005)) = 0.0025
	_Transparency("Transparency", Range(0.0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        LOD 200
		
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			Cull Back
			
			CGPROGRAM
			
			#pragma vertex vertexFunction
			#pragma fragment fragmentFunction
			#pragma geometry geometryFunction
			#include "UnityCG.cginc"
			
			struct v2g
			{
				float4 pos : SV_POSITION;
			};
			struct g2f
			{
				float4 pos : SV_POSITION;
				float3 bary : TEXCOORD0;
			};
			
			v2g vertexFunction(appdata_base v)
			{
				v2g o;
				o.pos = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			[maxvertexcount(3)]
			void geometryFunction(triangle v2g IN[3], 
			     inout TriangleStream<g2f> triStream)
			{
				g2f o;
				o.pos = IN[0].pos;
				o.bary = float3(1, 0, 0);
				triStream.Append(o);
				o.pos = IN[1].pos;
				o.bary = float3(0, 0, 1);
				triStream.Append(o);
				o.pos = IN[2].pos;
				o.bary = float3(0, 1, 0);
				triStream.Append(o);
			}
			
			float _Wireframe;
			fixed4 _Color;
			float _Transparency;
			fixed4 fragmentFunction(g2f i) : SV_Target
			{
				float value = min(i.bary.x, (min(i.bary.y, i.bary.z)));
				value = exp2(-1 / _Wireframe * value * value);
				fixed4 col = _Color;
				col.a = _Transparency;
				return col * value;
			}
			ENDCG
			
		}
    }
    
}
